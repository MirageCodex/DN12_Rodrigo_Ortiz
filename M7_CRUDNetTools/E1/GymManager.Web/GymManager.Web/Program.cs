using GymManager.Core.EquipmentTypes;
using GymManager.Core.Members;
using GymManager.Core.MembershipType;
using GymManager.Core.Staff;
using GymManager.DataAccess;
using GymManager.DataAccess.Repositories;
using GymManager.Web.Controllers;
using GymManagerApplicationServices.EquipmentTypes;
using GymManagerApplicationServices.Members;
using GymManagerApplicationServices.MembershipTypes;
using GymManagerApplicationServices.Navigation;
using GymManagerApplicationServices.ReportStaff;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.AspNetCore;
using Serilog.Configuration;
using Serilog.Filters;
using System.Globalization;
using Wkhtmltopdf.NetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] {
    new CultureInfo("en"),
    new CultureInfo("es-MX")
    };
    options.DefaultRequestCulture = new RequestCulture("es-MX");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("Logs/log.txt")
    .WriteTo.Console()
    //.Filter.ByIncludingOnly(Matching.FromSource<MembersController>())
    .CreateLogger();

builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration)
    .Enrich.FromLogContext()
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
builder.Services.AddRazorPages().AddRazorRuntimeCompilation().AddViewLocalization();

builder.Services.AddTransient<IMembersAppService, MembersAppService>();
builder.Services.AddTransient<IMembershipTypesAppService, MembershipTypesAppService>();
builder.Services.AddTransient<IEquipmentTypeAppService, EquipmentTypeAppService>();
builder.Services.AddTransient<IStaffAttendanceAppServices, StaffAttendanceAppServices>();
builder.Services.AddTransient<IMenuAppService, MenuAppService>();
builder.Services.AddTransient<IRepository<int,Member>,MembersRepository>();
builder.Services.AddTransient<IRepository<int,MembershipType>, MembershipTypeRepository>();
builder.Services.AddTransient<IRepository<int,EquipmentType>,EquipmentTypeRepository>();
builder.Services.AddTransient<IRepository<int, StaffAttendance>, Repository<int, StaffAttendance>>();

builder.Services.AddWkhtmltopdf();
builder.Services.AddAutoMapper(typeof(GymManagerApplicationServices.MapperProfile));

var app = builder.Build();

//app.UseSerilogRequestLogging();
app.UseRouting();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var localizationOptions = services.GetService<IOptions<RequestLocalizationOptions>>().Value;
    app.UseRequestLocalization(localizationOptions);
}
app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-development");
}
else
{
    app.UseExceptionHandler("/error");
}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

try
{
    Log.Information("Initiating Program");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "An unhandled exception occurred during bootstrapping");
}
finally
{
    Log.CloseAndFlush();
}

