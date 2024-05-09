using NetBank.SharedPackages.Interfaces;
using NetBank.Users.Domain.Entities;

namespace NetBank.Users.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByDocumentId(long documentNumber);
    }
}
