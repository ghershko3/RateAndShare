using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using RateAndShare.Models;

namespace RateAndShare.Controllers
{
    public class CountriesController : Controller
    {
        private RateAndShareContext db = new RateAndShareContext();

        // GET: Countries
        public ActionResult Index()
        {
            object userSession = HttpContext.Session[UsersController.SessionName];
            object isAdminSession = HttpContext.Session[UsersController.SessionIsAdminName];
            if (userSession != null && (bool)isAdminSession)
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
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
