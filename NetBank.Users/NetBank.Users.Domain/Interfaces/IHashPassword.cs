namespace NetBank.Users.Domain.Interfaces
{
    public interface IHashPassword
    {
        (string password, string salt) GenerateHash(string password);
        string GenerateHash(string password, string salt);
    }
}
