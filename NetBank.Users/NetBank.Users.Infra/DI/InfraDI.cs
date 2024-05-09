using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetBank.Users.Domain.Interfaces;
using NetBank.Users.Infra.Data.Context;
using NetBank.Users.Infra.Data.Repository;
using NetBank.Users.Infra.Encrypt;

namespace NetBank.Users.Infra.DI
{
    public static class InfraDI
    {
        public static IServiceCollection InjectInfraDependencies(this IServiceCollection services, ConfigurationManager configuration) 
        {
            services
                .AddDbContext<UsersContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultValue")))
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IAddressRepository, AddressRepository>()
                .AddSingleton<IHashPassword, HashPassword>();

            return services;
        }
    }
}
