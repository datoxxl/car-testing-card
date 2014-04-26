using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestCard.Properties;
using TestCard.Properties.Resources;

namespace TestCard.Web.Models
{
    public class TestingCardChangeRequestListModel : ChangeRequestBase
    {
        public int TestingCardChangeRequestID { get; set; }
        public int? TestingCardID { get; set; }

        [Display(Name = "Number", ResourceType = typeof(GeneralResource))]
        public string TestingCardNumber { get; set; }
    }
}