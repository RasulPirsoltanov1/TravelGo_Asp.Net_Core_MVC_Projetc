using BusinessLayer.CQRS.Commands.DestinationCommands;
using DataAccessLayer.Concrete.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task Handle(UpdateDestinationCommand updateDestinationCommand)
        {
            var dest = await _context.Destinations.FindAsync(updateDestinationCommand.Id);

            if (dest != null)
            {
                dest.Price = updateDestinationCommand.Price;
                dest.City = updateDestinationCommand.City;
                dest.DayNight = updateDestinationCommand.DayNight;
                await _context.SaveChangesAsync();
            }
        }

    }
}
