﻿using Microsoft.AspNetCore.SignalR;

namespace WebApplication2
{
    public class ChatHub:Hub
    {
        public async Task Send(string message, string userName)
        {
            await Clients.All.SendAsync("Receive", message, userName);
        }
    }
}
