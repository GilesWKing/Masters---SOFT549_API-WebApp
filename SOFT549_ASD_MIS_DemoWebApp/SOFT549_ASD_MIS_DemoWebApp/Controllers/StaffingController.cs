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
    public class StaffingController : Controller
    {
        private readonly GilesContext _context;

        public StaffingController(GilesContext context)
        {
            _context = context;
        }

        // GET: Staffing
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetApiCall<List<Staff>>("Staffing"));
        }
    

        // GET: Staffing/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var staff = await _context.GetApiCall<Staff>(string.Concat("Staffing", "/", id));
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }


        // GET: Staffing/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Staffing/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffId,RoleId,StaffName,ContactDetails,Organisation,ClientId")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                var result = await _context.PostApiCall<Staff>("Staffing", staff);

                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }


        // GET: Staffing/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.GetApiCall<Staff>(string.Concat("Staffing", "/", id));

            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }


        // POST: Staffing/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffId,RoleId,StaffName,ContactDetails,Organisation,ClientId")] Staff staff)
        {
            if (id != staff.StaffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _context.PutApiCall<Staff>(string.Concat("Staffing", "/", id), staff);
                return RedirectToAction(nameof(Index));
            }

            return View(staff);
        }


        // GET: Staffing/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.GetApiCall<Staff>(string.Concat("Staffing", "/", id));

            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staffing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var staffing = await _context.DeleteApiCall<Staff>(string.Concat("Staffing", "/", id));
            return RedirectToAction(nameof(Index));
        }

        private bool StaffExists(int id)
        {

            var task = _context.GetApiCall<Staff>(string.Concat("Staffing", "/", id)).Result;

            return (task.StaffId > 0);
        }
    }
}
