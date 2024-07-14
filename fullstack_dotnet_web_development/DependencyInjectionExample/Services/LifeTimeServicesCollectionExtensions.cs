using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionExample.Services.Interfaces;

namespace DependencyInjectionExample.Services
{
    public static class LifeTimeServicesCollectionExtensions
    {
        public static IServiceCollection AddLifeTimeServices(this IServiceCollection services)
        {
            services.AddScoped<IScopedService, ScopedService>();
            services.AddTransient<ITransientService, TransientService>();
            services.AddSingleton<ISingletonService, SingletonService>();
            return services;
        }
    }
}