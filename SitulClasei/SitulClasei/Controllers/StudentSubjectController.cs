using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Models;
using SitulClasei.Common.Response;
using BusinessLogic.Core;
using LoggingService;

namespace SitulClasei.Controllers
{
    public partial class StudentSubjectController : Controller
    {


        public virtual ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        [ActionName("Add")]
        public virtual async Task<ActionResult> Add(StudentSubjectAssigmentsModel model)
        {
            TempData["notice"] = "Error";
            TempData["notice"] = "Success";
            if (!ModelState.IsValid)
            {
                return RedirectToAction("BadRequest");
            }

            try
            {
                var group = await StudentSubjectCore.AddAsync(model.SubjectID, model.StudentID).ConfigureAwait(false);
                if (group == null)
                {
                    return RedirectToAction("BadRequest");
                }

                return RedirectToAction("Success");
            }
            catch (Exception ex)
            {
                LogHelper.LogException<StudentSubjectController>(ex);
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


        [HttpGet]
        [ActionName("GetStudentSubject")]
        public virtual async Task<ActionResult> GetStudetSubjects(Guid subjectId)
        {
            try
            {
                var std = await StudentSubjectCore.GetAsync(subjectId).ConfigureAwait(false);
                if (std == null)
                {
                    return BadRequest();
                }

                return Success();
            }
            catch (Exception ex)
            {
                LogHelper.LogException<StudentSubjectController>(ex);
                return BadRequest();
            }
        }


    }
}