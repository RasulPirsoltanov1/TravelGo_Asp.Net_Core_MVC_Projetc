using BusinessLayer.CQRS.Results.ContactUsResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Commands.ContactUsCommands
{
    public class ConatctUsCreateCommand: IRequest<ContactUsCreateResult>
    {
        public string? Name { get; set; }
        public string? Subject { get; set; }
        public string? MessageBody { get; set; }
        public DateTime? MessageDate { get; set; }
        public string? Mail { get; set; }
        public bool? MessageStatus { get; set; }
    }
}
