using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);
//adicionar serviço signalR
builder.Services.AddSignalR();
var app = builder.Build();

app.MapHub<MyHub>("/chat");

app.MapGet("/", () => "Hello World!");

app.Run();

class MyHub : Hub
{
    public async IAsyncEnumerable<DateTime> Streaming(CancellationToken cancellationToken)
    {
        while (true)
        {
            yield return DateTime.UtcNow;
            await Task.Delay(1000, cancellationToken);
        }
    }
}
