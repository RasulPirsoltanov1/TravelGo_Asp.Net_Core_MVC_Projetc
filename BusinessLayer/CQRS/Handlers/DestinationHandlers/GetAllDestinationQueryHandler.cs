using BusinessLayer.CQRS.Results.Destinations;
using DataAccessLayer.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Handlers.DestinationHandlers
{

    public class GetAllDestinationQueryHandler
    {
        private Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<List<GetAllDestinationQueryResult>> Handler()
        {
            var result = await _context.Destinations.Select(d => new GetAllDestinationQueryResult
            {
                Capacity = d.Capacity,
                City = d.City,
                DayNight = d.DayNight,
                Id = d.DestinationId,
                Price = d.Price
            }).ToListAsync();
            return result;
        }
    }
}
