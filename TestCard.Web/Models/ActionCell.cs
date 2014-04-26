using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestCard.Domain;

namespace TestCard.Web.Models
{
    public class ActionCell
    {
        public Objects EntityObject { get; set; }
        public List<ActionButton> Items { get; set; }
    }
}