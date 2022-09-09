using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftwareStore.Models.ViewModel;
using SoftwareStore.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using SoftwareStore.Data;

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
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            Account? account = applicationRepository.CheckNameAccount(model.Name);
            if (account == null)
                return View(model);
            if (account.Password != model.Password)
                return View(model);

            List<Claim> claims;
            if (account?.Role == "Administrator")
            {
                claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Name),
                    new Claim(ClaimTypes.Role, "Administrator")
                };
            }
            else
            {
                claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Name)
                };
            }

            var claimIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimPricipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync("Cookie", claimPricipal); // Добавление куки

            return RedirectToLocal(model.ReturnUrl);
        }

        [AllowAnonymous]
        public IActionResult Registration(string returnURL)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            Account? account = applicationRepository.CheckNameAccount(model.Name);
            if (account != null)
                return View(model);

            List<Claim> claims;
            if (account?.Role == "Administrator")
            {
                claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Name),
                    new Claim(ClaimTypes.Role, "Administrator")
                };
            }
            else
            {
                claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Name)
                };
            }

            var claimIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimPricipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync("Cookie", claimPricipal); // Добавление куки

            applicationRepository.AddAccount(new Account
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
            });

            return RedirectToLocal(model.ReturnUrl);
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
