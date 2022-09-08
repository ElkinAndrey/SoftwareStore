using Microsoft.AspNetCore.Mvc;

namespace SoftwareStore.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string returnURL)
        {
            return View();
        }

        public IActionResult Registration(string returnURL)
        {
            return View();
        }
    }
}
