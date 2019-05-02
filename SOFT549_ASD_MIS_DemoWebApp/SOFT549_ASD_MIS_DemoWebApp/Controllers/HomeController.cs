using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SOFT549_ASD_MIS_DemoWebApp.Models;
using Microsoft.AspNetCore.Http;

namespace SOFT549_ASD_MIS_DemoWebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly GilesContext _context;

        public HomeController(GilesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Authenticated")))
            {
                return RedirectToAction("Overview", "User");
                //return Redirect("/User/Overview");
            }

            Authentication auth = new Authentication();
            auth.Username = "superuser@asd.com";
            auth.Password = "Admin";

            return View(auth);
        }

        [HttpPost]
        public IActionResult Index(Authentication model)
        {
            if (model.Username == "superuser@asd.com" && model.Password == "Admin")
            {
                HttpContext.Session.SetString("Authenticated", true.ToString());
                
                return RedirectToAction("Overview", "User");
            }
            if (model.Username != null && model.Password != null)
            {
                ViewBag.NotValidUser = "Not valid login credentials.";
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("Authenticated", false.ToString());
            return Redirect("/");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "PND contact page.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
