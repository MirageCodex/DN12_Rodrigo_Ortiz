using DataAccess.GymManager.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
string connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<GymManagerDataContext>(options =>
options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));
builder.Services.AddTransient<IQuerrysGymManager, QuerrysGymManager>();
builder.Services.AddControllers().AddNewtonsoftJson(X => X.SerializerSettings.ReferenceLoopHandling
= Newtonsoft.Json.ReferenceLoopHandling.Ignore);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
