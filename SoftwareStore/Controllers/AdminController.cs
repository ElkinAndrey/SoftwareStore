using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                return View(model);

            account.Role = "Administrator";

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

        [HttpPost]
        public async Task<IActionResult> AddSoftware(AddSoftwareViewModel model) // страница, на которой можно добавить новую программу на сайт
        {
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            ViewBag.Name = User.Identity.Name;

            // Проверка данных
            Account? account = applicationRepository.CheckNameAccount(model.Software.Name);
            if (account != null)
                return View(model);

            applicationRepository.AddSoftware(model.Software);

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
