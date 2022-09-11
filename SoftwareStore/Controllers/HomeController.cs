using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftwareStore.Models;

namespace SoftwareStore.Controllers
{
    public class HomeController : Controller
    {
        private IApplicationRepository applicationRepository;

        public HomeController(IApplicationRepository actionResult)
        {
            this.applicationRepository = actionResult;
        }

        public IActionResult Index()
        {
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            ViewBag.Name = User.Identity.Name;

            List<Software> softwares = applicationRepository.Softwares;

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

            Software? software = applicationRepository.CheckNameSoftware(name);

            return View(software);
        }
    }
}
