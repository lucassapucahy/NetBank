using NetBank.SharedPackages.Model;
using NetBank.Users.Domain.Entities;

namespace NetBank.Users.Domain.Interfaces
{
    public interface ILoginUsecase
    {
        Task<DomainResult<User>> Execute(long documentId, string password);
    }
}
