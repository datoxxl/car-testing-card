﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestCard.Web.Models
{
    public class PersonScheduleModel
    {
        public int personID { get; set; }
        public List<Day> Days { get; set; }

        public class Day
        {
            public int WeekDayNumber { get; set; }
            public string WeekDayName { get; set; }
            public TimeSpan? StartTime { get; set; }
            public TimeSpan? EndTime { get; set; }
            public TimeSpan? BreakStartTime { get; set; }
            public TimeSpan? BreakEndTime { get; set; }
        }

        public IEnumerable<SelectListItem> WorkHours { get; set; }
        public IEnumerable<SelectListItem> BreakHours { get; set; }
    }
}