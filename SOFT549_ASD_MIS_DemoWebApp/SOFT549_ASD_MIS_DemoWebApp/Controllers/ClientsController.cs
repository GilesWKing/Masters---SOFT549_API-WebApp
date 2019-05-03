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
    public class ClientsController : Controller
    {
        private readonly GilesContext _context;

        public ClientsController(GilesContext context)
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

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetApiCall<List<Client>>("Clients"));
            /// <summary>
            /// Adds the word "Clients" on to the end of the string that will call the API.
            /// </summary>
        }


        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.GetApiCall<Client>(string.Concat("Clients", "/", id));      // Need validation here.
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }


        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Clients/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,ClientName,ClientContact")] Client client)
        {
            if (ModelState.IsValid)
            {
                var result = await _context.PostApiCall<Client>("Clients", client);

                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }


        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.GetApiCall<Client>(string.Concat("Clients", "/", id)); // Again, validation needed on this string!

            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }



        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,ClientName,ClientContact")] Client client)
        {
            if (id != client.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                var result = await _context.PutApiCall<Client>(string.Concat("Clients", "/", id), client);
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }


        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var client = await _context.GetApiCall<Client>(string.Concat("Clients", "/", id));

            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }


        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.DeleteApiCall<Client>(string.Concat("Clients", "/", id));
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            var task = _context.GetApiCall<Client>(string.Concat("Clients", "/", id)).Result;

            return (task.ClientId > 0);
        }
    }
}
