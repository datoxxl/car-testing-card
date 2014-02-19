﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCard.Web.Filters;
using TestCard.Web;
using TestCard.Properties.Resources;
using TestCard.Domain.Services;
using System.Net.Mime;

namespace TestCard.Web.Controllers
{
    [AuthorizationFilter]
    public class CompanyController : BaseController
    {
        public ActionResult View(int id)
        {
            return GetModel(id);
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Add()
        {
            var model = new Models.CompanyModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Models.CompanyModel model, HttpPostedFileWrapper file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (file != null && file.ContentType != MediaTypeNames.Image.Jpeg)
                    {
                        SetErrorMessage(GeneralResource.ImageAllowedMessage);
                    }
                    else
                    {
                        using (var service = new CompanyService())
                        {
                            var company = AutoMapper.Mapper.Map<Models.CompanyModel, TestCard.Domain.Company>(model);

                            service.SaveCompany(company, CurrentUser.PersonID, GetFileData(file));

                            SetSuccessMessage();

                            return RedirectToAction("Edit", new { @id = company.CompanyID });
                        }
                    }
                }
            }
            catch
            {
                SetErrorMessage();
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            return GetModel(id);
        }

        [HttpPost]
        public ActionResult Edit(int id, Models.CompanyModel model, HttpPostedFileWrapper file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (file != null && file.ContentType != MediaTypeNames.Image.Jpeg)
                    {
                        SetErrorMessage(GeneralResource.ImageAllowedMessage);
                    }
                    else
                    {
                        using (var service = new CompanyService())
                        {
                            var company = service.Get(id);

                            company = AutoMapper.Mapper.Map(model, company);

                            service.SaveCompany(company, CurrentUser.PersonID, GetFileData(file));
                        }

                        SetSuccessMessage();
                        return RedirectToAction("Edit", RouteData.Values);
                    }
                }
            }
            catch
            {
                SetErrorMessage();
            }


            return View(model);
        }

        private ActionResult GetModel(int id)
        {
            try
            {
                using (var service = new CompanyService())
                {
                    var source = service.Get(id);

                    if (source != null)
                    {
                        var model = AutoMapper.Mapper.Map<Models.CompanyModel>(source);

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
    }
}
