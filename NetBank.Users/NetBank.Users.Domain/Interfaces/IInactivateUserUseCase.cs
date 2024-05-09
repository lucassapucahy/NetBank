using NetBank.SharedPackages.Model;
using NetBank.Users.Domain.Entities;

namespace NetBank.Users.Domain.Interfaces
{
    public interface IInactivateUserUseCase
    {
        public Task<DomainResult<User>> Execute(long userId);
    }
}
