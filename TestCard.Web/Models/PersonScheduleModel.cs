using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestCard.Web.Models
{
    public class PersonScheduleModel
    {
        public int PersonID { get; set; }
        public int? PersonScheduleChangeRequestID { get; set; }
        public List<Day> Days { get; set; }

        public class Day
        {
            public int WeekDayNumber { get; set; }
            public string WeekDayName { get; set; }
            [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
            public TimeSpan? StartTime { get; set; }
            [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
            public TimeSpan? EndTime { get; set; }
            [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
            public TimeSpan? BreakStartTime { get; set; }
            [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
            public TimeSpan? BreakEndTime { get; set; }
        }

        public IEnumerable<SelectListItem> WorkHours { get; set; }
        public IEnumerable<SelectListItem> BreakHours { get; set; }
    }
}