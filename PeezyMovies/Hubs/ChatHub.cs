namespace PeezyMovies.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using PeezyMovies.Core.Models;

    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

    }
}
