using Microsoft.Extensions.DependencyInjection;
using Pensions.Core.Persistence.Interfaces;
using Pensions.Core.Services;
using Pensions.Core.Services.Interfaces;
using Pensions.Persistence.Repositories;

namespace Pensions.DependencyInjection
{
    public static class DependencyInjectionExtension
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IBasicService, BasicService>();
            
            services.AddScoped<IAccrualRepository, AccrualRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IBasicRepository, BasicRepository>();
            services.AddScoped<ISalaryRepository, SalaryRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
        }
    }
}
