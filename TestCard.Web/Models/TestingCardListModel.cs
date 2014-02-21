using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestCard.Properties.Resources;

namespace TestCard.Web.Models
{
    public class TestingCardListModel
    {
        public int TestingCardID { get; set; }

        public string Number { get; set; }

        [Display(Name = "OwnerIDNo", ResourceType = typeof(GeneralResource))]
        public string OwnerIDNo { get; set; }

        public bool? IsValid { get; set; }

        public string FirnishNumber { get; set; }

        public DateTime? FirnishDate { get; set; }

        [Display(Name = "Comment", ResourceType = typeof(GeneralResource))]
        public string Comment { get; set; }

        public int? ResponsiblePersonID { get; set; }

        [Display(Name = "Odometer", ResourceType = typeof(GeneralResource))]
        public decimal? Odometer { get; set; }

        public int? CompanyID { get; set; }

        [Display(Name = "CardNumber", ResourceType = typeof(GeneralResource))]
        public string TestingCardNumber { get; set; }

        [Display(Name = "VINCode", ResourceType = typeof(GeneralResource))]
        public string VIN { get; set; }

        [Display(Name = "CarModel", ResourceType = typeof(GeneralResource))]
        public string CarModel { get; set; }

        [Display(Name = "CarNumber", ResourceType = typeof(GeneralResource))]
        public string CarNumber { get; set; }

        [Display(Name = "CarSerialNo", ResourceType = typeof(GeneralResource))]
        public string CarSerialNo { get; set; }

        [Display(Name = "OwnerName", ResourceType = typeof(GeneralResource))]
        public string OwnerName { get; set; }

        [Display(Name = "EffectiveDate", ResourceType = typeof(GeneralResource))]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? EffectiveDate { get; set; }

        [Display(Name = "Company", ResourceType = typeof(GeneralResource))]
        public string CompanyName { get; set; }

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
    }
}