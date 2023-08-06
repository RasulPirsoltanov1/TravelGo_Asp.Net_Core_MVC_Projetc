using BusinessLayer.CQRS.Commands.DestinationCommands;
using DataAccessLayer.Concrete.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Handlers.DestinationHandlers
{
    public class CreateDestinationCommandHandler
    {
        private readonly Context _context;

        public CreateDestinationCommandHandler(Context context)
        {
            _context = context;
        }
        public async Task Handle(CreateDestinationCommand createDestinationCommand)
        {
            try
            {
              await  _context.Destinations.AddAsync(new EntityLayer.Concrete.Destination
                {
                    City= createDestinationCommand.City,
                    DayNight= createDestinationCommand.DayNight,
                    Capacity= createDestinationCommand.Capacity,    
                    Price= createDestinationCommand.Price,
                    Status= true,
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
