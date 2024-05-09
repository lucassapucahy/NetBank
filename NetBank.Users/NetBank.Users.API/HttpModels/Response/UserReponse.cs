using NetBank.Users.Domain.Entities;
using NetBank.Users.Domain.Enums;

namespace NetBank.Users.API.HttpModels.Response
{
    public class UserReponse
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool Status { get; set; }
        public long DocumentNumber { get; set; }
        public RequestType RequestType { get; set;  }
        public AddressResponse? Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdate { get; set; }

        public static UserReponse BuildFromDomain(User user) 
        {
            return new UserReponse
            {
                Id = user.Id,
                Name = user.Name,
                BirthDate = user.BirthDate,
                Email = user.Email,
                Phone = user.Phone,
                Address = AddressResponse.BuildFromDomain(user.Address!),
                CreatedAt = user.CreatedAt,
                LastUpdate = user.LastUpdate,
                DocumentNumber = user.DocumentNumber,
                RequestType = user.RequestType
            };
        }
    }
}
