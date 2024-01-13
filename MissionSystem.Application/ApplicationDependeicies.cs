using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MissionSystem.Application.Behaviors;
using MissionSystem.Application.Services;
using MissionSystem.Infrastructure.Services;
using MediatR;

namespace MissionSystem.Application
{
    public static class ApplicationDependeicies
    {
        public static IServiceCollection AddApplicationDependeicies(this IServiceCollection services)
        {
            services.AddTransient<AuthService>();
            services.AddTransient<GovernmentService>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
