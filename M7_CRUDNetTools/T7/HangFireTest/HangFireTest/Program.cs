using Hangfire;
using Hangfire.MySql;
using Hangfire.Server;
using HangFireTest.Helper;
using HangFireTest.Jobs;
using System.Transactions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

GlobalConfiguration.Configuration.UseStorage(
    new MySqlStorage(builder.Configuration.GetConnectionString("HangfireConnection"), new MySqlStorageOptions 
    { 
        TransactionIsolationLevel = IsolationLevel.ReadCommitted,
        QueuePollInterval = TimeSpan.FromSeconds(15),
        JobExpirationCheckInterval = TimeSpan.FromHours(1),
        CountersAggregateInterval = TimeSpan.FromMinutes(5),
        PrepareSchemaIfNecessary = true,
        DashboardJobListLimit = 5000,
        TransactionTimeout = TimeSpan.FromMinutes(5),
        TablesPrefix = "HangFire"
    }));

builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings());

builder.Services.AddHangfireServer(JobStorage.Current, additionalProcesses: new IBackgroundProcess[] 
{
    new TestProcess()});

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

app.UseAuthorization();

app.MapRazorPages();

app.UseHangfireDashboard();

RecurringJob.AddOrUpdate(
    "myrecurringjob",
    () => DBHelper.Process(0,"Recourring"),
    Cron.Minutely);

//RecurringJob.RemoveIfExists("myrecurringjob");

app.Run();
