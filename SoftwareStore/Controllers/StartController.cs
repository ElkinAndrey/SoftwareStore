using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftwareStore.Models;

namespace SoftwareStore.Controllers
{
    public class StartController : Controller
    {
        private IApplicationRepository repository;

        public StartController(ApplicationDbContext context)
        {
            SignInAccount.SignOut();
            repository = new EFApplicationRepository(context);
        }

        public IActionResult Login()
        {
            ViewBag.NameEmailError = false;
            ViewBag.PasswordError = false;
            var account = new Account();
            return View(account);
        }

        [HttpPost]
        public IActionResult Login(Account account)
        {
            Account acc = repository.CheckNameAccount(account);
            if (acc != null && acc.Name == account.Name && account.Name != null)
            {
                if (acc.Password == account.Password && account.Password != null)
                {
                    SignInAccount.SignIn(acc);
                    return RedirectToAction("Index", "Home");
                }

                ViewBag.NameEmailError = false;
                ViewBag.PasswordError = true;
                return View(account);
            }
            ViewBag.NameEmailError = true;
            ViewBag.PasswordError = false;
            return View(account);
        }

        public IActionResult Registration()
        {

            ViewBag.NameEmailError = false;
            ViewBag.PasswordError = false;
            var account = new Account();
            return View(account);
        }

        [HttpPost]
        public IActionResult Registration(Account account)
        {
            var acc = repository.CheckNameAccount(account);
            if (acc == null && account.Name != null)
            {
                if (account.Password != null)
                {
                    repository.AddAccount(account);
                    SignInAccount.SignIn(account);
                    return RedirectToAction("Index", "Home");
                }

                ViewBag.NameEmailError = false;
                ViewBag.PasswordError = true;
                return View(account);
            }
            ViewBag.NameEmailError = true;
            ViewBag.PasswordError = false;
            return View(account);
        }
    }
}
