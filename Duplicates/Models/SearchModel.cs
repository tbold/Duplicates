using System;
using System.Web;
using System.Collections.Generic;

namespace Duplicates.Models
{
    public class SearchModel
    {
        public string uniqueIdentifier { get; set; }
        public List<Dictionary<string, string>> data { get; set; }
        public List<string> columns { get; set; }
    }
}
