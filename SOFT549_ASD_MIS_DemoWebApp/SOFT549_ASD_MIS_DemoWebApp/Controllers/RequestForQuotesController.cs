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
    public class RequestForQuotesController : Controller
    {
        private readonly GilesContext _context;

        public RequestForQuotesController(GilesContext context)
        {
            _context = context;
        }

        // Retrieves all records in the RequestForQuote table and generates a table of data on RequestForQuotes Index View.
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetApiCall<List<RequestForQuote>>("RequestForQuotes"));
        }


        // Retrieves a specific RequestForQuote through use of the id. Displays that data on an individual view.
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestforquote = await _context.GetApiCall<RequestForQuote>(string.Concat("RequestForQuotes", "/", id));
            if (requestforquote == null)
            {
                return NotFound();
            }

            return View(requestforquote);
        }


        // GET: RequestForQuotes/Create
        public IActionResult Create()
        {
            return View();
        }


        // My post method sending data to a model and onto the Post API Call method that will send data to the database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuoteId,ClientName,ClientPhone,ClientEmail,ClientRep,ClientRepContact,ProjectName,ProjectManager,PredStartDate,PredCompletionDate,ProjectDescription")] RequestForQuote requestforquote)
        {
            if (ModelState.IsValid)
            {
                var result = await _context.PostApiCall<RequestForQuote>("RequestForQuotes", requestforquote);

                return RedirectToAction(nameof(Index));
            }
            return View(requestforquote);
        }


        // GET: RequestForQuotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestforquote = await _context.GetApiCall<RequestForQuote>(string.Concat("RequestForQuotes", "/", id));

            if (requestforquote == null)
            {
                return NotFound();
            }

            return View(requestforquote);
        }


        // POST: RequestForQuotes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuoteId, ClientName, ClientPhone, ClientEmail, ClientRep, ClientRepContact, ProjectName, ProjectManager, PredStartDate, PredCompletionDate, ProjectDescription")] RequestForQuote requestforquote)
        {
            if (id != requestforquote.QuoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                var result = await _context.PutApiCall<RequestForQuote>(string.Concat("RequestForQuotes", "/", id), requestforquote);

                return RedirectToAction(nameof(Index));
            }

            return View(requestforquote);
        }


        // GET: RequestForQuotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestforquote = await _context.GetApiCall<RequestForQuote>(string.Concat("RequestForQuotes", "/", id));

            if (requestforquote == null)
            {
                return NotFound();
            }

            return View(requestforquote);
        }


        // POST: RequestForQuotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requestforquote = await _context.DeleteApiCall<RequestForQuote>(string.Concat("RequestForQuotes", "/", id));
            return RedirectToAction(nameof(Index));
        }

        private bool RequestForQuoteExists(int id)
        {
            var task = _context.GetApiCall<RequestForQuote>(string.Concat("RequestForQuotes", "/", id)).Result;

            return (task.QuoteId > 0);
        }
    }
}
