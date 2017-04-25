using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Models;
using SitulClasei.Common.Response;
using BusinessLogic.Core;
using LoggingService;

namespace SitulClasei.Controllers
{
    public partial class StudentGroupController : Controller
    {


        public virtual ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        [ActionName("Add")]
        public virtual async Task<ActionResult> Add(StudentGroupAssigmentsModel model)
        {
            TempData["notice"] = "Error";
            TempData["notice"] = "Success";
            if (!ModelState.IsValid)
            {
                return RedirectToAction("BadRequest");
            }

            try
            {
                var group = await StudentGroupCore.AddAsync(model.GroupId, model.StudentId).ConfigureAwait(false);
                if (group == null)
                {
                    return RedirectToAction("BadRequest");
                }

                return RedirectToAction("Success");
            }
            catch (Exception ex)
            {
                LogHelper.LogException<StudentGroupController>(ex);
                return RedirectToAction("BadRequest");
            }
        }



        public virtual ActionResult BadRequest()
        {
            return View();
        }


        public virtual ActionResult Success()
        {
            return View();
        }

        public virtual async Task<ActionResult> Display(Guid Id)
        {
            var stdgrp = await StudentGroupCore.GetAsync(Id);
            return View(stdgrp);
        }


        [HttpGet]
        [ActionName("GetStudentGroup")]
        public virtual async Task<ActionResult> GetStudetGroups(Guid groupId)
        {
            try
            {
                var std = await StudentGroupCore.GetAsync(groupId).ConfigureAwait(false);
                if (std == null)
                {
                    return BadRequest();
                }

                return Success();
            }
            catch (Exception ex)
            {
                LogHelper.LogException<StudentGroupController>(ex);
                return BadRequest();
            }
        }


    }
}