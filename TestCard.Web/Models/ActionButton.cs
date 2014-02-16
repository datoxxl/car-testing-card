using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCard.Web.Models
{
    public class ActionButton
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public ActionType Type { get; set; }

        public enum ActionType { Add, Edit, Delete }
    }
}