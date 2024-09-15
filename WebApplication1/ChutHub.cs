using Microsoft.AspNetCore.Authorization; // для атрибута Authorize
using Microsoft.AspNetCore.SignalR;

namespace WebApplication1
{
    [Authorize]
    public class ChatHub : Hub
    {
        public async Task Send(string message, string to)
        {
            // получение текущего пользователя, который отправил сообщение
            //var userName = Context.UserIdentifier;
            if (Context.UserIdentifier is string userName)
            {
                await Clients.Users(to, userName).SendAsync("Receive", message, userName);
            }
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Notify", $"Приветствуем {Context.UserIdentifier}");
            await base.OnConnectedAsync();
        }
    }
}