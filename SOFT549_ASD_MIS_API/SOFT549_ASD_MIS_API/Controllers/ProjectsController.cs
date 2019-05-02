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
    public class ProjectsController : ControllerBase
    {
        private readonly GilesContext _context;

        public ProjectsController(GilesContext context)
        {
            _context = context;
        }

        // GET: api/Projects
        [HttpGet]
        public IEnumerable<Project> GetProject()
        {
            return _context.Project;
        }

        // GET: api/Projects/Basic
        [HttpGet("Basic")]
        public IEnumerable<SelectListItem> GetProjectBasic()
        {
            var projects = _context.Project.Select(p => new SelectListItem() {
                                                      Value = p.ProjectId.ToString(),
                                                      Text = p.ProjectName
                                                  });

            return projects;
        }

        // GET: api/Projects/5/Overview
        [HttpGet("{id}/Overview")]
        public async Task<IActionResult> GetProjectOverview([FromRoute] int id)
        {
            //var project = _context.Project.Where(x => x.ProjectId == id).Select(x => new Project() { ProjectId = x.ProjectId }).FirstOrDefaultAsync();

            //ProjectOverview result = null;

            //var projects = _context.Project.Include(x => x.Client);
            //foreach (var project2 in projects)
            //{
            //    foreach (var client in project2.Client)
            //    {
            //        result = new ProjectOverview() { PredictedLaunchDate = project2.PredictedLaunchDate }; 
            //    }
            //}

            //Get project overview data from multiple tables and store data in project overview model
            var project = await _context.Client

            //Inner Join Projects to Clients
            .Join(_context.Project, x => x.ClientId, y => y.ClientId,
                    (x, y) => new { Client = x, Project = y })

            //Left Join Activities (Optional) to Projects - Where Activity = Project management
            .GroupJoin(_context.Activity, x => x.Project.ProjectId, y => y.ProjectId,
                    (x, y) => new { x.Project, x.Client, Activity = y })
            .SelectMany(x => x.Activity.Where(z => z.ActivityName == "Project management").DefaultIfEmpty(), (x, y) => new { x.Client, x.Project, Activity = y })
                                               
            //Left Join Staff (Optional) to Activities
            .GroupJoin(_context.Staff, x => x.Activity.StaffId, y => y.StaffId,
                    (x, y) => new { x.Project, x.Client, x.Activity, Staff = y })
            .SelectMany(x => x.Staff.DefaultIfEmpty(), (x, y) => new { x.Client, x.Project, x.Activity, Staff = y })
                                               
            //Filter final results to match Project ID
            .Where(x => x.Project.ProjectId == id)

            //Select columns and assign to model
            .Select(x => new ProjectOverview { ClientName = x.Client.ClientName,
                                               PredictedLaunchDate = x.Project.PredictedLaunchDate,
                                               PredictedCompletionDate = x.Project.PredictedCompletionDate,
                                               PredictedCost = x.Project.PredictedCost,
                                               ActualCost = x.Project.ActualCost,
                                               StaffName = x.Staff.StaffName,
                                               StaffContactDetails = x.Staff.ContactDetails
                                            }).FirstOrDefaultAsync();

            
            //If result is null, no records found
            if (project == null)
                return NotFound();

            return Ok(project);
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = await _context.Project.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject([FromRoute] int id, [FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // POST: api/Projects
        [HttpPost]
        public async Task<IActionResult> PostProject([FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Project.Add(project);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjectExists(project.ProjectId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProject", new { id = project.ProjectId }, project);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Project.Remove(project);
            await _context.SaveChangesAsync();

            return Ok(project);
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.ProjectId == id);
        }
    }
}