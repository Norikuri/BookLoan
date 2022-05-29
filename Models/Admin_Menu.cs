using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookLoan.Models
{
    public class Admin_Menu : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
