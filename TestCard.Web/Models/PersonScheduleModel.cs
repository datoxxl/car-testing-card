using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestCard.Web.Models
{
    public class PersonScheduleModel
    {
        public List<Day> Days { get; set; }

        public class Day
        {
            public DayOfWeek WeekDay { get; set; }
            public TimeSpan? WorkStartTime { get; set; }
            public TimeSpan? WorkEndTime { get; set; }
            public TimeSpan? BreakStartTime { get; set; }
            public TimeSpan? BreakEndTime { get; set; }
        }

        public IEnumerable<SelectListItem> WorkHours { get; set; }
        public IEnumerable<SelectListItem> BreakHours { get; set; }
    }
}