using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZOOZoo.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Здесь зарегистрируем существующие сценарии, например:
            // services.AddScoped<IEmployeeUseCase, EmployeeUseCase>();
            return services;
        }
    }
}
