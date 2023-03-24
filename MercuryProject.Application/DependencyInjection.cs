﻿using System.Reflection;
using ErrorOr;
using FluentValidation;
using MediatR;
using MercuryProject.Application.Authentication.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace MercuryProject.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
