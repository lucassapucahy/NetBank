using Microsoft.Extensions.DependencyInjection;
using NetBank.Users.Domain.Interfaces;
using NetBank.Users.Domain.UseCases;

namespace NetBank.Users.Infra.DI
{
    public static class DomainDI
    {
        public static IServiceCollection InjectDomainDependencies(this IServiceCollection services)
        {
            services
                .AddScoped<IInactivateUserUseCase, InactivateUserUseCase>()
                .AddScoped<INewUserUseCase, NewUserUseCase>()
                .AddScoped<ILoginUsecase, LoginUsecase>();
                
            return services;
        }
    }
}
