using DataStructures;
using Demo.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly PersonContext _db;

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