using System;
using System.ComponentModel.DataAnnotations;
using TestCard.Properties.Resources;
using System.Web.Mvc;

namespace TestCard.Web.Models
{
    public class RegisterModel
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
        public string AccountTypeName{ get; set; }

        [Required(ErrorMessage = "",
           ErrorMessageResourceName = "FillRequiredField",
           ErrorMessageResourceType = typeof(GeneralResource))]
        [Display(Name = "Password", ResourceType = typeof(GeneralResource))]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "",
           ErrorMessageResourceName = "FillRequiredField",
           ErrorMessageResourceType = typeof(GeneralResource))]
        [Display(Name = "RepeatPassword", ResourceType = typeof(GeneralResource))]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password",
            ErrorMessage = "",
            ErrorMessageResourceName = "PasswordsMustMatch",
            ErrorMessageResourceType = typeof(GeneralResource))]
        public string RepeatPassword { get; set; }

        public SelectList AccountTypeSelectList { get; set; }
        public SelectList CompanySelectList { get; set; }
    }
}