using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCard.Web.Models
{
    public interface IFilteredList
    {
        ListFilter Filter { get; set; }
    }
}