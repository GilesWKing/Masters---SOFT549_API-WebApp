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
    public class TasksController : Controller
    {
        private readonly GilesContext _context;

        public TasksController(GilesContext context)
        {
            _context = context;
        }

        /// <summary>
        /// In the GilesContext.cs, there are four separate methods to call the database.
        /// These are each Get, Post, Put and Delete.
        /// Within each controller, the API is called to retrieve and send the data from relevant models.
        /// The methods below concatenate a string to either Get or Post.
        /// Much of this code has been edited from the standard MVC Template code that is generated.
        /// </summary>

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetApiCall<List<Assignment>>("Tasks"));
        }


        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.GetApiCall<Assignment>(string.Concat("Tasks", "/", id));
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }


        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Tasks/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskId,StaffId,TaskName,ActivityId,PredictedStartDate,ActualStartDate,PredictedCompletionDate,ActualCompletionDate,PredictedCost,ActualCost,TaskSequence")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                var result = await _context.PostApiCall<Assignment>("Tasks", assignment);

                return RedirectToAction(nameof(Index));
            }
            return View(assignment);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var assignment = await _context.GetApiCall<Assignment>(string.Concat("Tasks", "/", id));

            if (assignment == null)
            {
                return NotFound();
            }
            return View(assignment);
        }

        // POST: Tasks/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,StaffId,TaskName,ActivityId,PredictedStartDate,ActualStartDate,PredictedCompletionDate,ActualCompletionDate,PredictedCost,ActualCost,TaskSequence")] Assignment assignment)
        {
            if (id != assignment.TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _context.PutApiCall<Assignment>(string.Concat("Tasks", "/", id), assignment);
                return RedirectToAction(nameof(Index));
            }

            return View(assignment);
        }


        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.GetApiCall<Assignment>(string.Concat("Tasks", "/", id));

            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var client = await _context.DeleteApiCall<Assignment>(string.Concat("Tasks", "/", id));
            return RedirectToAction(nameof(Index));
        }

        private bool AssignmentExists(int id)
        {
            var task = _context.GetApiCall<Assignment>(string.Concat("Tasks", "/", id)).Result;

            return (task.TaskId > 0);
        }
    }
}
