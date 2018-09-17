using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace RemoteController.Web.Hubs
{
    public class MachineHub : Hub
    {
        private static readonly HubMannager<string> Connections =
            new HubMannager<string>();

        public async Task SendCommand(List<string> clients, string command)
        {
            await Clients.Users(clients).SendAsync("ExecuteCommand", command);
        }

        //public override async Task OnConnectedAsync()
        //{
        //    var name = Context.User.Identity.Name;

        //    Connections.Add(name, Context.ConnectionId);

        //    await base.OnConnectedAsync();
        //}

        //public override async Task OnDisconnectedAsync(Exception exception)
        //{
        //    string name = Context.User.Identity.Name;

        //    Connections.Remove(name, Context.ConnectionId);

        //    await base.OnDisconnectedAsync(exception);
        //}
    }
}
