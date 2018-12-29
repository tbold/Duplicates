using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Duplicates.Controllers
{
    public class TableController : Controller
    {
        // GET: Table
        [HttpPost]
        public ActionResult ReadTable(string filename)
        {
            List<string> columns = GetColumnNames(filename);
            List<Dictionary<string, string>> table = new List<Dictionary<string, string>>();
            return Json(table, JsonRequestBehavior.AllowGet);
        }

        public static List<Dictionary<string, string>> ReadTableContents(string[] columns, string[] data)
        {
            List<Dictionary<string, string>> table = new List<Dictionary<string, string>>();
            {
                for (var i = 1; i < data.Count() - 1; i++)
                {
                    var line = data[i].Split(',');
                    Dictionary<string, string> row = new Dictionary<string, string>();
                    for (int j = 0; j < line.Length; j++)
                    {
                        row.Add(columns[j], line[j]);
                    }
                    table.Add(row);
                }


            }
            return table;
        }

        [HttpPost]
        public ActionResult GetColumns(string filename)
        {
            List<string> columns = GetColumnNames(filename);
            return Json(columns, JsonRequestBehavior.AllowGet);
        }

        private List<string> GetColumnNames(string filename)
        {
            List<string> columns = new List<string>();
            using (var reader = new StreamReader(@"/Users/" + filename + ".csv"))
            {
                if (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Split(',');
                    for (int i = 0; i < line.Length; i++)
                    {
                        columns.Add(line[i]);
                    }
                }
            }
            return columns;
        }
    }
}
