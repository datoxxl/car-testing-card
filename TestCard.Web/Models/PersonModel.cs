using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCard.Properties.Resources;

namespace TestCard.Web.Models
{
    public class PersonModel
    {
        public int? PersonID { get; set; }
        public int? PersonChangeRequestID { get; set; }

        [Required(ErrorMessage = "",
           ErrorMessageResourceName = "FillRequiredField",
           ErrorMessageResourceType = typeof(GeneralResource))]
        [Display(Name = "Name", ResourceType = typeof(GeneralResource))]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "",
           ErrorMessageResourceName = "FillRequiredField",
           ErrorMessageResourceType = typeof(GeneralResource))]
        [Display(Name = "LastName", ResourceType = typeof(GeneralResource))]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "",
            ErrorMessageResourceName = "EmailNotValid",
            ErrorMessageResourceType = typeof(GeneralResource))]
        [Required(ErrorMessage = "",
           ErrorMessageResourceName = "FillRequiredField",
           ErrorMessageResourceType = typeof(GeneralResource))]
        [Display(Name = "Email", ResourceType = typeof(GeneralResource))]
        public string Email { get; set; }

        [Required(ErrorMessage = "",
           ErrorMessageResourceName = "FillRequiredField",
           ErrorMessageResourceType = typeof(GeneralResource))]
        [Display(Name = "Tel", ResourceType = typeof(GeneralResource))]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "",
           ErrorMessageResourceName = "FillRequiredField",
           ErrorMessageResourceType = typeof(GeneralResource))]
        [StringLength(11,
            MinimumLength = 11,
            ErrorMessage = "",
            ErrorMessageResourceName = "IdNumberMaxLengthError",
            ErrorMessageResourceType = typeof(GeneralResource))]
        [Display(Name = "IdNumber", ResourceType = typeof(GeneralResource))]
        public string IDNo { get; set; }

        [Required(ErrorMessage = "",
           ErrorMessageResourceName = "FillRequiredField",
           ErrorMessageResourceType = typeof(GeneralResource))]
        [Display(Name = "Company", ResourceType = typeof(GeneralResource))]
        public Nullable<int> CompanyID { get; set; }

        [Display(Name = "Company", ResourceType = typeof(GeneralResource))]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "",
           ErrorMessageResourceName = "FillRequiredField",
           ErrorMessageResourceType = typeof(GeneralResource))]
        [Display(Name = "Type", ResourceType = typeof(GeneralResource))]
        public int AccountTypeID { get; set; }

        [Display(Name = "Type", ResourceType = typeof(GeneralResource))]
        public string AccountTypeName { get; set; }

        public SelectList AccountTypeSelectList { get; set; }
        public SelectList CompanySelectList { get; set; }
    }
}