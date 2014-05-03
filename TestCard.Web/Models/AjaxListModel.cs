using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCard.Web.Models
{
    public class AjaxListModel
    {
        public string ActionName { get; set; }
        public string ControllerName { get; set; }

        public object RouteValues { get; set; }

        public ListFilter Filter { get; set; }
    }
}