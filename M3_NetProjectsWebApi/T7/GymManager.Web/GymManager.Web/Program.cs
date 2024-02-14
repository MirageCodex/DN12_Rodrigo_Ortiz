using GymManager.DataAccess;
using GymManagerApplicationServices.Members;
using GymManagerApplicationServices.MembershipTypes;
using GymManagerApplicationServices.Navigation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

CultureInfo cultureInfo = new CultureInfo("es-ES"); 
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

string connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<GymManagerContext>(options =>
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddDefaultIdentity<IdentityUser>(options => 
options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<GymManagerContext>();
builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/LogIn");
   
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddTransient<IMembersAppService, MembersAppService>();
builder.Services.AddTransient<IMembershipTypesAppService, MembershipTypesAppService>();
builder.Services.AddTransient<IMenuAppService, MenuAppService>();

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
