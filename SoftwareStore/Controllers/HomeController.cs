using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftwareStore.Models;

namespace SoftwareStore.Controllers
{
    public class HomeController : Controller
    {
        private IApplicationRepository actionResult = new FakeApplicationRepository();

        public IActionResult Index()
        {
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            ViewBag.Name = User.Identity.Name;

            List<Software> softwares = actionResult.Softwares;

            return View(softwares);
        }

        public IActionResult LogOff()
        {

            HttpContext.SignOutAsync("Cookie"); // Удаление куки
            return Redirect("/Home/Index");
        }

        public ViewResult Product()
        {
            // Тут продукт должен браться из базы данных, если продукт не найден, то на странице вывести сообщение "Продукт не найден"

            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            ViewBag.Name = User.Identity.Name;

            object? id = RouteData.Values["id"];
            string? name = id?.ToString();

            Software? software = actionResult.CheckNameSoftware(name);

            return View(software);
        }

        [Authorize(Policy = "Administrator")]
        public IActionResult Admin()
        {
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            ViewBag.Name = User.Identity.Name;

            return View();
        }

        public IActionResult AccessDenied()
        {
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            ViewBag.Name = User.Identity.Name;

            return View();
        }
    }
}
