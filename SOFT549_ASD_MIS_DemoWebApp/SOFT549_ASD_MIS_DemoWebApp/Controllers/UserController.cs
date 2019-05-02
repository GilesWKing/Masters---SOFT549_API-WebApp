using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SOFT549_ASD_MIS_DemoWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SOFT549_ASD_MIS_DemoWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly GilesContext _context;

        public UserController(GilesContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Overview(int? ProjectId)
        {
            //Get ProjectId, ProjectName List from API
            var projects = await _context.GetApiCall<List<SelectListItem>>(string.Concat("Projects", "/", "Basic"));

            //Setup View Model and Projects Dropdown List Data
            var model = new Models.ViewModels.User.Overview
            {
                ProjectId = ProjectId,
                Projects = projects
            };

            //Get Project Overview Data
            if (ProjectId != null)
            {
                try
                {
                    var overview = await _context.GetApiCall<ProjectOverview>(string.Concat("Projects", "/", ProjectId, "/", "Overview"));

                    model.ClientName = overview.ClientName;
                    model.PredictedLaunchDate = overview.PredictedLaunchDate.ToString("dd/MM/yyyy");
                    model.PredictedCompletionDate = overview.PredictedCompletionDate.ToString("dd/MM/yyyy");
                    model.PredictedCost = overview.PredictedCost;
                    model.ActualCost = overview.ActualCost;

                    if (overview.StaffName != null)
                        model.StaffName = overview.StaffName;

                    if (overview.StaffContactDetails != null)
                        model.StaffContactDetails = overview.StaffContactDetails;
                }
                catch { }
            }

            return View(model);
        }
        
        public IActionResult ReqForQuote()
        {
            return View();
        }
    }
}