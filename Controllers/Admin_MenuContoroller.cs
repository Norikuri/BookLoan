using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookLoan.Controllers
{
    public class Admin_Menu : Controller
    {   
        [HttpPost]
        public IActionResult Index(string Approve, string Apply)
        {
            if (Approve != null)
            {
                return View("Views/Approve_BK/Index.cshtml");
            }
            if (Apply != null)
            {
                return View("Views/Apply_BK/Index.cshtml");
            }
            return View("Index");
        }
    }
}
