using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Duplicates.Models;
using System.IO;
using Phonix;
namespace Duplicates.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetSearchResults(Dictionary<string, string> parameters, Dictionary<string, string> columns, List<Dictionary<string, string>> data)
        {
            List<Dictionary<string, string>> searchFields = SearchDatabase(parameters, columns, data);
            return Json(searchFields, JsonRequestBehavior.AllowGet);
        }

        private List<Dictionary<string, string>> SearchDatabase(Dictionary<string, string> parameters, Dictionary<string, string> columns, List<Dictionary<string, string>> data)
        {

            List<Dictionary<string, string>> table = new List<Dictionary<string, string>>();

            for (int i = 0; i < data.Count; i++)
            {
                Dictionary<string, string> row = data[i];
                foreach (var parameter in parameters.Keys)
                {
                    if (!Equals(parameter, "uniqueID"))
                    {
                        DoubleMetaphone _generator = new DoubleMetaphone();
                        string[] match = new string[2];
                        match[0] = row[parameter];
                        match[1] = parameters[parameter];
                        if (_generator.IsSimilar(match))
                        {
                            table.Add(row);
                        }
                    }
                }

            }
            return table;

        }
    }
}

