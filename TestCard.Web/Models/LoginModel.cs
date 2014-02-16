using TestCard.Properties.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestCard.Web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "",
            ErrorMessageResourceName = "FillRequiredField",
            ErrorMessageResourceType = typeof(GeneralResource))]
        [StringLength(11,
            MinimumLength = 11,
            ErrorMessage = "",
            ErrorMessageResourceName = "IdNumberMaxLengthError",
            ErrorMessageResourceType = typeof(GeneralResource))]
        [Display(Name = "IdNumber", ResourceType = typeof(GeneralResource))]
        public string IdNumber { get; set; }

        [Required(ErrorMessage = "",
            ErrorMessageResourceName = "FillRequiredField",
            ErrorMessageResourceType = typeof(GeneralResource))]
        [Display(Name = "Password", ResourceType = typeof(GeneralResource))]
        public string Password { get; set; }
    }
}