using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SoftwareStore.Controllers
{
    [Authorize(Policy = "Administrator")]
    public class AdminController : Controller
    {
        public IActionResult Index() // Главная страница админ панели
        {
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            ViewBag.Name = User.Identity.Name;

            return View();
        }

        public IActionResult GiveAdmin() // страница, на которой можно выдать админку
        {
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            ViewBag.Name = User.Identity.Name;

            return View();
        }

        public IActionResult GiveSoftware() // страница, на которой можно выдать пользователю доступ к програме
        {
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            ViewBag.Name = User.Identity.Name;

            return View();
        }

        public IActionResult AddSoftware() // страница, на которой можно добавить новую программу на сайт
        {
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            ViewBag.Name = User.Identity.Name;

            return View();
        }

        [AllowAnonymous]
        public IActionResult AccessDenied() // страница, на которую перейдет пользователь без роли администратора
        {
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            ViewBag.Name = User.Identity.Name;

            return View();
        }
    }
}
