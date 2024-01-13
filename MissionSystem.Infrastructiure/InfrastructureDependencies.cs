using Microsoft.Extensions.DependencyInjection;
using MissionSystem.Application.Contracts;
using MissionSystem.Infrastructiure.Repositories.CoordinatorRepository;
using MissionSystem.Infrastructiure.Repositories.SchoolRepository;
using MissionSystem.Infrastructure.Generic;
using MissionSystem.Infrastructure.Repositories.CategoryRepository;
using MissionSystem.Infrastructure.Repositories.GovernmentRepository;
using MissionSystem.Infrastructure.Repositories.MissionRepository;

namespace MissionSystem.Infrastructure
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IGovernmentRepository, GavernmentRepository>();
            services.AddTransient<ISchoolRepository, SchoolRepository>();
            services.AddTransient<ICoordinatorRepository, CoordinatorRepository>();
            services.AddTransient<IMissionRepository, MissionRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            return services;
        }
    }
}
