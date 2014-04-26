using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestCard.Properties;
using TestCard.Properties.Resources;

namespace TestCard.Web.Models
{
    public class PersonChangeRequestListModel : ChangeRequestBase
    {
        public int PersonChangeRequestID { get; set; }
        public int? PersonID { get; set; }

        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }

        [Display(Name = "User", ResourceType = typeof(GeneralResource))]
        public string PersonFullName
        {
            get
            {
                return string.Format("{0} {1}", PersonFirstName, PersonLastName);
            }
            set { }
        }
    }
}