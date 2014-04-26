﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestCard.Domain;

namespace TestCard.Web.Models
{
    public class ActionButton
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public ActionTypes Type { get; set; }
        public object ObjectID { get; set; }

        public enum ActionTypes { Add, Edit, Delete, Print }
    }
}