using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SOFT549_ASD_MIS_WebApp.Models;

namespace SOFT549_ASD_MIS_WebApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly GilesContext _context;

        public TasksController(GilesContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            var gilesContext = _context.Assignment.Include(a => a.Activity).Include(a => a.Staff);
            return View(await gilesContext.ToListAsync());
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignment
                .Include(a => a.Activity)
                .Include(a => a.Staff)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            ViewData["ActivityId"] = new SelectList(_context.Activity, "ActivityId", "ActivityName");
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "Organisation");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskId,StaffId,TaskName,ActivityId,PredictedStartDate,ActualStartDate,PredictedCompletionDate,ActualCompletionDate,PredictedCost,ActualCost,TaskSequence")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivityId"] = new SelectList(_context.Activity, "ActivityId", "ActivityName", assignment.ActivityId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "Organisation", assignment.StaffId);
            return View(assignment);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignment.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            ViewData["ActivityId"] = new SelectList(_context.Activity, "ActivityId", "ActivityName", assignment.ActivityId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "Organisation", assignment.StaffId);
            return View(assignment);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("TaskId,StaffId,TaskName,ActivityId,PredictedStartDate,ActualStartDate,PredictedCompletionDate,ActualCompletionDate,PredictedCost,ActualCost,TaskSequence")] Assignment assignment)
        {
            if (id != assignment.TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignmentExists(assignment.TaskId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivityId"] = new SelectList(_context.Activity, "ActivityId", "ActivityName", assignment.ActivityId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "Organisation", assignment.StaffId);
            return View(assignment);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignment
                .Include(a => a.Activity)
                .Include(a => a.Staff)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var assignment = await _context.Assignment.FindAsync(id);
            _context.Assignment.Remove(assignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignmentExists(short id)
        {
            return _context.Assignment.Any(e => e.TaskId == id);
        }
    }
}
