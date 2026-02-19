using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;

namespace HealthMonitor;

public class MonitorHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        Console.WriteLine($"Client Connected: {Context.ConnectionId}");
        await base.OnConnectedAsync();
    }
}