using MrgUserRegistration.DataAccess.Repositories;
using MrgUserRegistration.DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MrgUserRegistration.DataAccess.DependencyInjection
{

    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
