using NetBank.Users.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace NetBank.Users.API.HttpModels.Request
{
    public class AddressRequest
    {
        [Required]
        [MaxLength(255)]
        public string? Street { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        [MaxLength(100)]
        public string? City { get; set; }
        [Required]
        [MaxLength(100)]
        public string? State { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Country { get; set; }
        [Required]
        [RegularExpression(@"^\d{5}(-\d{3})?$", ErrorMessage = "Invalid Zip Code")]
        public string? ZipCode { get; set; }

        public Address ToDomain()
        {
            return new Address
            {
                Street = Street,
                Number = Number,
                City = City,
                State = State,
                Country = Country,
                ZipCode = ZipCode
            };
        }
    }
}
