using BusinessLayer.CQRS.Handlers.DestinationHandlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Registrations
{
    public static class ServiceRegistration
    {
        public static void AddServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<GetAllDestinationQueryHandler>();
            services.AddScoped<GetByIdDestinationQueryHandler>();
            services.AddScoped<CreateDestinationCommandHandler>();
            services.AddScoped<DeleteDestinationCommandHandler>();
            services.AddScoped<UpdateDestinationCommandHandler>();
        }
    }
}
