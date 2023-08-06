using BusinessLayer.CQRS.Commands.DestinationCommands;
using DataAccessLayer.Concrete.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Handlers.DestinationHandlers
{
    public class DeleteDestinationCommandHandler
    {
        private Context _context;

        public DeleteDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveDestinationCommand removeDestinationCommand)
        {
            var destination = _context.Destinations.Find(removeDestinationCommand.Id);
            if (destination != null)
            {
                _context.Destinations.Remove(destination);
                _context.SaveChanges();
            }
        }
    }
}
