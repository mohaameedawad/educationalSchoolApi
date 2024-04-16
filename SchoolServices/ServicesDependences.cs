using Microsoft.Extensions.DependencyInjection;
using SchoolServices.Interfaces;
using SchoolServices.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolServices
{
    public static class ServicesDependences
    {
        public static IServiceCollection AddServicesDependencies (this IServiceCollection services)
        {
            services.AddTransient<IstudentService, studentService> ();

            return services;
        }
    }
}
