using MercuryProject.API.Common.Mapping;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace MercuryProject.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            //JsonSerializerOptions options = new()
            //{
            //    ReferenceHandler = ReferenceHandler.Preserve,
            //    WriteIndented = true,
            //    MaxDepth = 64
            //};
            services.AddMappings();
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
