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

        /// <summary>
        /// In the GilesContext.cs, there are four separate methods to call the database.
        /// These are each Get, Post, Put and Delete.
        /// Within each controller, the API is called to retrieve and send the data from relevant models.
        /// The methods below concatenate a string to either Get or Post.
        /// Much of this code has been edited from the standard MVC Template code that is generated.
        /// </summary>


        //If the user is already logged in, rather than revert back to the login page, this will take the user to the logged in page.
        [HttpGet]
        public IActionResult Index()
        {
            if (Convert.ToBoolean(HttpContext.Session.GetString("Authenticated")))
            {
                return RedirectToAction("Overview", "User");
            }
            return View();
        }


        //Method for logging in.
        [HttpPost]
        public IActionResult Index(Authentication model)
        {
            //Change code below to change login credentials.
            if (model.Username == "superuser@asd.com" && model.Password == "Admin")
            {
                //Use 'session' to limit login capability.
                HttpContext.Session.SetString("Authenticated", true.ToString());
                //Return User/Overview screen once logged in.
                return View("~/Views/User/Overview.cshtml");
            }
            //If the credentials are not empty but don't match the login credentials...
            if (model.Username != null && model.Password != null)
            {
                ViewBag.NotValidUser = "Not valid login credentials.";
            }
            ///... return the login view!
            return View();
        }

        //Logout essential sets Boolean to false. 
        //The return redirect adds '/' to api call to generate homepage.
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
