using BusinessLayer.CQRS.Results.GuideResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Commands.DestinationCommands
{
    public class UpdateDestinationCommand
    {
        public int Id { get; set; }
        public string City { get; set; }
        public double Price { get; set; }
        public string DayNight { get; set; }
    }
}
