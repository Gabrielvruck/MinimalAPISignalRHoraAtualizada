using Microsoft.AspNetCore.SignalR.Client;

const string url = "https://localhost:7201/chat";

//criacao da conexao com servidor signalr
await using var connection = new HubConnectionBuilder().WithUrl(url).Build();

//conectar ao servidor
await connection.StartAsync();

await foreach(var date in connection.StreamAsync<DateTime>("Streaming"))
{
    Console.WriteLine(date);
}