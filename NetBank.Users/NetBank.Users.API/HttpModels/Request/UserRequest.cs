using NetBank.Users.Domain.Entities;
using NetBank.Users.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace NetBank.Users.API.HttpModels.Request
{
    public class UserRequest
    {
        [Required]
        [MinLength(20), MaxLength(255)]
        public string? Name { get; set; }
        [Range(typeof(DateTime), "1900/01/01", "9999/12/31", ErrorMessage = "Date must be after 1900/01/01")]
        public DateTime BirthDate { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public long DocumentNumber { get; set; }
        [Phone]
        public string? Phone { get; set; }
        [Required]
        public RequestType RequestType { get; set; }
        [Required]
        public AddressRequest? Address { get; set; }
        [Required]
        public string Password { get; set; }

        public User ToDomain() 
        {
            return new User()
            {
                Name = Name,
                BirthDate = BirthDate,
                Email = Email,
                Phone = Phone,
                RequestType = RequestType,
                DocumentNumber = DocumentNumber,
                Address = Address!.ToDomain(),
                Password = Password,
                Status = true
            };
        }

    }
}
