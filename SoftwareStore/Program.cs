// ������ ���������. ��� ����� ���� � ����� ��� (�� ���� �� ��� �� ������). � �������� ����� ����� ��������� ���������� ��� ����, ����� � ������� ��������, ��� � ����� �����, ������ ��� ��� ������� ���������� �����

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("Cookie") // ���������� ��������������
    .AddCookie("Cookie", config =>
    {
        config.LoginPath = "/Account/Login"; // ���� ������� ��� ������� ��������������
    }); // ������������� ����
builder.Services.AddAuthorization(); // ���������� �����������

builder.Services.AddControllersWithViews(); // ���������� MVC


var app = builder.Build();
app.UseHttpsRedirection(); // �������������� ���������� HTTPS
app.UseStaticFiles(); // ���������� ����������� ����� (css,  js)
app.UseRouting(); // ��������� ������������ �������� � �������� �� �������������� ����

app.UseAuthentication(); // ���������� ��������������
app.UseAuthorization(); // ���������� �����������

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // �� ���� ��������
app.Run();