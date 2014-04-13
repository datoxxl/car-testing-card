﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TestCard.Domain;
using TestCard.Properties.Resources;

namespace TestCard.Web.Models
{
    public class TestingCardChangeRequestModel
    {
        public int? TestingCardID { get; set; }
        public int? TestingCardChangeRequestID { get; set; }

        [Display(Name = "RequestReason", ResourceType = typeof(GeneralResource))]
        public int? ReasonID { get; set; }

        [Display(Name = "RequestReason", ResourceType = typeof(GeneralResource))]
        public string ReasonName { get; set; }

        [Display(Name = "RequestExplanation", ResourceType = typeof(GeneralResource))]
        public string ReasonDescription { get; set; }

        public string Number { get; set; }

         [StringLength(11,
            MinimumLength = 11,
            ErrorMessage = "",
            ErrorMessageResourceName = "IdNumberMaxLengthError",
            ErrorMessageResourceType = typeof(GeneralResource))]
        [Display(Name = "OwnerIDNo", ResourceType = typeof(GeneralResource))]
        public string OwnerIDNo { get; set; }

        public bool? IsValid { get; set; }

        [Display(Name = "FirnishNumber", ResourceType = typeof(GeneralResource))]
        public string FirnishNumber { get; set; }

        [Display(Name = "FirnishDate", ResourceType = typeof(GeneralResource))]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FirnishDate { get; set; }

        [Display(Name = "Note", ResourceType = typeof(GeneralResource))]
        public string Comment { get; set; }

        [Display(Name = "Odometer", ResourceType = typeof(GeneralResource))]
        public decimal? Odometer { get; set; }

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

        public List<TestingStep> TestingSteps { get; set; }

        public SelectList Reasons { get; set; }
    }
}