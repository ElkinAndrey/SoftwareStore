using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftwareStore.Models;

namespace SoftwareStore.Controllers
{
    public class HomeController : Controller
    {
        private IApplicationRepository applicationRepository;

        public HomeController(IApplicationRepository actionResult)
        {
            this.applicationRepository = actionResult;
        }

        public IActionResult Index()
        {
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            ViewBag.Name = User.Identity.Name;

            Account? account = applicationRepository.CheckNameAccount(ViewBag.Name);
            List<Software> softwares = applicationRepository.Softwares;
            List<IndexViewModel> model = new List<IndexViewModel>();
            foreach (Software software in softwares) // Будет указанно, купленна ли программа пользователем
            {
                bool IsBought = false;
                foreach (Account acc in software.Accounts) // Есть ли аккаунт в списке аккаунтов, купивших программу
                {
                    if(acc == account)
                    {
                        IsBought = true;
                        break;
                    }
                }
                model.Add(new IndexViewModel
                {
                    Software = software,
                    IsBought = IsBought
                });
            }

            return View(model);
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

            object? id = RouteData.Values["id"];
            string? name = id?.ToString();

            Software? software = applicationRepository.CheckNameSoftware(name);

            return View(software);
        }
    }
}
