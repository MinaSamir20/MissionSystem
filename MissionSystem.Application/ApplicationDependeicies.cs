using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MissionSystem.Application.Behaviors;
using MissionSystem.Application.Services;
using MissionSystem.Infrastructure.Services;
using System.Reflection;

namespace MissionSystem.Application
{
    public static class ApplicationDependeicies
    {
        public static IServiceCollection AddApplicationDependeicies(this IServiceCollection services)
        {
            services.AddTransient<AuthService>();
            services.AddTransient<GovernmentService>();
            services.AddTransient<FileService>();

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
