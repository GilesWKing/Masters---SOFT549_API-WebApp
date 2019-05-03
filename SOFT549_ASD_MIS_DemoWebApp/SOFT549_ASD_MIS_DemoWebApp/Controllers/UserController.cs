using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SOFT549_ASD_MIS_DemoWebApp.Models;
using Microsoft.AspNetCore.Http;

namespace SOFT549_ASD_MIS_DemoWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly GilesContext _context;

        public UserController(GilesContext context)
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

        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> Overview(int? ProjectId)
        //{
        //    var projectList = await _context.GetApiCall<List<SelectListItem>>(string.Concat("Projects", "/", "Dropdown"));
        //    ViewBag.ProjectList = projectList;

        //    Overview overview = new Overview();

        //    if (ProjectId != null)
        //        overview = await _context.GetApiCall<Overview>(string.Concat("Projects", "/", "Overview"));

        //    return View(overview);
        //}

        //public async Task<IActionResult> Overview()
        //{
        //    //if(Convert.ToBoolean(HttpContext.Session.GetString("Authenticated")))
        //    //    return View();                      // generates the overview screen upon successful login

        //    //return Redirect("/");
        //    var projects = await _context.GetApiCall<List<Project>>("Projects");
        //    return View(projects);

        //}

        public IActionResult ReqForQuote()
        {
            //if (Convert.ToBoolean(HttpContext.Session.GetString("Authenticated")))
            //    return View();

            //return Redirect("/");
            return View();
        }

        public IActionResult Overview()
        {
            return View();
        }
    }
}