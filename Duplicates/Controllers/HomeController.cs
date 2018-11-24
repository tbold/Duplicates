using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Duplicates.Models;

namespace Duplicates.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SearchModel model = new SearchModel();
            return View(model);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Database()
        {
            return View();
        }
    }
}