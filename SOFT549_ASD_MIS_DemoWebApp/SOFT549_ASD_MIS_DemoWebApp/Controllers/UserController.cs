using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SOFT549_ASD_MIS_DemoWebApp.Models;

namespace SOFT549_ASD_MIS_DemoWebApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Overview()
        {
            return View();
        }
    }
}