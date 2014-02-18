﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCard.Domain.Services;
using TestCard.Properties.Resources;
using TestCard.Web.Filters;
using TestCard.Web.Helpers;

namespace TestCard.Web.Controllers
{
    [AuthorizationFilter]
    public class UserController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        //public ActionResult Add()
        //{
        //    var model = new Models.CompanyModel();

        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult Add(Models.CompanyModel model, HttpPostedFileWrapper file)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            if (file != null && file.ContentType != MediaTypeNames.Image.Jpeg)
        //            {
        //                SetErrorMessage(GeneralResource.ImageAllowedMessage);
        //            }
        //            else
        //            {
        //                using (var service = new CompanyService())
        //                {
        //                    var company = AutoMapper.Mapper.Map<Models.CompanyModel, TestCard.Domain.Company>(model);

        //                    service.SaveCompany(company, CurrentUser.PersonID, GetFileData(file));
        //                }

        //                SetSuccessMessage();
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        SetErrorMessage();
        //    }

        //    return View(model);
        //}

        public ActionResult Edit(int id)
        {
            try
            {
                using (var service = new PersonService())
                {
                    var source = service.Get(id);

                    if (source != null)
                    {
                        var model = new Models.PersonModel();
                        model.UserInfo = AutoMapper.Mapper.Map(source, model.UserInfo);
                        model.Schedule = new Models.PersonScheduleModel();
                        model.Schedule.Days = AutoMapper.Mapper.Map<List<Models.PersonScheduleModel.Day>>(source.PersonSchedules.ToList());

                        ModelDataHelper.PopulateRegisterModel(model.UserInfo);
                        ModelDataHelper.PopulatePersonScheduleModel(model.Schedule);

                        return View(model);
                    }
                    else
                    {
                        SetErrorMessage(GeneralResource.RecordNotExists);
                    }
                }
            }
            catch
            {
                SetErrorMessage();
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Edit(int id, Models.PersonModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var service = new PersonChangeRequestService())
                    {
                        var per = AutoMapper.Mapper.Map<Domain.PersonChangeRequest>(model.UserInfo);

                        List<Domain.PersonScheduleChangeRequest> scheduleList = new List<Domain.PersonScheduleChangeRequest>();

                        scheduleList = AutoMapper.Mapper.Map<List<Domain.PersonScheduleChangeRequest>>(model.Schedule.Days);

                        service.SavePersonChangeRequest(per, scheduleList, CurrentUser.PersonID);
                    }

                    SetSuccessMessage();
                    return RedirectToAction("Edit", RouteData.Values);
                }
            }
            catch
            {
                SetErrorMessage();
            }

            ModelDataHelper.PopulateRegisterModel(model.UserInfo);
            ModelDataHelper.PopulatePersonScheduleModel(model.Schedule);

            return View(model);
        }
    }
}