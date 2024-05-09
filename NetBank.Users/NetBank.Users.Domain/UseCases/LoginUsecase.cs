using Microsoft.Extensions.Logging;
using NetBank.SharedPackages.Model;
using NetBank.Users.Domain.Entities;
using NetBank.Users.Domain.Interfaces;

namespace NetBank.Users.Domain.UseCases
{
    public class LoginUsecase: ILoginUsecase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<LoginUsecase> _logger;
        private readonly IHashPassword _hash;

        public LoginUsecase(IUserRepository userRepository, ILogger<LoginUsecase> logger, IHashPassword hash)
        {
            _userRepository = userRepository;
            _logger = logger;
            _hash = hash;
        }

        public async Task<DomainResult<User>> Execute(long documentId, string password)
        {
            var user = await _userRepository.GetByProp(x => x.DocumentNumber == documentId);

            if (user == null)
            {
                var failureMsg = "Document or Password is invalid.";
                _logger.LogInformation("document id not found on database.");
                return DomainResult<User>.CreateFailure(new List<string> { failureMsg });
            }

            var providedPassword = _hash.GenerateHash(password, user.Salt);

            if (user.Password != providedPassword)
            {
                var failureMsg = "Document or Password is invalid.";
                _logger.LogInformation("invalid password.");
                return DomainResult<User>.CreateFailure(new List<string> { failureMsg });
            }

            return DomainResult<User>.CreateSuccess(user);

        }
    }
}
