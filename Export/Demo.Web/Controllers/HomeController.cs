using Demo.Web.Models;
using Export;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataStructures;

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
            //using (FileStream file = System.IO.File.Create("test.pdf"))
            //{
            //    DefaultDocumentGeneratorFactory factory = new DefaultDocumentGeneratorFactory(
            //        new DefaultCompositionRoot());

            //    var docGen = factory.Create<IEnumerable<Person>>(DocumentType.Pdf);

            //    docGen.Generate(file, new List<Person>
            //    {
            //       // null,
            //        new Person
            //        {
            //            Name = "user 1",
            //            Surname = "test 1"
            //        },
            //        //new Person
            //        //{
            //        //    Name = null,
            //        //    Surname = null
            //        //},
            //        new Person
            //        {
            //            Name = "user 2",
            //            Surname = "test 2"
            //        }
            //    });
            //}

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