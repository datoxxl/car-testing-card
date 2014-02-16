using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestCard.Properties.Resources;

namespace TestCard.Web.Models
{
    public class CompanyListModel
    {
        [Display(Name = "Title", ResourceType = typeof(GeneralResource))]
        public string CompanyName { get; set; }
        [Display(Name = "Telephone", ResourceType = typeof(GeneralResource))]
        public string Phone { get; set; }
        [Display(Name = "AccreditationScope", ResourceType = typeof(GeneralResource))]
        public string AccreditationScope { get; set; }
        [Display(Name = "AccreditationNumber", ResourceType = typeof(GeneralResource))]
        public string AccreditationNumber { get; set; }
        [Display(Name = "AccreditationDate", ResourceType = typeof(GeneralResource))]
        public Nullable<System.DateTime> AccreditationExpireDate { get; set; }
    }
}