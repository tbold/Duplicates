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
            var table = ReadTableContents(filename, columns);
            return Json(table, JsonRequestBehavior.AllowGet);
        }

        private static List<Dictionary<string, string>> ReadTableContents(string filename, List<string> columns)
        {
            List<Dictionary<string, string>> table = new List<Dictionary<string, string>>();
            using (var reader = new StreamReader(@"/Users/" + filename + ".csv"))
            {
                if (reader.ReadLine() != null)
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine().Split(',');
                        Dictionary<string, string> row = new Dictionary<string, string>();
                        for (int i = 0; i < line.Length; i++)
                        {
                            row.Add(columns[i], line[i].ToString());
                        }
                        table.Add(row);
                    }
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

        [HttpPost]
        public List<Dictionary<string, string>> GetSubsetTable(List<Dictionary<string, string>> fields, string filename)
        {
            List<string> columns = GetColumnNames(filename);
            List<Dictionary<string, string>> table = ReadTableContents(filename, columns);
            List<Dictionary<string, string>> results = new List<Dictionary<string, string>>();
            for (int j = 0; j < table.Count(); j++)
            {
                List<string> tableKeys = new List<string>(table[j].Keys);
                List<string> fieldsKeys = new List<string>(fields[0].Keys);
                Dictionary<string, string> row = new Dictionary<string, string>();

                for (int i = 0; i < fieldsKeys.Count(); i++)
                {
                    if (tableKeys.IndexOf(fieldsKeys[i]) != -1)
                    {
                        //row.Add();
                    }
                }
            }
            return results;
        }
    }
}
