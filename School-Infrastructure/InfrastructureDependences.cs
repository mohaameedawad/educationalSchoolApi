using Microsoft.Extensions.DependencyInjection;
using School_Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_Infrastructure.Repositories;
using School_Infrastructure.Bases;

namespace School_Infrastructure
{
    public static class InfrastructureDependences
    {
        public static IServiceCollection AddInfrastructureDependences (this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            return services;
        }
    }
}
