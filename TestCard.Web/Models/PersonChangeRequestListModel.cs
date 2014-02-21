using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestCard.Properties;
using TestCard.Properties.Resources;

namespace TestCard.Web.Models
{
    public class PersonChangeRequestListModel
    {
        public int PersonChangeRequestID { get; set; }
        public int? PersonID { get; set; }
        public int? ResponsiblePersonID { get; set; }

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

        public string ResponsiblePersonFirstName { get; set; }
        public string ResponsiblePersonLastName { get; set; }

        [Display(Name = "RequestUser", ResourceType = typeof(GeneralResource))]
        public string ResponsiblePersonFullName
        {
            get
            {
                return string.Format("{0} {1}", ResponsiblePersonFirstName, ResponsiblePersonLastName);
            }
            set { }
        }

        [Display(Name = "RequestDate", ResourceType = typeof(GeneralResource))]
        public Nullable<System.DateTime> CreateDate { get; set; }

        public int? QualityManagerConfirmStatusID { get; set; }

        [Display(Name = "AdministratorConfirm", ResourceType = typeof(GeneralResource))]
        public string QualityManagerConfirmStatusName { get; set; }

        public int? AdministatorConfirmStatusID { get; set; }

        [Display(Name = "QualityManagerConfirm", ResourceType = typeof(GeneralResource))]
        public string AdministratorConfirmStatusName { get; set; }
    }
}