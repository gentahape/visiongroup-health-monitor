using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HealthMonitor;

public class StatusWorker : BackgroundService
{
    private readonly IHubContext<MonitorHub> _hubContext;

    public StatusWorker(IHubContext<MonitorHub> hubContext)
    {
        _hubContext = hubContext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var cpuUsage = Random.Shared.Next(10, 90);
            var memoryUsage = Random.Shared.Next(200, 1024);

            var status = new
            {
                Timestamp = DateTime.UtcNow,
                Cpu = cpuUsage,
                Memory = $"{memoryUsage} MB",
                Message = "Server Running Smoothly"
            };

            await _hubContext.Clients.All.SendAsync("ReceiveStatus", status, stoppingToken);
            await Task.Delay(2000, stoppingToken);
        }
    }
}