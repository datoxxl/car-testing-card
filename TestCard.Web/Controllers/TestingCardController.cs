using System;
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
    public class TestingCardController : BaseController
    {
        public ActionResult List()
        {
            return View();
        }

        public ActionResult View(int id)
        {
            return GetModel(id);
        }

        public ActionResult Add()
        {
            var model = new Models.TestingCardModel();
            ModelDataHelper.Populate(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Models.TestingCardModel model, HttpPostedFileWrapper file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var service = new TestingCardService())
                    {
                        var testingCard = AutoMapper.Mapper.Map<Models.TestingCardModel, TestCard.Domain.TestingCard>(model);

                        //service.SaveCompany(company, CurrentUser.PersonID, GetFileData(file));

                        SetSuccessMessage();

                        return RedirectToAction("Edit", new { @id = testingCard.TestingCardID });
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
        public ActionResult Edit(int id, Models.TestingCardModel model, HttpPostedFileWrapper file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var service = new TestingCardService())
                    {
                        var company = service.Get(id);

                        company = AutoMapper.Mapper.Map(model, company);

                        //service.SaveCompany(company, CurrentUser.PersonID, GetFileData(file));
                    }

                    SetSuccessMessage();
                    return RedirectToAction("Edit", RouteData.Values);
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
                using (var service = new TestingCardService())
                {
                    var source = service.Get(id);

                    if (source != null)
                    {
                        var model = AutoMapper.Mapper.Map<Models.TestingCardModel>(source);
                        ModelDataHelper.Populate(model);

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
