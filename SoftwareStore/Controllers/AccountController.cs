using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftwareStore.Models.ViewModel;

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

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginViewModel model)
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
