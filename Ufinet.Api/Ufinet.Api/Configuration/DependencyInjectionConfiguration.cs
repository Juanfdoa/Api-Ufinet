using Ufinet.Contracts.Interfaces.Repositories;
using Ufinet.Contracts.Interfaces.Services;
using Ufinet.Core.Services;
using Ufinet.Infrastructure.Repositories;

namespace Ufinet.Api.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependecyInjectionConfiguration(this IServiceCollection services)
        {
            #region Repositories
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            #endregion

            #region Services
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IHotelService, HotelService>();
            #endregion

            return services;
        }
    }
}
