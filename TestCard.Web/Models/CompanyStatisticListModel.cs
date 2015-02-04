using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestCard.Properties.Resources;

namespace TestCard.Web.Models
{
    public class CompanyStatisticListModel
    {
        public int CompanyID { get; set; }

        [Display(Name = "Company", ResourceType = typeof(GeneralResource))]
        public string CompanyName { get; set; }

        [Display(Name = "ScheduleChangeRequestCount", ResourceType = typeof(GeneralResource))]
        public Nullable<int> ScheduleChangeRequestCnt { get; set; }

        [Display(Name = "FilledCardCount", ResourceType = typeof(GeneralResource))]
        public Nullable<int> FilledCardCnt { get; set; }

        [Display(Name = "CardChangeRequestCount", ResourceType = typeof(GeneralResource))]
        public Nullable<int> TestingCardChangeRequestCnt { get; set; }

        [Display(Name = "CardDailyAverage", ResourceType = typeof(GeneralResource))]
        public Nullable<int> TestingCardDailyAvg { get; set; }

        [Display(Name = "OnlineTime", ResourceType = typeof(GeneralResource))]
        public Nullable<int> UserOnlineTime { get; set; }

        [Display(Name = "Valid", ResourceType = typeof(GeneralResource))]
        public Nullable<int> ValidCardCnt { get; set; }

        [Display(Name = "Invalid", ResourceType = typeof(GeneralResource))]
        public Nullable<int> InvalidCardCnt { get; set; }

        [Display(Name = "Primary", ResourceType = typeof(GeneralResource))]
        public Nullable<int> FirstTestingCnt { get; set; }

        [Display(Name = "Secondary", ResourceType = typeof(GeneralResource))]
        public Nullable<int> SecondaryTestingCnt { get; set; }
    }
}