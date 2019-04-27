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


        // GET: Clients
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Client.ToListAsync());         //Old method to call database functions

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

            //var client = await _context.Client.FirstOrDefaultAsync(m => m.ClientId == id);

            var client = await _context.GetApiCall<Client>(string.Concat("Clients", "/", id));      // Need validation around this string!
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,ClientName,ClientContact")] Client client)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(client);
                //await _context.SaveChangesAsync();

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

            //var client = await _context.Client.FindAsync(id);

            var client = await _context.GetApiCall<Client>(string.Concat("Clients", "/", id)); // Again, validation needed on this string!

            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }



        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                //try
                //{
                //    _context.Update(client);
                //    await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!ClientExists(client.ClientId))
                //   {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}

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

            //var client = await _context.Client.FirstOrDefaultAsync(m => m.ClientId == id);

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
            //var client = await _context.Client.FindAsync(id);
            //_context.Client.Remove(client);
            //await _context.SaveChangesAsync();

            var client = await _context.DeleteApiCall<Client>(string.Concat("Clients", "/", id));
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            //return _context.Client.Any(e => e.ClientId == id);

            var task = _context.GetApiCall<Client>(string.Concat("Clients", "/", id)).Result;

            return (task.ClientId > 0);
        }
    }
}
