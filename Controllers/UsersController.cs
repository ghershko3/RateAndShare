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
    public class UsersController : Controller
    {
        public const string SessionName = "UserId";
        public const string SessionUserName = "UserName";
        public const string SessionIsAdminName = "IsAdmin";

        private RateAndShareContext db = new RateAndShareContext();

        // GET: Users/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Username,Password")] User p_user)
        {
            if (p_user == null)
            {
                return View();
            }
            // check if the given params are correct and there is a user
            else if (p_user.Username != null && p_user.Password != null && isUserExists(p_user.Username, p_user.Password))
            {
                User currUser = db.Users.First(user => user.Username == p_user.Username);
                int userId = currUser.UserId;
                bool isAdmin = currUser.IsAdmin;
                string userName = currUser.Username;

                HttpContext.Session.Add(SessionName, userId);
                HttpContext.Session.Add(SessionUserName, userName);
                HttpContext.Session.Add(SessionIsAdminName, isAdmin);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["ErrMessage"] = "Incorrect user name or password";
            }

            return View();
        }

        // GET: Users/Register
        public ActionResult Register()
        {
            ViewData["countries"] = db.Countries.ToList();

            List<SelectListItem> countries = new List<SelectListItem>();

            foreach (RateAndShare.Models.Country country in ((IEnumerable<RateAndShare.Models.Country>)ViewData["countries"]))
            {
                countries.Add(new SelectListItem { Text = country.Name, Value = country.Id.ToString() });
            }

            ViewBag.countries = countries;

            return View();
        }

        // POST: Users/Register
        [HttpPost]
        public async Task<ActionResult> Register([Bind(Include = "Username,Password,Email,CountryId")] User p_user)
        {
            if (ModelState.IsValid)
            {
                // Check if there already User with the same username
                if (db.Users.Any(user => user.Username == p_user.Username))
                {
                    ViewData["ErrMessage"] = "The requeseted username is already taken, sorry..";
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                db.Users.Add(p_user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // GET: Users/LogOut
        public ActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        private bool isUserExists(string p_username, string p_password)
        {
            return db.Users.Any(user => user.Username == p_username && user.Password == p_password);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}