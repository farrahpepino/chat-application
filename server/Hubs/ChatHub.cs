using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace server.Hubs {
    public class ChatHub : Hub{
        private static readonly Dictionary<string, string> _userConnections = new();

        public override async Task OnConnectedAsync()
        {
            var userId = Context.GetHttpContext()?.Request.Query["userId"];
            if (!string.IsNullOrEmpty(userId))
            {
                _userConnections[userId] = Context.ConnectionId;
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = _userConnections.FirstOrDefault(x => x.Value == Context.ConnectionId).Key;
            if (userId != null)
                _userConnections.Remove(userId);

            await base.OnDisconnectedAsync(exception);
        }

        public static string? GetConnectionId(string userId)
        {
            return _userConnections.TryGetValue(userId, out var connId) ? connId : null;
        }
    }

}
