using System.Net.WebSockets;
using System.Text;
using System.Collections.Concurrent;

namespace server.WebSockets
{
    public static class ChatWebSocketHandler
    {
        private static readonly ConcurrentDictionary<string, WebSocket> _connections = new();

        public static async Task HandleAsync(HttpContext context)
        {
            if (!context.WebSockets.IsWebSocketRequest)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid WebSocket request");
                return;
            }

            var userId = context.Request.Query["userId"];
            if (string.IsNullOrEmpty(userId)){
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Missing userId");
                return;
            }

            using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
            _connections[userId] = webSocket;
            Console.WriteLine($"Connected: {userId}");
            await ReceiveMessagesAsync(userId, webSocket);
        }

        private static async Task ReceiveMessagesAsync(string userId, WebSocket socket)
        {
            var buffer = new byte[4096];

            while (socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    _connections.TryRemove(userId, out _);
                    await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by user", CancellationToken.None);
                    Console.WriteLine($"Disconnected: {userId}");
                }
            }
        }

        public static async Task<bool> SendMessageToUserAsync(string userId, string message)
        {
            try{
                if (string.IsNullOrEmpty(userId) ||
                    !_connections.TryGetValue(userId, out var socket) ||
                    socket == null ||
                    socket.State != WebSocketState.Open){
                    Console.WriteLine($"Unable to send message to {userId}");
                    _connections.TryRemove(userId, out _);
                    return false;
                }

                var bytes = Encoding.UTF8.GetBytes(message);
                await socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
                Console.WriteLine($"Sent message to {userId}");
                return true;
            }
            catch (Exception ex){
                Console.WriteLine($"Error sending to {userId}: {ex.Message}");
                _connections.TryRemove(userId, out _);
                return false;
            }
        }

        public static IReadOnlyDictionary<string, WebSocket> GetConnections(){
            return _connections;
        }
    }
}