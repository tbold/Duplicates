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
            SearchModel model = new SearchModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult SearchManually(Dictionary<string, string> parameters, List<Dictionary<string, string>> data)
        {
            List<Dictionary<string, string>> table = new List<Dictionary<string, string>>();
            table = SearchDatabase(parameters, data, table);
            return Json(table, JsonRequestBehavior.AllowGet);
        }

        private List<Dictionary<string, string>> SearchDatabase(Dictionary<string, string> parameters, List<Dictionary<string, string>> data, List<Dictionary<string, string>> table)
        {

            for (int i = 0; i < data.Count; i++)
            {
                Dictionary<string, string> row = data[i];
                foreach (var parameter in parameters)
                {
                    if (!Equals(parameter.Key, "uniqueID"))
                    {
                        DoubleMetaphone _generator = new DoubleMetaphone();
                        string[] match = new string[2];
                        match[0] = row[parameter.Key];
                        match[1] = parameters[parameter.Key];
                        if (_generator.IsSimilar(match))
                        {
                            table.Add(row);
                            data.Remove(row);
                        }
                    }
                }
            }
            return table;
        }

        [HttpPost]
        public ActionResult SearchByVariable(SearchModel model, string searchVariable)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["uniqueID"] = model.uniqueIdentifier;
            List<Dictionary<string, string>> table = new List<Dictionary<string, string>>();
            List<Dictionary<string, string>> data = model.data;
            for (int i = 0; i < data.Count; i++)
            {
                parameters[searchVariable] = model.data[i][searchVariable];
                SearchDatabase(parameters, data, table);
            }
            return Json(table, JsonRequestBehavior.AllowGet);
        }
    }
}

