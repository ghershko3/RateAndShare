using RateAndShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RateAndShare.Controllers
{
    public class RatesController : Controller
    {
        private RateAndShareContext db = new RateAndShareContext();

        // GET: Rates
        public ActionResult Index()
        {
            return View(db.Rates.ToList());
        }

        // GET: Rates/GetRatesForSong/5
        public ActionResult GetRatesForSong(int? p_songId)
        {
            List<Rate> rates = null;
            try
            {
                rates = db.Rates.Where(rate => rate.SongId == p_songId).ToList();
            }
            catch (Exception)
            {
                rates = new List<Rate>();
            }

            return View(rates);
        }

        // GET: Rates/GetRatesForUser/5
        public ActionResult GetRatesForUser(int? p_userId)
        {
            List<Rate> rates = null;
            try
            {
                rates = db.Rates.Where(rate => rate.UserId == p_userId).ToList();
            }
            catch (Exception)
            {
                rates = new List<Rate>();
            }

            return View(rates);
        }

        // GET: Rates/GetRatesFromGrade/5/1
        // A method that gets all the song's rates that have higher grade then the given
        public ActionResult GetRatesFromGrade(int p_songId, int p_fromGrade)
        {
            List<Rate> rates = null;
            try
            {
                rates = db.Rates.Where(rate => rate.SongId == p_songId && rate.NumOfStars >= p_fromGrade).ToList();
            }
            catch (Exception)
            {
                rates = new List<Rate>();
            }

            return View(rates);
        }

        // GET: Rates/Create
        public ActionResult Create()
        {
            ViewBag.songsList = new SelectList(db.Songs, "SongId", "SongName");
            return View();
        }

        // POST: Rates/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "SongId,NumOfStars")] Rate p_rate)
        {
            // Check if the user is loged in
            object userSession = HttpContext.Session[UsersController.SessionName];
            if (userSession != null)
            {
                // Save the rate with the user id
                int userId = (int)userSession;
                p_rate.UserId = userId;

                if (ModelState.IsValid)
                {
                    db.Rates.Add(p_rate);
                    await db.SaveChangesAsync();
                }
            }
            else
            {
                return RedirectToRoute("Users");
            }

            return View();
        }

        // POST: Rates/Edit
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include = "ID,SongId,NumOfStars")] Rate p_rate)
        {
            object userSession = HttpContext.Session[UsersController.SessionName];
            if (userSession == null)
            {
                return RedirectToRoute("Users");
            }
            else if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int userId = int.Parse((string)userSession);
            Rate currentRate = db.Rates.First(rate => rate.ID == p_rate.ID);

            // Check if the current user created the requested Rate, user can update rates that only he created
            if (currentRate.UserId == userId)
            {
                db.Entry(p_rate).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            return View();
        }

        // POST: Rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            object userSession = HttpContext.Session[UsersController.SessionName];
            if (userSession == null)
            {
                return RedirectToRoute("Users");
            }

            int userId = int.Parse((string)userSession);
            Rate rate = db.Rates.Find(id);

            if (rate.UserId == userId)
            {
                db.Rates.Remove(rate);
                db.SaveChanges();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            return View();
        }
    }
}