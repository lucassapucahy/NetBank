using Microsoft.Extensions.Logging;
using NetBank.SharedPackages.Model;
using NetBank.Users.Domain.Entities;
using NetBank.Users.Domain.Interfaces;

namespace NetBank.Users.Domain.UseCases
{
    public class NewUserUseCase : INewUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<NewUserUseCase> _logger;
        private readonly IHashPassword _hash;

        public NewUserUseCase(IUserRepository userRepository, ILogger<NewUserUseCase> logger, IHashPassword hash)
        {
            _userRepository = userRepository;
            _logger = logger;
            _hash = hash;
        }

        public async Task<DomainResult<User>> Execute(User user)
        {
            if (!user.IsFullAge())
            {
                var failureMsg = "User is not Full Age";
                _logger.LogInformation(failureMsg);
                return DomainResult<User>.CreateFailure(new List<string> { failureMsg });
            }

            var alreadyExists = (await _userRepository.GetByProp(x => x.DocumentNumber == user.DocumentNumber)) != null;

            if (alreadyExists)
            {
                var failureMsg = "Already exists an user with this Document Number";
                _logger.LogInformation(failureMsg);
                return DomainResult<User>.CreateFailure(new List<string> { failureMsg });
            }

            (user.Password, user.Salt) = _hash.GenerateHash(user.Password);

            var createdUser = await _userRepository.Insert(user);

            await _userRepository.SaveChanges();

            //send message to others services

            return DomainResult<User>.CreateSuccess(createdUser);

        }
    }
}
