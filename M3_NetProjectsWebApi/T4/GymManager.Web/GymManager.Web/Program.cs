using GymManagerApplicationServices.Members;
using Microsoft.AspNetCore.Builder;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

CultureInfo cultureInfo = new CultureInfo("es-ES"); 
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddTransient<IMembersAppService, MembersAppService>();

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "membersin",
    pattern: "{controller=Attendance}/{action=Index}/{id?}");

app.Run();
