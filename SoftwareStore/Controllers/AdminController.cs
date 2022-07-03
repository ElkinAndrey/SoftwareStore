using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using SoftwareStore.Models;
using SoftwareStore.Models.ViewModels;
using System.Security;

namespace SoftwareStore.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext _context;
        IWebHostEnvironment _appEnvironment;
        IApplicationRepository repository;

        public AdminController(ApplicationDbContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
            repository = new EFApplicationRepository(context);
        }

        public IActionResult Index()
        {
            ProductViewModel productViewModel = new ProductViewModel(); // Создание модели для представления
            ViewBag.AdminPanel = (SignInAccount.Account)?.Admin ?? false; // Показать админ панель только администратору
            return View(productViewModel);
        }

        // Дать админку
        [HttpPost]
        public ViewResult GiveAdmin(ProductViewModel productViewModel)
        {
            ViewBag.AdminPanel = (SignInAccount.Account)?.Admin ?? false; // Показать админ панель только администратору

            // Проверить, есть ли такое имя
            Account? account = repository.CheckNameAccount(new Account { Name = productViewModel.NameAdmin });
            if (account == null)
            {
                ModelState.AddModelError(nameof(productViewModel.NameAdmin), "1");
                return View("Index", productViewModel);
            }
            account.Admin = true;
            repository.Update();

            return View("Index", productViewModel);
        }

        // Дать пользователю программу
        [HttpPost]
        public ViewResult GiveProduct(ProductViewModel productViewModel)
        {
            ViewBag.AdminPanel = (SignInAccount.Account)?.Admin ?? false;  // Показать админ панель только администратору

            // Проверки
            Account? account = repository.CheckNameAccount(new Account { Name = productViewModel.NameBuyer });
            if (account == null) // Проверка, есть ли такое имя
                ModelState.AddModelError(nameof(productViewModel.NameBuyer), "2");
            Software? software = repository.CheckNameSoftware(new Software { Name = productViewModel.Product });
            if (software == null) // Проверка, есть ли такая программа
                ModelState.AddModelError(nameof(productViewModel.Product), "3");
            if (software == null || account == null)
                return View("Index", productViewModel);

            // Дать программу
            account.Softwares.Add(software); // Добавление программы в список покупок
            if (account.Name == SignInAccount.Account.Name) // Добавление программы в список покупок самому себе, чтобы не нужно было перезаходить
                SignInAccount.Account.Softwares.Add(software);
            repository.Update();

            return View("Index", productViewModel);
        }

        // Добавить новую программу
        [HttpPost]
        [DisableRequestSizeLimit]
        public ViewResult AddProduct(ProductViewModel productViewModel)
        {
            ViewBag.AdminPanel = (SignInAccount.Account)?.Admin ?? false; // Показать админ панель только администратору

            // Проверки
            Software? software = productViewModel.Software;
            if (repository.CheckNameSoftware(software) != null) // Проверка, есть ли продукт с таким именем
                ModelState.AddModelError(nameof(productViewModel.Software.Name), "4");
            if (productViewModel.Software.ShortInformation == "") // Проверка, заполнено ли короткое описание
                ModelState.AddModelError(nameof(productViewModel.Software.ShortInformation), "5");
            if (productViewModel.Software.Information == "") // Проверка, заполнена ли информация
                ModelState.AddModelError(nameof(productViewModel.Software.Information), "6");
            if (productViewModel.Software.Price == 0) // Проверка, указана ли цена
                ModelState.AddModelError(nameof(productViewModel.Software.Price), "7");
            if (productViewModel.Software.Size == 0) // Проверка, указан ли вес программы
                ModelState.AddModelError(nameof(productViewModel.Software.Size), "8");
            if (productViewModel.Software.OS == "") // Проверка, указана ли операционная система
                ModelState.AddModelError(nameof(productViewModel.Software.OS), "9");
            if (productViewModel.Software.Language == "") // Проверка, указан ли язык
                ModelState.AddModelError(nameof(productViewModel.Software.Language), "10");
            if (productViewModel.GetFile == null || productViewModel.GetImage == null) // Проверка на путь к файлу и проверка на путь к картинке
            {
                productViewModel.GetFile = null;
                productViewModel.GetImage = null;
                ModelState.AddModelError(nameof(productViewModel.GetFile), "8");
                ModelState.AddModelError(nameof(productViewModel.GetImage), "9");
            }
            if (
                software != null ||
                productViewModel.Software.ShortInformation == "" ||
                productViewModel.Software.Information == "" ||
                productViewModel.Software.Price == 0 ||
                productViewModel.GetFile == null ||
                productViewModel.GetImage == null
             )
                return View("Index", productViewModel);

            // Добавление
            productViewModel.Software.File = GetNewFileName(productViewModel.GetFile.FileName, productViewModel.Software.Name);
            productViewModel.Software.Image = GetNewFileName(productViewModel.GetImage.FileName, productViewModel.Software.Name);
            AddFiles(productViewModel.Software.Name, "/files/", productViewModel.GetFile);
            AddFiles(productViewModel.Software.Name, "/images/", productViewModel.GetImage);
            repository.AddSoftware(new Software() // Добавение программы
            {
                Name = productViewModel.Software.Name,
                ShortInformation = productViewModel.Software.ShortInformation,
                Information = productViewModel.Software.Information,
                Price = productViewModel.Software.Price,
                File = productViewModel.Software.File,
                Image = productViewModel.Software.Image,
                Size = productViewModel.Software.Size,
                OS = productViewModel.Software.OS,
                Language = productViewModel.Software.Language,
                Date = DateTime.Now
            });
            productViewModel.GetFile = null;
            productViewModel.GetImage = null;

            return View("Index", productViewModel);
        }

        // Получить новое имя файла с расжирением от старого (adfgdsa.exe => new.exe)
        private string GetNewFileName(string oldName, string newName)
        {
            int i;
            for (i = oldName.Length - 1; oldName[i] != '.'; i--) { }
            newName += oldName.Substring(i, oldName.Length - i);
            return newName;
        }

        // Добавить файл на сервер (новое имя файла без расширения, папка, IFormFile)
        private async void AddFiles(string FileName, string Path, IFormFile File)
        {
            if (Path[Path.Length - 1] != '\\' && Path[Path.Length - 1] != '/')
                Path += '/';
            string path;
            int i;
            for (i = File.FileName.Length - 1; File.FileName[i] != '.'; i--) { }
            path = Path + FileName + File.FileName.Substring(i, File.FileName.Length - i);
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                try
                {
                    await File.CopyToAsync(fileStream);
                }
                catch (ObjectDisposedException e)
                {

                }
            }
        }
    }
}
