using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRApi.DAL;
using SignalRApi.Hubs;
using System.Collections;
using System.Data;

namespace SignalRApi.Model
{
    public class VisitorService
    {
        private readonly AppDbContext _appDbContext;
        private IHubContext<VisitorHub> _hubContext;

        public VisitorService(AppDbContext appDbContext, IHubContext<VisitorHub> hubContext)
        {
            _appDbContext = appDbContext;
            _hubContext = hubContext;
        }
        public IQueryable<Visitor> GetList()
        {
            return _appDbContext.Visitors.AsQueryable();
        }
        public async Task SaveVisitors(Visitor visitor)
        {
            await _appDbContext.Visitors.AddAsync(visitor);
            await _appDbContext.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("CallVisitorList", "asa");
        }
        public List<VisitorChart> GetVisitorCharts()
        {
            List<VisitorChart> visitorCharts = new List<VisitorChart>();
            using (var command = _appDbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "select * from Visitors";
                command.CommandType = CommandType.Text;
                _appDbContext.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VisitorChart visitorChart = new VisitorChart();
                        visitorChart.VisitDate = reader.GetDateTime(0).ToShortDateString();
                        Enumerable.Range(1, 5).ToList().ForEach(Range =>
                        {
                            visitorChart.Count.Add(Range);
                        });
                        visitorCharts.Add(visitorChart);
                    }
                    _appDbContext.Database.CloseConnection();
                    return visitorCharts;
                }
            }
        }
    }
}
