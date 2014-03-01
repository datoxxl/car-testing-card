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
        public int CompanyID { get; set; }
        [Display(Name = "Title", ResourceType = typeof(GeneralResource))]
        public string CompanyName { get; set; }
        [Display(Name = "Telephone", ResourceType = typeof(GeneralResource))]
        public string Phone { get; set; }
        [Display(Name = "Address", ResourceType = typeof(GeneralResource))]
        public string Address { get; set; }
        [Display(Name = "AccreditationScope", ResourceType = typeof(GeneralResource))]
        public string AccreditationScope { get; set; }
        [Display(Name = "AccreditationNumber", ResourceType = typeof(GeneralResource))]
        public string AccreditationNumber { get; set; }
        [Display(Name = "AccreditationDate", ResourceType = typeof(GeneralResource))]
        [DisplayFormat(DataFormatString="{0:dd.MM.yyyy}")]
        public Nullable<System.DateTime> AccreditationExpireDate { get; set; }
    }
}