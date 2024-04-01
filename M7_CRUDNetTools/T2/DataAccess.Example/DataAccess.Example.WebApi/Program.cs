using DataAccess.Example.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();
Log.Information("Starting up!");

string connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<VehiclesDataContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddTransient<IQueryExample, QueriesExample>();

builder.Services.AddTransient<IColorsDataManager, ColorsDataManager>();

builder.Services.AddTransient<IVehiclesDataManager, VehiclesDataManager>();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);    

var app = builder.Build();

// Configure the HTTP request pipeline.
void Configure (IApplicationBuilder app,IWebHostEnvironment web,VehiclesDataContext context)
{
    if (web.IsDevelopment())
    {
        app.UseExceptionHandler("/error-development");
    }
    else
    {
        app.UseExceptionHandler("/error");
    }
}
Host.CreateDefaultBuilder(args).UseSerilog();
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
