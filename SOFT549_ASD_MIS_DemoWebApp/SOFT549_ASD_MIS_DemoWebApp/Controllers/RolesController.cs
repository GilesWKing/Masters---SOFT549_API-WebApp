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
    public class RolesController : Controller
    {
        private readonly GilesContext _context;

        public RolesController(GilesContext context)
        {
            _context = context;
        }


        // GET: Roles
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Role.ToListAsync());

            return View(await _context.GetApiCall<List<Role>>("Roles"));
        }


        // GET: Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var role = await _context.Role
            //    .FirstOrDefaultAsync(m => m.RoleId == id);

            var role = await _context.GetApiCall<Role>(string.Concat("Roles", "/", id));
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }


        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId,RoleName,CostPerHour")] Role role)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(role);
                //await _context.SaveChangesAsync();

                var result = await _context.PostApiCall<Role>("Roles", role);

                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }


        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var role = await _context.Role.FindAsync(id);

            var role = await _context.GetApiCall<Role>(string.Concat("Roles", "/", id));

            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }


        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoleId,RoleName,CostPerHour")] Role role)
        {
            if (id != role.RoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //try
                //{
                //    _context.Update(role);
                //    await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!RoleExists(role.RoleId))
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
            return View(role);
        }


        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var role = await _context.Role
            //    .FirstOrDefaultAsync(m => m.RoleId == id);

            var role = await _context.GetApiCall<Role>(string.Concat("Roles", "/", id));

            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }


        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var role = await _context.Role.FindAsync(id);
            //_context.Role.Remove(role);
            //await _context.SaveChangesAsync();

            var role = await _context.DeleteApiCall<Role>(string.Concat("Roles", "/", id));
            return RedirectToAction(nameof(Index));
        }

        private bool RoleExists(int id)
        {
            //return _context.Role.Any(e => e.RoleId == id);

            var task = _context.GetApiCall<Role>(string.Concat("Roles", "/", id)).Result;

            return (task.RoleId > 0);
        }
    }
}
