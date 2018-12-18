﻿using System;
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
        public ActionResult GetSearchResults(Dictionary<string, string> parameters, string filename)
        {
            List<Dictionary<string, string>> searchFields = SearchDatabase(parameters, filename);
            return Json(searchFields, JsonRequestBehavior.AllowGet);
        }

        private List<Dictionary<string, string>> SearchDatabase(Dictionary<string, string> parameters, string filename)
        {

            List<Dictionary<string, string>> table = new List<Dictionary<string, string>>();
            using (var reader = new StreamReader(@"/Users/" + filename + ".csv"))
            {
                if (!reader.EndOfStream)
                {
                    string[] columns = reader.ReadLine().Split(',');
                    List<string> keys = new List<string>(parameters.Keys);
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine().Split(',');
                        Dictionary<string, string> row = new Dictionary<string, string>();
                        for (int i = 0; i < keys.Count; i++)
                        {
                            int id = keys.IndexOf("uniqueID");
                            if (id != i)
                            {
                                int searchField = Array.IndexOf(columns, keys[i]);
                                DoubleMetaphone _generator = new DoubleMetaphone();
                                string[] match = new string[2];
                                match[0] = line[searchField];
                                match[1] = parameters[keys[i]];
                                if (_generator.IsSimilar(match))
                                {
                                    for (int j = 0; j < line.Length; j++)
                                    {
                                        row.Add(columns[j], line[j]);
                                    }
                                    table.Add(row);
                                }
                            }
                        }
                    }
                }
            }
            return table;
        }

        /*
        private List<Dictionary<string, string>> FindMetaphone(Dictionary<string, string> parameters, List<Dictionary<string, string>> searchFields)
        {
            string[] Fields = new string[searchFields.Count()];
            string[] Ids = new string[searchFields.Count()];
            List<string> keys = new List<string>(parameters.Keys);
            int count = 0;
            foreach (var item in searchFields)
            {
                Fields[count] = item[keys[1]];
                Ids[count++] = item[keys[0]];
            }
            List<Dictionary<string, string>> results = new List<Dictionary<string, string>>();
            DoubleMetaphone _generator = new DoubleMetaphone();
            for (int i = 0; i < Fields.Length; i++)
            {
                string[] match = new string[2];
                match[0] = Fields[i];
                match[1] = parameters[keys[1]];
                bool similar = _generator.IsSimilar(match);
                if (similar)
                {
                    Dictionary<string, string> row = new Dictionary<string, string>();
                    for (int j = 0; j < keys.Count(); j++)
                    {
                        row.Add(keys[j], searchFields[i][keys[j]]);
                        //row.Add(searchFields[i]);
                    }
                    results.Add(row);
                }

            }
            return results;
        }*/

    }
}

