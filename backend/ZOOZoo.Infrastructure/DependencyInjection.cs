using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZOOZoo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<ZooDbContext>(options =>
                options.UseNpgsql(connectionString));
            // Здесь зарегистрируем реализации репозиториев:
            // services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            return services;
        }
    }
}
