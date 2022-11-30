using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace SoftwareStore.Controllers
{
    [Authorize(Policy = "Administrator")]
    public class AdminController : Controller
    {

        private IApplicationRepository applicationRepository;

        public AdminController(IApplicationRepository applicationRepository)
        {
            this.applicationRepository = applicationRepository;
        }

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

        [HttpPost]
        public async Task<IActionResult> GiveAdmin(GiveAdminViewModel model) // страница, на которой можно выдать админку
        {
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            ViewBag.Name = User.Identity.Name;

            // Проверка данных
            Account? account = applicationRepository.CheckNameAccount(model.Name);
            if (account == null)
            {
                ModelState.AddModelError(nameof(model.Name), "Name not found");
                return View(model);
            }

            applicationRepository.GiveAdmin(account);

            return View();
        }

        public IActionResult GiveSoftware() // страница, на которой можно выдать пользователю доступ к програме
        {
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            ViewBag.Name = User.Identity.Name;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GiveSoftware(GiveSoftwareViewModel model) // страница, на которой можно выдать пользователю доступ к програме
        {
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            ViewBag.Name = User.Identity.Name;

            Account? account = applicationRepository.CheckNameAccount(model.Account);
            if (account == null)
            {
                ModelState.AddModelError(nameof(model.Account), "Name not found");
                return View(model);
            }

            Software? software = applicationRepository.CheckNameSoftware(model.Software);
            if (software == null)
            {
                ModelState.AddModelError(nameof(model.Software), "Software not found");
                return View(model);
            }

            applicationRepository.GiveSoftware(account, software); // Выдать пользователю программу

            return View();
        }

        public IActionResult AddSoftware() // страница, на которой можно добавить новую программу на сайт
        {
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            ViewBag.Name = User.Identity.Name;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSoftware(AddSoftwareViewModel model) // страница, на которой можно добавить новую программу на сайт
        {
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            ViewBag.Name = User.Identity.Name;

            // Проверка данных
            Software? software = applicationRepository.CheckNameSoftware(model.Name);
            if(software != null)
            {
                ModelState.AddModelError(nameof(model.Name), "The name is already in use");
                return View(model);
            }

            if (model.Price < 0)
            {
                ModelState.AddModelError(nameof(model.Price), "The price cannot be negative");
                return View(model);
            }
            if (!ModelState.IsValid) { return View(model); }
            Software newSoftware = new Software 
            { 
                Name = model.Name, 
                ShortInformation = model.ShortInformation, 
                Information = model.Information, 
                Price = model.Price ?? 0
            };
            applicationRepository.AddSoftware(newSoftware);

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
