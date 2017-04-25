using BusinessLogic.Core;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace SitulClasei.Controllers
{
    public partial class GroupController : Controller
    {
        // GET: Group
        public virtual async Task<ActionResult> Index()
        {
            var groups = await GroupCore.GetAllAsync().ConfigureAwait(false);
            return View(groups);
        }

        // GET: Group/Details/5
        public virtual ActionResult Details(int id)
        {
            return View();
        }

        // GET: Group/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: Group/Create
        [HttpPost]
        public virtual async Task<ActionResult> Create(Group model)
        {
            try
            {
                // TODO: Add insert logic here
                await GroupCore.CreateAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Group/Edit/5
        public virtual async Task<ActionResult> Edit(Guid id)
        {
            var std = await GroupCore.GetAsync(id);
            return View(std);
        }

        // POST: Group/Edit/5
        [HttpPost]
        public virtual async Task<ActionResult> Edit(Guid id, Group model)
        {

            try
            {
                // TODO: Add update logic here
                await GroupCore.GetAsync(id);
                await GroupCore.UpdateAsync(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Group/Delete/5
        public virtual async Task<ActionResult> Delete(Guid id)
        {
            var std = await GroupCore.GetAsync(id);
            return View(std);
        }

        // POST: Group/Delete/5
        [HttpPost]
        public virtual async Task<ActionResult> Delete(Guid id, Group model)
        {
            try
            {
                // TODO: Add delete logic here
                await GroupCore.GetAsync(id);
                await GroupCore.DeleteAsync(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
