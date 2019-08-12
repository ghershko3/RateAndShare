using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RateAndShare.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RateAndShare.Controllers
{
    public class StatisticsController : Controller
    {
        private RateAndShareContext db = new RateAndShareContext();

        // GET: Statistics
        public ActionResult Index()
        {
            object userSession = HttpContext.Session[UsersController.SessionName];
            object isAdmin = HttpContext.Session[UsersController.SessionIsAdminName];
            if (userSession == null || isAdmin == null || !(bool)isAdmin)
            {
                return RedirectToAction("Index", "Home");
            }

            Hashtable countries = new Hashtable();
            db.Countries.ToList().ForEach(country => countries.Add(country.Id, country.Name));
            var users = db.Users.GroupBy(user => user.CountryId).Select(user => new { countryId = user.Key, count = (user.Count()) }).ToList();
            ViewBag.userLocationData = JsonConvert.SerializeObject(users);
            ViewBag.countries = JsonConvert.SerializeObject(countries);

            var rates = db.Rates.GroupBy(rate => rate.UserId).Select(rate => new { userId = rate.Key, count = rate.Count() }).ToList();
            JArray userRates = new JArray();
            rates.ForEach(rate =>
            {
                JObject currUserRates = new JObject();
                currUserRates.Add("username", db.Users.Find(rate.userId).Username);
                currUserRates.Add("count", rate.count);
                userRates.Add(currUserRates);
            });

            ViewBag.userRatesData = JsonConvert.SerializeObject(userRates);
            return View();
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