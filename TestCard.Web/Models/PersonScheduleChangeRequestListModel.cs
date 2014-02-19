using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCard.Web.Models
{
    public class PersonScheduleChangeRequestListModel
    {
        public int PersonScheduleChangeRequestID { get; set; }
        public int? PersonID { get; set; }
        public int? ResponsiblePersonID { get; set; }

        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }

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

        public string ResponsiblePersonFullName
        {
            get
            {
                return string.Format("{0} {1}", ResponsiblePersonFirstName, ResponsiblePersonLastName);
            }
            set { }
        }

        public Nullable<System.DateTime> CreateDate { get; set; }

        public int? QualityManagerConfirmStatusID { get; set; }
        public string QualityManagerConfirmStatusName { get; set; }

        public int? AdministatorConfirmStatusID { get; set; }
        public string AdministratorConfirmStatusName { get; set; }
    }
}