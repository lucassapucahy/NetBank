using NetBank.Users.Domain.Interfaces;

namespace NetBank.Users.Infra.Encrypt
{
    public class HashPassword : IHashPassword
    {
        public (string password, string salt) GenerateHash(string password) 
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            return (BCrypt.Net.BCrypt.HashPassword(password, salt), salt);
        }

        public string GenerateHash(string password, string salt)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }
    }
}
