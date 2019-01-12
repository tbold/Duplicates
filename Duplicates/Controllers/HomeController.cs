using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Duplicates.Controllers;
namespace DuplicatesFinder.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ReadTable(string[] columns, string[] data)
        {
            List<Dictionary<string, string>> table = new List<Dictionary<string, string>>();
            table = TableController.ReadTableContents(columns, data);
            return Json(table, JsonRequestBehavior.AllowGet);
        }
    }
}