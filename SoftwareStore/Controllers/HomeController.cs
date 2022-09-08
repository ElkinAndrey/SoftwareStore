﻿using Microsoft.AspNetCore.Mvc;

namespace SoftwareStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            ViewBag.Name = User.Identity.Name;
            return View();
        }
    }
}
