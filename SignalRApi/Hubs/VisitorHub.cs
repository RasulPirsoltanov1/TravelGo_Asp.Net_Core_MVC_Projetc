using Microsoft.AspNetCore.SignalR;
using SignalRApi.Model;

namespace SignalRApi.Hubs
{
    public class VisitorHub:Hub
    {
        private readonly VisitorService _visitorService;

        public VisitorHub(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }
        public async Task SendVisitorList()
        {
            await Clients.All.SendAsync("ReceiveList", _visitorService.GetVisitorCharts());
        }
    }
}
