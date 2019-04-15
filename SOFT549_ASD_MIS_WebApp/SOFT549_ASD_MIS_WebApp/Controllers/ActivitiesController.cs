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
    public class ActivitiesController : Controller
    {
        private readonly GilesContext _context;

        public ActivitiesController(GilesContext context)
        {
            _context = context;
        }

        // GET: Activities
        public async Task<IActionResult> Index()
        {
            var gilesContext = _context.Activity.Include(a => a.Project).Include(a => a.Staff);
            return View(await gilesContext.ToListAsync());
        }

        // GET: Activities/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activity
                .Include(a => a.Project)
                .Include(a => a.Staff)
                .FirstOrDefaultAsync(m => m.ActivityId == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // GET: Activities/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "PredictedCost");
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "Organisation");
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActivityId,ProjectId,ActivityName,StaffId,PredictedStartDate,ActualStartDate,PredictedCompletionDate,ActualCompletionDate,PredictedCost,ActualCost,ActivitySequence")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "PredictedCost", activity.ProjectId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "Organisation", activity.StaffId);
            return View(activity);
        }

        // GET: Activities/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activity.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "PredictedCost", activity.ProjectId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "Organisation", activity.StaffId);
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("ActivityId,ProjectId,ActivityName,StaffId,PredictedStartDate,ActualStartDate,PredictedCompletionDate,ActualCompletionDate,PredictedCost,ActualCost,ActivitySequence")] Activity activity)
        {
            if (id != activity.ActivityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityExists(activity.ActivityId))
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
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "PredictedCost", activity.ProjectId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "Organisation", activity.StaffId);
            return View(activity);
        }

        // GET: Activities/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activity
                .Include(a => a.Project)
                .Include(a => a.Staff)
                .FirstOrDefaultAsync(m => m.ActivityId == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var activity = await _context.Activity.FindAsync(id);
            _context.Activity.Remove(activity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityExists(short id)
        {
            return _context.Activity.Any(e => e.ActivityId == id);
        }
    }
}
