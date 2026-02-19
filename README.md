# Health Monitor Service

A unified Health Check service combining REST API and WebSocket using .NET 8 and Docker.

## Requirements
- Docker
- Linux / WSL

## How to Run (Using Docker)

1. Build the image:
   ```bash
   cd HealthMonitor
   docker build -t health-monitor-app .
   ```

2. Run the container:
    ```bash
    docker run -d -p 5000:8080 --name my-monitor health-monitor-app
    ```

## Testing
- REST API:
    `curl http://localhost:5000/api/health`
- WebSocket:
    Connect via Postman or WebSocket Client to: `ws://localhost:5000/monitor-hub`