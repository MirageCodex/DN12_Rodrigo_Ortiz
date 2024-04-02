using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;
using WebCors.Example.Client.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebCors.Example.Client.Data;
using WebCors.Example.Client.Areas.Identity.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using WebApi.Shared.Config;
using WebCors.Example.Client.Utils;
using WebCors.Example.Client.Utils.Config;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation().AddViewLocalization().AddDataAnnotationsLocalization(options =>
{
    options.DataAnnotationLocalizerProvider = (type, factory) =>
    {
        var assemblyName = new AssemblyName(typeof(CommonResources).GetTypeInfo().Assembly.FullName);
        return factory.Create(nameof(CommonResources), assemblyName.Name);
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UsersOnly", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
    });
});

var authorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.Configure<JwtTokenValidationSettings>(builder.Configuration.GetSection(nameof(JwtTokenValidationSettings)));
builder.Services.AddSingleton<IJwtTokenValidationSettings, JwtTokenValidationSettingsFactory>();

builder.Services.Configure<JwtTokenIssuerSettings>(builder.Configuration.GetSection(nameof(JwtTokenIssuerSettings)));
builder.Services.AddSingleton<IJwtTokenIssuerSettings, JwtTokenIssuerSettingsFactory>();

builder.Services.Configure<AuthenticationSettings>(builder.Configuration.GetSection(nameof(AuthenticationSettings)));
builder.Services.AddSingleton<IAuthenticationSettings, AuthenticationSettingsFactory>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IClaimPrincipalManager, ClaimPricipalManager>();


var serviceProvider = builder.Services.BuildServiceProvider();
var authenticationSettings = serviceProvider.GetService<IAuthenticationSettings>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddCookie(JwtBearerDefaults.AuthenticationScheme,
    options =>
    {
        options.LoginPath = authenticationSettings.LoginPath;
        options.AccessDeniedPath = authenticationSettings.AccessDeniedPath;
        options.Events = new CookieAuthenticationEvents
        {
            OnValidatePrincipal = RefreshTokenMonitor.ValidateAsync
        };
    }
    );
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient("WebApi", (client) =>
{
    client.BaseAddress = new Uri(builder.Configuration["JwtTokenIssuerSettings:BaseAddress"]);
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en"),
        new CultureInfo("es-MX")
    };
    options.DefaultRequestCulture = new RequestCulture("es-MX");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var localizationOptions = services.GetService<IOptions<RequestLocalizationOptions>>().Value;
    app.UseRequestLocalization(localizationOptions);
}

app.UseAuthorization();

app.MapRazorPages();

app.Run();
