using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookLoan.Controllers
{
    public class GeneralController : Controller
    {   
        [HttpPost]
        public IActionResult Index()
        {
            
            //return View("Index");
            return RedirectToAction("Login", "Login");
        }

        public IActionResult Menu()
        {
            return View("General_menu");
        }
    }
}
