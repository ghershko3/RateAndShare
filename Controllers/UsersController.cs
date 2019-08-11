using RateAndShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RateAndShare.Controllers
{
    public class UsersController : Controller
    {
        public const string SessionName = "UserId";
        private RateAndShareContext db = new RateAndShareContext();

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login([Bind(Include = "Username,Password")] User p_user)
        {
            if (p_user == null)
            {
                return View("Login");
            }
            // check if the given params are correct and there is a user
            else if (p_user.Username != null && p_user.Password != null && isUserExists(p_user.Username, p_user.Password))
            {
                int userId = db.Users.First(user => user.Username == p_user.Username).UserId;
                HttpContext.Session.Add(SessionName, userId);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["ErrMessage"] = "Incorrect user name or password";
            }

            return View("Login");
        }

        // POST: Users/Register
        [HttpPost]
        public async Task<ActionResult> Register([Bind(Include = "Username,Password,Email")] User p_user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(p_user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
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
    }
}