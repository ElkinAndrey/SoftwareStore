// My
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using SoftwareStore.Models;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// My
// Добавления контекста базы данных
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
// Увеличить минимальный размер загружаемого на сервер файла
builder.Services.Configure<FormOptions>(x => {
    x.MultipartBodyLengthLimit = int.MaxValue;
});

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // От куда начинать
app.Run();