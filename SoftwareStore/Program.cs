// ������ ���������. ��� ����� ���� � ����� ��� (�� ���� �� ��� �� ������). � �������� ����� ����� ��������� ���������� ��� ����, ����� � ������� ��������, ��� � ����� �����, ������ ��� ��� ������� ���������� �����

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); // ���������� MVC

var app = builder.Build();
app.UseHttpsRedirection(); // �������������� ���������� HTTPS
app.UseStaticFiles(); // ���������� ����������� ����� (css,  js)
app.UseRouting(); // ��������� ������������ �������� � �������� �� �������������� ����

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // �� ���� ��������
app.Run();