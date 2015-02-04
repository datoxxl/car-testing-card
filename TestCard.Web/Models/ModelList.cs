using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCard.Web.Models
{
    public class ModelList<T> : List<T>, IFilteredList
    {
        public ListFilter Filter { get; set; }
    }
}