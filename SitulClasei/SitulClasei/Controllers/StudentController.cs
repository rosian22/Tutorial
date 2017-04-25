using BusinessLogic.Core;
using BusinessLogic.Model;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SitulClasei.Controllers
{
    public partial class StudentController : Controller
    {
        // GET: Student
        public virtual async Task<ActionResult> Index()
        {
            ViewBag.Subjects = await SubjectCore.GetAllAsync().ConfigureAwait(false);
            ViewBag.Student = await StudentCore.GetAllAsync().ConfigureAwait(false);

            var students = await StudentCore.GetAllAsync(new[] {
                nameof(Student.Subjects) }).ConfigureAwait(false);
            return View(students);
        }

        public virtual async Task<ActionResult> Filter(Guid? SubjectId)
        {

            ViewBag.Subject = await SubjectCore.GetAllAsync().ConfigureAwait(false);
            ViewBag.AllStudents = await StudentCore.GetAllAsync().ConfigureAwait(false);

            var model = await SubjectCore.GetFiltered(navigationProperties: new[] {
                nameof(Subject.Students)
            }).ConfigureAwait(false);
            if (model == null)
            {
                return View();
            }
            if (SubjectId != null && SubjectId != Guid.Empty)
            {
                ViewBag.ShiftIdToOpenInDialog = SubjectId.Value;
            }

            ViewBag.SubjectList = model.EntityContainers.First().Data;
            ViewBag.TotalShiftsCount = model.TotalItems;
            return View(model);
        }

        [HttpGet]
        public virtual async Task<ActionResult> GetStudentsBySubjectId(Guid subjectId)
        {
            var currentSubject = await SubjectCore.GetAsync(subjectId, new[] {
                                    nameof(Subject.Students)
                                }).ConfigureAwait(false);

            var studentsForCurrentSubject = currentSubject.Students.ToList();
           

        ViewBag.AllStudents = studentsForCurrentSubject;

            return View("_studentList", studentsForCurrentSubject);
        }

        // GET: Student/Details/5
        public virtual ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public virtual ActionResult Create()
        {
            return View("Create");
        }

        // POST: Student/Create
        [HttpPost]
        public virtual async Task<ActionResult> Create(Student model)
        {
            try
            {
                await StudentCore.CreateAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public virtual async Task<ActionResult> Edit(Guid id)
        {
            var std = await StudentCore.GetAsync(id);
            return View(std);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public virtual async Task<ActionResult> Edit(Guid id, Student model)
        {

            await StudentCore.UpdateAsync(model);
            await StudentCore.GetAsync(id);
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public virtual async Task<ActionResult> Delete(Guid id)
        {
            var std = await StudentCore.GetAsync(id);
            return View(id);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public virtual async Task<ActionResult> Delete(Guid id, Student model)
        {
            try
            {
                // TODO: Add delete logic here
                await StudentCore.GetAsync(id);
                await StudentCore.DeleteAsync(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
