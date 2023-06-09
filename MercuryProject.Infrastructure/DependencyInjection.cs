using MercuryProject.Application.Common.Interfaces.Authentication;
using MercuryProject.Application.Common.Interfaces.Persistence;
using MercuryProject.Application.Common.Interfaces.Services;
using MercuryProject.Infrastructure.Authentication;
using MercuryProject.Infrastructure.Persistence;
using MercuryProject.Infrastructure.Persistence.Repositories;
using MercuryProject.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MercuryProject.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure
            (this IServiceCollection services, ConfigurationManager builderConfiguration)
        {
            services.AddAuth(builderConfiguration)
                .AddPersistence(builderConfiguration);
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddHttpContextAccessor();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, ConfigurationManager builderConfiguration)
        {
            services.AddDbContext<MercuryProjectDbContext>(options => options.UseSqlServer(builderConfiguration["ConnectionStrings:DefaultConnection"]));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IIdeaRepository, IdeaRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
            return services;
        }

        public static IServiceCollection AddAuth
            (this IServiceCollection services, ConfigurationManager builderConfiguration)
        {
            var jwtSettings = new JwtSettings();
            builderConfiguration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            var hashSettings = new HashSettings();
            builderConfiguration.Bind(HashSettings.SectionName, hashSettings);

            services.AddSingleton(Options.Create(hashSettings));

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });

            return services;
        }
    }
}
