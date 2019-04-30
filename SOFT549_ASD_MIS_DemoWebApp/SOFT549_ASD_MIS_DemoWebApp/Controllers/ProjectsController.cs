using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SOFT549_ASD_MIS_DemoWebApp.Models;

namespace SOFT549_ASD_MIS_DemoWebApp.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly GilesContext _context;

        public ProjectsController(GilesContext context)
        {
            _context = context;
        }


        // GET: Projects
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetApiCall<List<Project>>("Projects"));
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.GetApiCall<Project>(string.Concat("Projects", "/", id));
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,ClientId,ProjectName,PredictedLaunchDate,ActualLaunchDate,PredictedCompletionDate,ActualCompletionDate,PredictedCost,ActualCost,Price")] Project project)
        {
            if (ModelState.IsValid)
            {
                var result = await _context.PostApiCall<Project>("Projects", project);
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.GetApiCall<Project>(string.Concat("Projects", "/", id));

            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,ProjectName,PredictedLaunchDate,ActualLaunchDate,PredictedCompletionDate,ActualCompletionDate,PredictedCost,ActualCost,Price")] Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _context.PutApiCall<Project>(string.Concat("Projects", "/", id), project);
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.GetApiCall<Project>(string.Concat("Projects", "/", id));

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var project = await _context.DeleteApiCall<Project>(String.Concat("Projects", "/", id));
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            var task = _context.GetApiCall<Project>(string.Concat("Projects", "/", id)).Result;

            return (task.ProjectId > 0);
        }
    }
}
