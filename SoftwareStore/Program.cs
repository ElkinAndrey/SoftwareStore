// Даниил Сергеевич. Эту часть кода я писал сам (ни кому за это не платил). Я оставляю здесь такие подробные коментарии для себя, чтобы в будущем понимать, что и зачем нужно, потому что это сложные непонятные слова

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("Cookie") // Добавление аутентификации
    .AddCookie("Cookie", config =>
    {
        config.LoginPath = "/Account/Login"; // Куда перейти при попытке аутентификации
    }); // Использование куки
builder.Services.AddAuthorization(); // Добавление авторизации

builder.Services.AddControllersWithViews(); // Добавление MVC


var app = builder.Build();
app.UseHttpsRedirection(); // Принудительное применение HTTPS
app.UseStaticFiles(); // Добавление статических фалов (css,  js)
app.UseRouting(); // Добавляет соответствие маршрута в конвейер ПО промежуточного слоя

app.UseAuthentication(); // Добавление аутентификации
app.UseAuthorization(); // Добавление авторизации

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // От куда начинать
app.Run();