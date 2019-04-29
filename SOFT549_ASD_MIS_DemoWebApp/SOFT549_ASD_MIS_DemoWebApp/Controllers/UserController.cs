using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Overview()
        {
            return View();
        }

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
    }
}