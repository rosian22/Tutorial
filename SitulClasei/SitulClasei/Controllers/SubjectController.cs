using BusinessLogic.Core;
using Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SitulClasei.Controllers
{
    public partial class SubjectController : Controller
    {
        // GET: Subject
        public virtual async Task<ActionResult> Index()
        {
            var subjects = await SubjectCore.GetAllAsync().ConfigureAwait(false);
            return View(subjects);
        }

        // GET: Subject/Details/5
        public virtual ActionResult Details(int id)
        {
            return View();
        }

        // GET: Subject/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: Subject/Create
        [HttpPost]
        public virtual async Task<ActionResult> Create(Subject model)
        {
            try
            {
                await SubjectCore.CreateAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Subject/Edit/5
        public virtual async Task<ActionResult> Edit(Guid Id)
        {
            var std = await SubjectCore.GetAsync(Id);
            return View(std);
        }

        // POST: Subject/Edit/5
        [HttpPost]
        public virtual async Task<ActionResult> Edit(Guid Id, Subject model)
        {
            try
            {
                await SubjectCore.UpdateAsync(model);
                await SubjectCore.GetAsync(Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Subject/Delete/5
        public virtual async Task<ActionResult> Delete(Guid Id)
        {
            var std = await SubjectCore.GetAsync(Id);
            return View(std);
        }

        // POST: Subject/Delete/5
        [HttpPost]
        public virtual async Task<ActionResult> Delete(Guid Id, Subject model)
        {
            try
            {
                await SubjectCore.GetAsync(Id);
                await SubjectCore.DeleteAsync(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
