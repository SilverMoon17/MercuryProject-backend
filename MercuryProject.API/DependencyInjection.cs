using MediatR;
using MercuryProject.API.Common.Mapping;
using MercuryProject.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace MercuryProject.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddMappings();
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
