﻿using Microsoft.AspNetCore.Mvc;

namespace DA_TT_Client.Areas.Employees.Controllers
{
    public class EmployeeHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
