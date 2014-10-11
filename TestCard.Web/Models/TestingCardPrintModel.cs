using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestCard.Properties.Resources;

namespace TestCard.Web.Models
{
    public class TestingCardPrintModel : TestingCardModel
    {
        [Display(Name = "EffectiveDate", ResourceType = typeof(GeneralResource))]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? EffectiveDate { get; set; }

        public int? ResponsiblePersonID { get; set; }

        [Display(Name = "RespFullName", ResourceType = typeof(GeneralResource))]
        public string RespPersonFullName { get; set; }

        [Display(Name = "Valid", ResourceType = typeof(GeneralResource))]
        public string Valid
        {
            get
            {
                return IsValid.HasValue && IsValid.Value ? GeneralResource.Valid : GeneralResource.NotValid;
            }
            set { }
        }

        public bool IsFirstTesting { get; set; }

        public int? CompanyID { get; set; }

        public string CompanyLogoFileName { get; set; }

        public string AccreditationLogoFileName { get; set; }

        [Display(Name = "Company", ResourceType = typeof(GeneralResource))]
        public string CompanyName { get; set; }

        [Display(Name = "AccreditationNumber", ResourceType = typeof(GeneralResource))]
        public string CompanyAccreditationNumber { get; set; }

        [Display(Name = "AccreditationScope", ResourceType = typeof(GeneralResource))]
        public string CompanyAccreditationScope { get; set; }

        [Display(Name = "Address", ResourceType = typeof(GeneralResource))]
        public string CompanyAddress { get; set; }
    }
}