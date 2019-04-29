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
            //var gilesContext = _context.Staff.Include(s => s.Client).Include(s => s.Role);
            //return View(await gilesContext.ToListAsync());

            return View(await _context.GetApiCall<List<Staff>>("Staffing"));
        }
    

        // GET: Staffing/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var staff = await _context.Staff
            //    .Include(s => s.Client)
            //    .Include(s => s.Role)
            //    .FirstOrDefaultAsync(m => m.StaffId == id);

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
            //ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "ClientContact");
            //ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleName");
            return View();
        }


        // POST: Staffing/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffId,RoleId,StaffName,ContactDetails,Organisation,ClientId")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(staff);
                //await _context.SaveChangesAsync();

                var result = await _context.PostApiCall<Staff>("Staffing", staff);

                return RedirectToAction(nameof(Index));
            }
            //ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "ClientContact", staff.ClientId);
            //ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleName", staff.RoleId);
            return View(staff);
        }


        // GET: Staffing/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var staff = await _context.Staff.FindAsync(id);

            var staff = await _context.GetApiCall<Staff>(string.Concat("Staffing", "/", id));

            if (staff == null)
            {
                return NotFound();
            }
            //ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "ClientContact", staff.ClientId);
            //ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleName", staff.RoleId);
            return View(staff);
        }


        // POST: Staffing/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                //try
                //{
                //    _context.Update(staff);
                //    await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!StaffExists(staff.StaffId))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}

                return RedirectToAction(nameof(Index));
            }
            //ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "ClientContact", staff.ClientId);
            //ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleName", staff.RoleId);
            return View(staff);
        }


        // GET: Staffing/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var staff = await _context.Staff
            //    .Include(s => s.Client)
            //    .Include(s => s.Role)
            //    .FirstOrDefaultAsync(m => m.StaffId == id);

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
            //var staff = await _context.Staff.FindAsync(id);
            //_context.Staff.Remove(staff);
            //await _context.SaveChangesAsync();

            var staffing = await _context.DeleteApiCall<Staff>(string.Concat("Staffing", "/", id));
            return RedirectToAction(nameof(Index));
        }

        private bool StaffExists(int id)
        {
            //return _context.Staff.Any(e => e.StaffId == id);

            var task = _context.GetApiCall<Staff>(string.Concat("Staffing", "/", id)).Result;

            return (task.StaffId > 0);
        }
    }
}
