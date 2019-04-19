using MrgUserRegistration.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MrgUserRegistration.Services.DependencyInjection
{

    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();

            return services;
        }
    }
}
