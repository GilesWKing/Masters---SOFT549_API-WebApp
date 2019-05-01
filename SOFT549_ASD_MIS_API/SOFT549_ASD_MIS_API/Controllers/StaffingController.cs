using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SOFT549_ASD_MIS_API.Models;

namespace SOFT549_ASD_MIS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffingController : ControllerBase
    {
        private readonly GilesContext _context;

        public StaffingController(GilesContext context)
        {
            _context = context;
        }

        // GET: api/Staffing
        [HttpGet]
        public IEnumerable<Staff> GetStaff()
        {
            return _context.Staff;
        }

        // GET: api/Staffing/Dropdown           Selects List data
        [HttpGet("Dropdown")]
        public IEnumerable<SelectListItem> GetStaffDropdown()
        {
            var staffList = new List<SelectListItem>();

            //staffingTable is all rows of staff table
            var staffingTable = _context.Staff;
            //for each row in staffing Table
            foreach (var staffRow in staffingTable)
            {
                //take data from row in table and put in model
                var staffListItem = new SelectListItem();
                staffListItem.Value = staffRow.StaffId.ToString();
                staffListItem.Text = staffRow.StaffName;

                //put model into list
                staffList.Add(staffListItem);
            }

            //return the completed list.
            return staffList;
        }

        // GET: api/Staffing/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaff([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var staff = await _context.Staff.FindAsync(id);

            if (staff == null)
            {
                return NotFound();
            }

            return Ok(staff);
        }

        // PUT: api/Staffing/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff([FromRoute] int id, [FromBody] Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != staff.StaffId)
            {
                return BadRequest();
            }

            _context.Entry(staff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
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

        // POST: api/Staffing
        [HttpPost]
        public async Task<IActionResult> PostStaff([FromBody] Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Staff.Add(staff);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StaffExists(staff.StaffId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStaff", new { id = staff.StaffId }, staff);
        }

        // DELETE: api/Staffing/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();

            return Ok(staff);
        }

        private bool StaffExists(int id)
        {
            return _context.Staff.Any(e => e.StaffId == id);
        }
    }
}