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

        /// <summary>
        /// In the GilesContext.cs, there are four separate methods to call the database.
        /// These are each Get, Post, Put and Delete.
        /// Within each controller, the API is called to retrieve and send the data from relevant models.
        /// The methods below concatenate a string to either Get or Post.
        /// Much of this code has been edited from the standard MVC Template code that is generated.
        /// </summary>

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetApiCall<List<Role>>("Roles"));
        }


        // GET: Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId,RoleName,CostPerHour")] Role role)
        {
            if (ModelState.IsValid)
            {
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
            
            var role = await _context.GetApiCall<Role>(string.Concat("Roles", "/", id));

            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }


        // POST: Roles/Edit/5

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
                var result = await _context.PutApiCall<Role>(string.Concat("Roles", "/", id), role);

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

            var role = await _context.DeleteApiCall<Role>(string.Concat("Roles", "/", id));
            return RedirectToAction(nameof(Index));
        }

        private bool RoleExists(int id)
        {

            var task = _context.GetApiCall<Role>(string.Concat("Roles", "/", id)).Result;

            return (task.RoleId > 0);
        }
    }
}
