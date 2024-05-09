using NetBank.SharedPackages.Model;
using NetBank.Users.Domain.Entities;

namespace NetBank.Users.Domain.Interfaces
{
    public interface INewUserUseCase
    {
        public Task<DomainResult<User>> Execute(User user);
    }
}
