using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftwareStore.Models.ViewModel;
using SoftwareStore.Models;

namespace SoftwareStore.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        IApplicationRepository applicationRepository = new FakeApplicationRepository();

        [AllowAnonymous]
        public IActionResult Login(string returnURL)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginViewModel model)
        {
            Account? account = applicationRepository.CheckNameAccount(model.Name);
            if (account == null)
                return View(model);
            if (account.Password != model.Password)
                return View(model);
            return RedirectToLocal(model.ReturnUrl);
        }

        [AllowAnonymous]
        public IActionResult Registration(string returnURL)
        {
            return View();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
