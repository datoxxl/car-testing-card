using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestCard.Properties.Resources;

namespace TestCard.Web.Models
{
    public class CompanyModel
    {
        [ScaffoldColumn(true)]
        public int CompanyID { get; set; }

        [Required(ErrorMessage = "",
           ErrorMessageResourceName = "FillRequiredField",
           ErrorMessageResourceType = typeof(GeneralResource))]
        [Display(Name = "Title", ResourceType = typeof(GeneralResource))]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "",
           ErrorMessageResourceName = "FillRequiredField",
           ErrorMessageResourceType = typeof(GeneralResource))]
        [Display(Name = "Telephone", ResourceType = typeof(GeneralResource))]
        public string Phone { get; set; }

        [Required(ErrorMessage = "",
           ErrorMessageResourceName = "FillRequiredField",
           ErrorMessageResourceType = typeof(GeneralResource))]
        [Display(Name = "AccreditationScope", ResourceType = typeof(GeneralResource))]
        public string AccreditationScope { get; set; }

        [Required(ErrorMessage = "",
           ErrorMessageResourceName = "FillRequiredField",
           ErrorMessageResourceType = typeof(GeneralResource))]
        [Display(Name = "AccreditationNumber", ResourceType = typeof(GeneralResource))]
        public string AccreditationNumber { get; set; }

        [Required(ErrorMessage = "",
           ErrorMessageResourceName = "FillRequiredField",
           ErrorMessageResourceType = typeof(GeneralResource))]
        [Display(Name = "AccreditationDate", ResourceType = typeof(GeneralResource))]
        public Nullable<System.DateTime> AccreditationExpireDate { get; set; }

        [Required(ErrorMessage = "",
           ErrorMessageResourceName = "FillRequiredField",
           ErrorMessageResourceType = typeof(GeneralResource))]
        [StringLength(9,
           MinimumLength = 9,
           ErrorMessage = "",
           ErrorMessageResourceName = "StringLengthErrorMessage",
           ErrorMessageResourceType = typeof(GeneralResource))]
        [Display(Name = "IdentificationNumber", ResourceType = typeof(GeneralResource))]
        public string IDNo { get; set; }

        public string FileName { get; set; }
    }
}