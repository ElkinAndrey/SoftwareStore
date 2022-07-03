using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareStore.Models;
using SoftwareStore.Models.ViewModels;

namespace SoftwareStore.Controllers
{
    public class HomeController : Controller
    {
        IApplicationRepository repository;

        public HomeController(ApplicationDbContext context)
        {
            repository = new EFApplicationRepository(context);
            /*Account account = new Account()
            {
                Name = "1",
                Password = "2"
            };
            Software software = new Software()
            {
                Name = "3",
                ShortInformation = "4",
                Information = "5",
                Price = 6,
                File = "7",
                Image = "8",
                Size = 9,
                OS = "10",
                Language = "11",
                Date = DateTime.Now,
                Downloads = 12
            };
            account.Softwares.Add(software);
            software.Accounts.Add(account);
            software.Reviews.Add(new Review()
            {
                Name = "13",
                Information = "14",
                Software = software
            });

            repository.AddAccount(account);*/

            foreach(var i in repository.Accounts)
            {
                Console.WriteLine(i.Name);
                foreach(var j in i.Softwares)
                {
                    Console.WriteLine(j.Name);
                }
                Console.WriteLine("\n");
            }
        }

        public IActionResult Index(SoftwareViewModel softwareViewModel)
        {
            // Формирование списка программ
            foreach (var i in 
                ((softwareViewModel.SearchString ?? "") == "" ? // Проверка строки поиска
                repository.Softwares : // Если строка пустая, то вернуть весь список программ
                repository.Softwares.Where(b => (b.Name.ToLower()).Contains(softwareViewModel.SearchString.ToLower())).ToList()) // Если строка не пустая, то вернуть только программы, содержащие в своем имени строку поиска
            )
            {
                AllMySoftware allMySoftware = new AllMySoftware()
                {
                    Software = i
                };
                Account? account = SignInAccount.Account;
                foreach (var j in account?.Softwares ?? new List<Software>())
                {
                    if (i.Name == j.Name)
                    {
                        allMySoftware.My = true;
                        continue;
                    }
                }
                softwareViewModel.Softwares.Add(allMySoftware);
            }

            // Добавить имя аккаунта, если есть вход в аккаунт
            ViewBag.Name = (SignInAccount.Account)?.Name ?? "";

            return View(softwareViewModel);
        }

        public IActionResult Product(int id)
        {
            Software software = repository.CheckIdSoftware(id) ?? new Software();
            ViewBag.Name = (SignInAccount.Account)?.Name ?? ""; // Имя аккаунта

            ViewBag.Buy = false;
            foreach (var i in software.Accounts)
                if (i.Name == ((SignInAccount.Account)?.Name ?? ""))
                {
                    ViewBag.Buy = true;
                    continue;
                }

            return View(software);
        }

        public ViewResult AddDownload(int id)
        {
            Software software = repository.CheckIdSoftware(id) ?? new Software(); // Программа
            software.Downloads++;
            repository.Update();

            ViewBag.Name = (SignInAccount.Account)?.Name ?? ""; // Имя аккаунта

            ViewBag.Buy = false;
            foreach (var i in software.Accounts)
                if (i.Name == ((SignInAccount.Account)?.Name ?? ""))
                {
                    ViewBag.Buy = true;
                    continue;
                }

            return View("Product", software);
        }

		[HttpPost]
        public FileResult DownloadFile(int id, string filename)
        {
            Software software = repository.CheckIdSoftware(id) ?? new Software();
            software.Downloads++;
            repository.Update();
            //Build the File Path.
            string path = "wwwroot/files/" + filename;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", filename);
        }

        public ViewResult AddReview(int id, string information)
        {
            Review review = new Review
            {
                Name = (SignInAccount.Account)?.Name ?? "",
                Information = information ?? ""
            };
            Software software = repository.CheckIdSoftware(id) ?? new Software(); // Программа
            software.Reviews.Add(review);
            repository.Update();

            ViewBag.Name = (SignInAccount.Account)?.Name ?? ""; // Имя аккаунта

            ViewBag.Buy = false;
            foreach (var i in software.Accounts)
                if (i.Name == ((SignInAccount.Account)?.Name ?? ""))
                {
                    ViewBag.Buy = true;
                    continue;
                }

            return View("Product", software);
        }

        public IActionResult Buy(int id)
        {
            ViewBag.Name = (SignInAccount.Account)?.Name ?? ""; // Имя аккаунта
            return View(id);
        }
    }
}
