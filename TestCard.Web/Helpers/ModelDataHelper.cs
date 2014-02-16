using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCard.Domain.Services;
using TestCard.Web.Models;

namespace TestCard.Web.Helpers
{
    public static class ModelDataHelper
    {
        public static List<SelectListItem> GetWorkHours()
        {
            var list = new List<SelectListItem>();

            var today = DateTime.Today;

            var time = new TimeSpan(7, 0, 0);

            for (var i = 0; i <= 15; i++)
            {
                var item = time.Add(new TimeSpan(i, 0, 0));
                list.Add(new SelectListItem()
                {
                    Text = item.ToString("hh\\:mm"),
                    Value = item.ToString()
                });
            }

            return list;
        }

        public static List<SelectListItem> GetBreakHours()
        {
            var list = new List<SelectListItem>();

            var time = new TimeSpan(12, 0, 0);

            for (var i = 0; i <= 12; i++)
            {
                var item = time.Add(new TimeSpan(0, i * 15, 0));
                list.Add(new SelectListItem
                {
                    Text = item.ToString("hh\\:mm"),
                    Value = item.ToString()
                });
            }

            return list;
        }

        public static List<TestCard.Web.Models.PersonScheduleModel.Day> GetScheduleDays()
        {
            var days = new List<TestCard.Web.Models.PersonScheduleModel.Day>();

            foreach (var item in Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>())
            {
                days.Add(new TestCard.Web.Models.PersonScheduleModel.Day { WeekDay = item });
            }

            return days;
        }

        public static void PopulateRegisterModel(RegisterModel model)
        {
            using (var service = new AccountTypeService())
            {
                model.AccountTypes = new SelectList(service.GetAll().ToList(), "AccountTypeID", "AccountTypeName");
            }
        }
    }
}