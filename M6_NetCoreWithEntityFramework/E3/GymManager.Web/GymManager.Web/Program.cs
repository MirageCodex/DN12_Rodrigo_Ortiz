using GymManager.Core.EquipmentTypes;
using GymManager.Core.Members;
using GymManager.Core.MembershipType;
using GymManager.DataAccess;
using GymManager.DataAccess.Repositories;
using GymManager.Web.Controllers;
using GymManagerApplicationServices.EquipmentTypes;
using GymManagerApplicationServices.Members;
using GymManagerApplicationServices.MembershipTypes;
using GymManagerApplicationServices.Navigation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.AspNetCore;
using Serilog.Configuration;
using Serilog.Filters;
using System.Globalization;
using Wkhtmltopdf.NetCore;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("Logs/log.txt")
    .WriteTo.Console()
    .Filter.ByIncludingOnly(Matching.FromSource<MembersController>())
    .CreateLogger();

builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration)
    .WriteTo.Console());

builder.Services.AddLogging();
builder.Host.UseSerilog();


CultureInfo cultureInfo = new CultureInfo("es-ES");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

string connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<GymManagerContext>(options =>
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<GymManagerContext>()
.AddUserStore<UserStore<IdentityUser,IdentityRole,GymManagerContext>>();

builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/LogIn");

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddTransient<IMembersAppService, MembersAppService>();
builder.Services.AddTransient<IMembershipTypesAppService, MembershipTypesAppService>();
builder.Services.AddTransient<IEquipmentTypeAppService, EquipmentTypeAppService>();
builder.Services.AddTransient<IMenuAppService, MenuAppService>();
builder.Services.AddTransient<IRepository<int,Member>,MembersRepository>();
builder.Services.AddTransient<IRepository<int, MembershipType>, MembershipTypeRepository>();
builder.Services.AddTransient<IRepository<int,EquipmentType>,EquipmentTypeRepository>();
builder.Services.AddWkhtmltopdf();

var app = builder.Build();

app.UseSerilogRequestLogging();
app.UseRouting();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
