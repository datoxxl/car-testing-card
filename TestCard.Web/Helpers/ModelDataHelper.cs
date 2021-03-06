﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCard.Domain;
using TestCard.Domain.Services;

namespace TestCard.Web.Helpers
{
    public static class ModelDataHelper
    {
        private static List<SelectListItem> GetWorkHours()
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

        private static List<SelectListItem> GetBreakHours()
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

        private static List<Models.PersonScheduleModel.Day> Populate(List<Models.PersonScheduleModel.Day> days)
        {
            if (days == null)
            {
                days = new List<Models.PersonScheduleModel.Day>();
            }

            for (int i = 1; i <= 7; i++)
            {
                var dayOfWeek = (DayOfWeek)(i == 7 ? 0 : i);
                var weekDayName = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(dayOfWeek);

                var day = days.FirstOrDefault(x => x.WeekDayNumber == i);

                if (day == null)
                {
                    day = new Models.PersonScheduleModel.Day
                    {
                        WeekDayNumber = i
                    };

                    days.Add(day);
                }

                day.WeekDayName = weekDayName;
            }

            return days;
        }

        public static void Populate(Models.PersonScheduleModel model)
        {
            model.Days = Populate(model.Days);
            model.BreakHours = GetBreakHours();
            model.WorkHours = GetWorkHours();
        }

        public static void Populate(Models.RegisterModel model)
        {
            using (var service = new AccountTypeService())
            {
                model.AccountTypeSelectList = new SelectList(service.GetAll().ToList(), "AccountTypeID", "AccountTypeName");
            }

            using (var service = new CompanyService())
            {
                model.CompanySelectList = new SelectList(service.GetAll().ToList(), "CompanyID", "CompanyName");
            }
        }

        public static void Populate(Models.PersonModel model)
        {
            using (var service = new AccountTypeService())
            {
                model.AccountTypeSelectList = new SelectList(service.GetAll().ToList(), "AccountTypeID", "AccountTypeName");
            }

            using (var service = new CompanyService())
            {
                model.CompanySelectList = new SelectList(service.GetAll().ToList(), "CompanyID", "CompanyName");
            }
        }

        public static void Populate(Models.TestingCardChangeRequestModel model)
        {
            using (var service = new ChangeRequestReasonService())
            {
                model.Reasons = new SelectList(service.GetAll().ToList(), "ChangeRequestReasonID", "Title");
            }
        }

        private static List<Models.TestingStep> Populate(List<Models.TestingStep> model)
        {
            using (var service = new TestingStepService())
            {
                var steps = service.GetAll(true);

                if (model == null)
                {
                    AutoMapper.Mapper.Map(steps, model);
                }
                else
                {
                    foreach (var step in steps)
                    {
                        var destStep = model.FirstOrDefault(x => x.TestingStepID == step.TestingStepID);

                        AutoMapper.Mapper.Map(step, destStep);

                        foreach (var subStep in step.TestingSubSteps)
                        {
                            AutoMapper.Mapper.Map(step, destStep.TestingSubSteps.FirstOrDefault(x => x.TestingSubStepID == subStep.TestingSubStepID));
                        }
                    }
                }

                return model;
            }
        }
    }
}