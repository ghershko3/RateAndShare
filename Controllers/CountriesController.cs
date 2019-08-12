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
            return View(db.Countries.ToList());
        }

        // GET: Countries/GetCountryGroupBy
        public ActionResult GetCountryGroupBy()
        {
            JObject countries = new JObject();
            foreach (Country country in db.Countries.ToList())
            {
                countries.Add(country.Name, country.Users.Count);
            }

            return View(countries);
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
