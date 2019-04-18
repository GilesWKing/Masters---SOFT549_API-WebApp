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
    public class ClientsController : ControllerBase
    {
        private readonly GilesContext _context;

        public ClientsController(GilesContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public IEnumerable<Client> GetClient()
        {
            return _context.Client;
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = await _context.Client.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        //-----------------------------Custom API Get Requests-----------------------------//
        [HttpGet("{id}/name")]
        public async Task<IActionResult> GetClientsName([FromRoute] int id)
        {
            var client = await _context.Client.FindAsync(id);
            return Ok(client.GetClientsName());
        }

        [HttpGet("{id}/contact")]
        public async Task<IActionResult> GetClientsContact([FromRoute] int id)
        {
            var client = await _context.Client.FindAsync(id);
            return Ok(client.GetClientsContact());
        }
        //-----------------------------        Close         -----------------------------//


        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient([FromRoute] int id, [FromBody] Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.ClientId)
            {
                return BadRequest();
            }

            //-----------------------------Custom error array: Clients-----------------------------//
            List<string> errors = new List<string>();

            // If the Client ID does not match the value found in the API PUT Request then generate error message.
            if (id != client.ClientId)
                errors.Add("The 'clientID' does not match the request.");

            // If the number of errors is greater than 0 (i.e. 1 or above) then return the error to the array.
            if (errors.Count > 0)
                return BadRequest(_context.FormatBadRequest(errors));
            //-----------------------------           Close           -----------------------------//

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        [HttpPost]
        public async Task<IActionResult> PostClient([FromBody] Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Client.Add(client);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClientExists(client.ClientId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClient", new { id = client.ClientId }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Client.Remove(client);
            await _context.SaveChangesAsync();

            return Ok(client);
        }

        private bool ClientExists(int id)
        {
            return _context.Client.Any(e => e.ClientId == id);
        }
    }
}