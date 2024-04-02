using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebApi.Cors.Example;
using WebApi.Cors.Example.Auth;
using WebApi.Cors.Example.Data;
using WebApi.Shared.Config;
using static WebApi.Cors.Example.Auth.IJwtIssuerOptions;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<JwtDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(
    opts =>
    {
        opts.Password.RequireDigit = true;
        opts.Password.RequireLowercase = true;
        opts.Password.RequireUppercase = true;
        opts.Password.RequireNonAlphanumeric = true;
        opts.Password.RequiredLength = 7;
        opts.Password.RequiredUniqueChars = 4;
    })
    .AddEntityFrameworkStores<JwtDbContext>()
    .AddDefaultTokenProviders();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure<JwtTokenValidationSettings>(builder.Configuration.GetSection("JwtTokenValidationSettings"));

builder.Services.AddTransient<IJwtIssuerOptions, JwtIssuerFactory>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter your token in the text input below. \r\n",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id=JwtBearerDefaults.AuthenticationScheme
                }
            },
            new string[]{}
        }
    });
});

var tokenValidationSettings = builder.Services.BuildServiceProvider().GetService<IOptions<JwtTokenValidationSettings>>().Value;

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = tokenValidationSettings.ValidIssuer,
            ValidAudience = tokenValidationSettings.ValidAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenValidationSettings.SecretKey)),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.WithOrigins("https://localhost:44323", "https://www.site.com")
        .WithMethods("GET").WithHeaders("Authorization"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.InitDbAsync();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();
