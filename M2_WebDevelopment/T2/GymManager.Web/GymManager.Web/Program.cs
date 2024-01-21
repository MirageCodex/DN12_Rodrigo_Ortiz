var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();

app.MapGet("/", () => "Hello World!");
app.MapGet("/File.html", () => DateTime.Now.ToString());

app.Run();
