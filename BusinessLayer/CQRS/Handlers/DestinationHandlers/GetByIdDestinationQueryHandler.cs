using BusinessLayer.CQRS.Queries.Destinations;
using BusinessLayer.CQRS.Results.Destinations;
using DataAccessLayer.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.CQRS.Handlers.DestinationHandlers
{
    public class GetByIdDestinationQueryHandler
    {
        private Context _context;

        public GetByIdDestinationQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<GetByIdDestinationQueryResult> Handler(GetByIdDestinationQuery getByIdDestinationQuery)
        {
            var result = await _context.Destinations.Select(d => new GetByIdDestinationQueryResult
            {
                City = d.City,
                DayNight = d.DayNight,
                Id = d.DestinationId,
            }).FirstOrDefaultAsync(d => d.Id== getByIdDestinationQuery.Id);
            return result;
        }
    }
}
