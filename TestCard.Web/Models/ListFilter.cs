using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCard.Web.Models
{
    public class ListFilter
    {
        public string Name { get; set; }
        public List<Item> Items { get; set; }

        public class Item
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public bool Selected { get; set; }
        }
    }
}