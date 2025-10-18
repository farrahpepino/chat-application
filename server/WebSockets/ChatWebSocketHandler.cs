using System.Net.WebSockets;
using System.Text;
using System.Collections.Concurrent; // LEARN

namespace server.WebSockets
{
    public static class ChatWebSocketHandler{
        // Store connected users (userId → WebSocket)
        private static readonly ConcurrentDictionary<String, WebSocket> _connections = new();


        public static async Task HandleAsync(HttpContext context){
            if(context.WebSockets.IsWebSocketRequest){
                var userId = context.Request.Query["userId"];
                if (string.IsNullOrEmpty(userId))
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Missing userId");
                    return;
                }

                using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                _connections[userId] = webSocket;
                Console.WriteLine($"WebSocket connected: {userId}");

                await ReceiveMessagesAsync(userId, webSocket);
            }
            
            else{
                context.Response.StatusCode = 400;
            }
        }
        
        private static async Task ReceiveMessagesAsync(string userId, WebSocket socket)
        {
            var buffer = new byte[1024 * 4];

            while (socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    _connections.TryRemove(userId, out _);
                    await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by user", CancellationToken.None);
                    Console.WriteLine($"WebSocket closed: {userId}");
                }
            }
        }

        public static async Task SendMessageToUserAsync(string userId, string message)
        {
            if (_connections.TryGetValue(userId, out var socket) && socket.State == WebSocketState.Open)
            {
                var bytes = Encoding.UTF8.GetBytes(message);
                await socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}