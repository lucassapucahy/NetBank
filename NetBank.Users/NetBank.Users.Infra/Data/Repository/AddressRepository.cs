using NetBank.SharedPackagesInfra.Repository;
using NetBank.Users.Domain.Entities;
using NetBank.Users.Domain.Interfaces;
using NetBank.Users.Infra.Data.Context;

namespace NetBank.Users.Infra.Data.Repository
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(UsersContext context) : base(context)
    {
    }
}
}
