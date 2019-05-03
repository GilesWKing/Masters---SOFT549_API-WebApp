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
    public class ActivitiesController : ControllerBase
    {
        private readonly GilesContext _context;

        public ActivitiesController(GilesContext context)
        {
            _context = context;
        }

        // GET: api/Activities
        [HttpGet]
        public IEnumerable<Activity> GetActivity()
        {
            return _context.Activity;
        }

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivity([FromRoute] int id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var activity = await _context.Activity.FindAsync(id);

            #region This is a mess that should've worked but didn't.
            //var activity = new Activity();

            ////projectsTable is all rows of project table
            //var activitiesTable = _context.Activity;
            ////for each row in projects Table
            //foreach (var activityRow in activitiesTable)
            //{
            //    activity.ActivityId = activityRow.ActivityId;
            //    activity.ProjectId = activityRow.ProjectId;
            //    activity.ActivityName = activityRow.ActivityName;
            //    activity.StaffId = activityRow.StaffId;
            //    activity.PredictedStartDate = activityRow.PredictedStartDate;
            //    activity.ActualStartDate = activityRow.ActualStartDate;
            //    activity.PredictedCompletionDate = activityRow.PredictedCompletionDate;
            //    activity.ActualCompletionDate = activityRow.ActualCompletionDate;
            //    activity.PredictedCost = activityRow.PredictedCost;
            //    activity.ActualCost = activityRow.ActualCost;
            //    activity.ActivitySequence = activityRow.ActivitySequence;
            //}

            //var project = await _context.Project.FindAsync(activity.ProjectId);
            //activity.ProjectName = project.ProjectName;

            //var staff = await _context.Staff.FindAsync(activity.StaffId);
            //activity.StaffName = staff.StaffName;
            #endregion

            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        // PUT: api/Activities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivity([FromRoute] int id, [FromBody] Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activity.ActivityId)
            {
                return BadRequest();
            }

            _context.Entry(activity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(id))
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

        // POST: api/Activities
        [HttpPost]
        public async Task<IActionResult> PostActivity([FromBody] Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Activity.Add(activity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)           //basic validation should any database error occur.
            {
                if (ActivityExists(activity.ActivityId))        //if activity id already exists method at bottom of page.
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);     //return error.
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetActivity", new { id = activity.ActivityId }, activity);
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var activity = await _context.Activity.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            _context.Activity.Remove(activity);
            await _context.SaveChangesAsync();

            return Ok(activity);
        }

        //looking if id in table is equal to id sending in post method.
        private bool ActivityExists(int id)
        {
            return _context.Activity.Any(e => e.ActivityId == id);
        }
    }
}