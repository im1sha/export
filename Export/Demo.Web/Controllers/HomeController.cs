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

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TextExport()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + @"\bin\Test.txt";
            using (FileStream file = new FileStream(path, FileMode.OpenOrCreate))
            {
                DefaultDocumentGeneratorFactory factory = new DefaultDocumentGeneratorFactory(
                    new DefaultCompositionRoot());

                var docGen = factory.Create<IEnumerable<Person>>(DocumentType.Txt);

                docGen.Generate(file, new List<Person>
                {
                    new Person
                    {
                        Name = "user 1",
                        Surname = "test 1"
                    },
                    new Person
                    {
                        Name = "user 2",
                        Surname = "test 2"
                    },
                       new Person
                    {
                        Name = "user 3",
                        Surname = "test 126845"
                    }
                });
                return RedirectToAction("IndexTxt");
            }

        }

        public ActionResult XlsxExport()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + @"\bin\Test.xlsx";
            using (FileStream file = new FileStream(path, FileMode.OpenOrCreate))
            {
                DefaultDocumentGeneratorFactory factory = new DefaultDocumentGeneratorFactory(
                    new DefaultCompositionRoot());

                var docGen = factory.Create<IEnumerable<Person>>(DocumentType.Xlsx);

                docGen.Generate(file, new List<Person>
                {
                    new Person
                    {
                        Name = "user 1",
                        Surname = "test 1"
                    },
                    new Person
                    {
                        Name = "user 2",
                        Surname = "test 2"
                    },
                       new Person
                    {
                        Name = "user 3",
                        Surname = "test 126845"
                    }
                });
                return RedirectToAction("IndexXlsx");
            }

        }

        public ActionResult PdfExport()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + @"\bin\Test.pdf";
            using (FileStream file = new FileStream(path, FileMode.OpenOrCreate))
            {
                DefaultDocumentGeneratorFactory factory = new DefaultDocumentGeneratorFactory(
                    new DefaultCompositionRoot());

                var docGen = factory.Create<IEnumerable<Person>>(DocumentType.Pdf);

                docGen.Generate(file, new List<Person>
                {
                    new Person
                    {
                        Name = "user 1",
                        Surname = "test 1"
                    },
                    new Person
                    {
                        Name = "user 2",
                        Surname = "test 2"
                    },
                       new Person
                    {
                        Name = "user 3",
                        Surname = "test 126845"
                    }
                });
                return RedirectToAction("IndexPdf");
            }
        }

        public string IndexTxt()
        {
            return "Экспор данных в формат txt успешно завершён!";
        }

        public string IndexXlsx()
        {
            return "Экспор данных в формат xlsx успешно завершён!";
        }


        public string IndexPdf()
        {
            return "Экспор данных в формат pdf успешно завершён!";
        }


    }
}