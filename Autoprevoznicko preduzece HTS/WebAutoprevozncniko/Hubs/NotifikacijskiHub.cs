using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAutoprevozncniko.Hubs
{
    public class NotifikacijskiHub : Hub
    {
        public static void Show()
        {
        }
        public async Task Send (string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
