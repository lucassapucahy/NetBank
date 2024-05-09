using NetBank.Users.Domain.Entities;

namespace NetBank.Users.API.HttpModels.Response
{
    public class AddressResponse
    {
        public string? Street { get; set; }
        public int Number { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }

        public static AddressResponse BuildFromDomain(Address address) 
        {
            return new AddressResponse
            {
                Street = address.Street,
                Number = address.Number,
                City = address.City,
                State = address.State,
                Country = address.Country,
                ZipCode = address.ZipCode
            };
        }
    }
}
