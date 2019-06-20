using Demo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        PersonContext _db;
        public HomeController()
        {
            _db = new PersonContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Index2()
        {
            var db = _db.People.ToList();
            return View(db);
        }

        [HttpPost]
        public ActionResult Index2(Person person)
        {

            return View();
        }
    }
}