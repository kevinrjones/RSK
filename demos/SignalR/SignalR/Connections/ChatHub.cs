using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using SignalR.Hubs;

namespace SignalRDemos.Connections
{
    public class ChatHub : Hub
    {
        public void Say(string message)
        {
            Clients.newMessage(message);
        }

        public Task<string> GetLastMessage()
        {
            return Task.Factory.StartNew(() =>
            {
                // Don't do this in the real world
                Thread.Sleep(3000);
                return "No message";
            });

        }
    }
}