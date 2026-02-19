using Microsoft.AspNetCore.Http.Json;
using HealthMonitor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddHostedService<StatusWorker>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/api/health", () =>
{
    return Results.Json(new
    {
        Status = "Healthy",
        OS = System.Runtime.InteropServices.RuntimeInformation.OSDescription,
        Time = DateTime.UtcNow
    });
});

app.MapHub<MonitorHub>("/monitor-hub");

app.Run();
