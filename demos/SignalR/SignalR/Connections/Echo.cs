using System.Threading.Tasks;
using SignalR;

namespace SignalRDemos.Connections
{
    public class Echo : SignalR.PersistentConnection
    {        
        protected override Task OnReceivedAsync(IRequest request, string connectionId, string data)
        {
            return Connection.Broadcast(data);
        }
    }
}