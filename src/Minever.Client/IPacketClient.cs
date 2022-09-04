﻿public interface IPacketClient : IDisposable, IAsyncDisposable
{
    public event Action? Disconnected;
    public event Action<object>? PacketReceived;

    //public abstract static Task<(TimeSpan Ping, ... Status)> PingServerAsync();

    public ValueTask ConnectAsync(string host, ushort port, CancellationToken cancellationToken = default);
    
    public Action<object> OnPacket<TData>(Action<TData> action) where TData : notnull;
    
    public void OnceOnPacket<TData>(Action<TData> action) where TData : notnull;
    
    public Task<TData> WaitPacketAsync<TData>(CancellationToken cancellationToken = default) where TData : notnull;
    
    public void SendPacket(object packetData);

    public Task<TResponseData> SendRequestAsync<TResponseData>(
        object requestPacketData, CancellationToken cancellationToken = default)
        where TResponseData : notnull;
}

// IProtocol protocol         = new JavaProtocolX(); // or BedrockProtocolX
// IPacketClient packetClient = new JavaPacketClient(protocol, logger); // or BedrockPacketClient

// await TPacketClient.PingAsync(address, port);

// var client = new MinecraftClient(packetClient, logger);

// await MinecraftClient.PingAsync(address, port);
// client.Disconnected += ...;
// await client.ConnectAsync(address, port);
// client.Player.Health;
// client.World.Current.GetBlock<GrassBlock>();
// await client.DisconnectAsync();



// await MinecraftClient.PingAsync(address, port).WaitAsync(TimeSpan.FromSecond(5));

// --- or ---
// if (isBedrock)
//     return await BedrockPacketClient.PingAsync(address, port);
// else
//     return await JavaPacketClient.PingAsync(address, port);



// packetClient.OnPacket<JavaWorldTime>(worldTime =>
// {
//     WorldAge  = worldTime.WorldAge;
//     TimeOfDay = worldTime.TimeOfDay;
// });
// packetClient.OnPacket<BedrockWorldTime>(worldTime =>
// {
//     WorldAge  = worldTime.Time;
//     TimeOfDay = TimeSpan.FromSeconds(worldTime.Time.TotalSeconds % 24000);
// });