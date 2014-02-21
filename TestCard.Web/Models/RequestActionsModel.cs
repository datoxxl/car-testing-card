using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCard.Web.Models
{
    public class RequestActionsModel
    {
        public int RequestID { get; set; }

        public string Action { get; set; }

        public string Controller { get; set; }
    }
}