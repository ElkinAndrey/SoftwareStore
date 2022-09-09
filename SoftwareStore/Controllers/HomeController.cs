using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

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

            object id = RouteData.Values["id"];
            string Name = id.ToString();
            return View(id);
        }
    }
}
