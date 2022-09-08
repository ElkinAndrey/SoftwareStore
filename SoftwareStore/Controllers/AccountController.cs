using Microsoft.AspNetCore.Mvc;

namespace SoftwareStore.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public IActionResult Login(string returnURL)
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Registration(string returnURL)
        {
            return View();
        }
    }
}
