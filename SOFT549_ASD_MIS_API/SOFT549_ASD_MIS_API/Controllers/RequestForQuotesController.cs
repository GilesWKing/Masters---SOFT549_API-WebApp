using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOFT549_ASD_MIS_API.Models;

namespace SOFT549_ASD_MIS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestForQuotesController : ControllerBase
    {
        private readonly GilesContext _context;

        public RequestForQuotesController(GilesContext context)
        {
            _context = context;
        }

        // GET: api/RequestForQuotes
        [HttpGet]
        public IEnumerable<RequestForQuote> GetRequestForQuote()
        {
            return _context.RequestForQuote;
        }

        // GET: api/RequestForQuotes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequestForQuote([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var requestforquote = await _context.RequestForQuote.FindAsync(id);

            if (requestforquote == null)
            {
                return NotFound();
            }

            return Ok(requestforquote);
        }

        // PUT: api/RequestForQuotes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestForQuote([FromRoute] int id, [FromBody] RequestForQuote requestforquote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != requestforquote.QuoteId)
            {
                return BadRequest();
            }

            _context.Entry(requestforquote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestForQuoteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RequestForQuote
        [HttpPost]
        public async Task<IActionResult> PostRequestForQuote([FromBody] RequestForQuote requestforquote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RequestForQuote.Add(requestforquote);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RequestForQuoteExists(requestforquote.QuoteId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRequestForQuote", new { id = requestforquote.QuoteId }, requestforquote);
        }

        // DELETE: api/RequestForQuotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestForQuote([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var requestforquote = await _context.RequestForQuote.FindAsync(id);
            if (requestforquote == null)
            {
                return NotFound();
            }

            _context.RequestForQuote.Remove(requestforquote);
            await _context.SaveChangesAsync();

            return Ok(requestforquote);
        }

        private bool RequestForQuoteExists(int id)
        {
            return _context.RequestForQuote.Any(e => e.QuoteId == id);
        }
    }
}