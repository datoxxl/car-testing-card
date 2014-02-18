using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestCard.Properties.Resources;

namespace TestCard.Web.Models
{
    public class PersonListModel
    {
        public int? PersonID { get; set; }
        public int? PersonChangeRequestID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Display(Name = "User", ResourceType = typeof(GeneralResource))]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
            set { }
        }

        [Display(Name = "Email", ResourceType = typeof(GeneralResource))]
        public string Email { get; set; }

        [Display(Name = "Telephone", ResourceType = typeof(GeneralResource))]
        public string Mobile { get; set; }

        [Display(Name = "IdNumber", ResourceType = typeof(GeneralResource))]
        public string IDNo { get; set; }

        public Nullable<int> CompanyID { get; set; }

        [Display(Name = "Company", ResourceType = typeof(GeneralResource))]
        public string CompanyName { get; set; }

        [Display(Name = "Type", ResourceType = typeof(GeneralResource))]
        public string AccountTypeName { get; set; }
    }
}