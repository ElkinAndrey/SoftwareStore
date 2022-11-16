// Даниил Сергеевич. Эту часть кода я писал сам (ни кому за это не платил). Я оставляю здесь такие подробные коментарии для себя, чтобы в будущем понимать, что и зачем нужно, потому что это сложные непонятные слова

using Microsoft.EntityFrameworkCore;
using SoftwareStore.Models;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("Cookie") // Добавление аутентификации
    .AddCookie("Cookie", config =>
    {
        config.LoginPath = "/Account/Login"; // Куда перейти при попытке аутентификации
        config.AccessDeniedPath = "/Admin/AccessDenied";
    }); // Использование куки
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Administrator", builder =>
    {
        builder.RequireClaim(ClaimTypes.Role, "Administrator"); // Добавление рои администратора
    });
}); // Добавление авторизации

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = SoftwareStore; Trusted_Connection = True")
);

builder.Services.AddTransient<IApplicationRepository, FakeApplicationRepository>(); // передаю IApplicationRepository в конструкторы контроллеров

builder.Services.AddControllersWithViews(); // Добавление MVC


var app = builder.Build();
app.UseHttpsRedirection(); // Принудительное применение HTTPS
app.UseStaticFiles(); // Добавление статических фалов (css,  js)
app.UseRouting(); // Добавляет соответствие маршрута в конвейер ПО промежуточного слоя

app.UseAuthentication(); // Добавление аутентификации
app.UseAuthorization(); // Добавление авторизации

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id=DefaultId}"); // От куда начинать
app.Run();