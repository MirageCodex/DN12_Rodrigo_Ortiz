using ATOS.ApplicationServices.Accounts;
using ATOS.Core.Accounts;
using ATOS.DataAccess.Repositories;
using GymManager.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ATOSContext>(options =>
options.UseInMemoryDatabase(databaseName: "ATOS"));

builder.Services.AddControllers().AddJsonOptions(x => { });

builder.Services.AddTransient<IProfilesAppService, ProfilesAppService>();
builder.Services.AddTransient<IUsersAppServices, UsersAppService>();

builder.Services.AddTransient<IRepository<int, ATOS.Core.Accounts.Profile>, ProfilesRepository>();
builder.Services.AddTransient<IRepository<int, User>, UserRepository>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ATOS API", Version = "v1" });
});

builder.Services.AddAutoMapper(typeof(ATOS.ApplicationServices.MapperProfile));

string connectionString = builder.Configuration.GetConnectionString("Logs");
builder.Services.AddSingleton((Serilog.ILogger)new LoggerConfiguration()
    .WriteTo.MySQL(connectionString)
    .CreateLogger());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
