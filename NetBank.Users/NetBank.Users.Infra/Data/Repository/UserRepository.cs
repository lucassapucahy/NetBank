using Microsoft.EntityFrameworkCore;
using NetBank.SharedPackagesInfra.Repository;
using NetBank.Users.Domain.Entities;
using NetBank.Users.Domain.Interfaces;
using NetBank.Users.Infra.Data.Context;

namespace NetBank.Users.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly UsersContext _usersContext;
        public UserRepository(UsersContext context) : base(context)
        {
            _usersContext = context;
        }

        public async Task<User?> GetByDocumentId(long documentNumber) 
        {
            return await _usersContext.Users.FirstOrDefaultAsync(x => x.DocumentNumber == documentNumber);
        }
    }
}
