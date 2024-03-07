using Hangfire;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection")));

// Add the processing server as IHostedService
services.AddHangfireServer();

var application = builder.Build();

application.UseHangfireDashboard("", new DashboardOptions
{
    DarkModeEnabled = false
});

application.Run();