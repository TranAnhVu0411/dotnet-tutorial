using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationDemo
{
    public static class OptionsCollectionExtensions
    {
        public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseOption>(configuration.GetSection(DatabaseOption.SectionName));
            services.Configure<DatabaseOption>(DatabaseOption.SystemDatabaseSectionName, configuration.GetSection($"{DatabaseOption.SectionName}:{DatabaseOption.SystemDatabaseSectionName}"));
            services.Configure<DatabaseOption>(DatabaseOption.BusinessDatabaseSectionName, configuration.GetSection($"{DatabaseOption.SectionName}:{DatabaseOption.BusinessDatabaseSectionName}"));
            return services;
        }
    }
}