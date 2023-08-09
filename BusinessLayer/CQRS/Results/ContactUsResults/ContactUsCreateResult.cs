using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CQRS.Results.ContactUsResults
{
    public class ContactUsCreateResult
    {
        public bool IsSuccess { get; set; } = false;
    }
}
