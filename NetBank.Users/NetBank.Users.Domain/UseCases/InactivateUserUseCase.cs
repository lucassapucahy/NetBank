using Microsoft.Extensions.Logging;
using NetBank.SharedPackages.Model;
using NetBank.Users.Domain.Entities;
using NetBank.Users.Domain.Interfaces;

namespace NetBank.Users.Domain.UseCases
{
    public class InactivateUserUseCase : IInactivateUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<InactivateUserUseCase> _logger;

        public InactivateUserUseCase(IUserRepository userRepository, ILogger<InactivateUserUseCase> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<DomainResult<User>> Execute(long userId)
        {
            var user = await _userRepository.GetByDocumentId(userId);

            if (user == null || !user.Status) 
            {
                _logger.LogInformation("User: {userId} dont exist or is already inactivate", userId);
                return DomainResult<User>.CreateSuccess(new User());  
            }

            user.Status = false;
            _userRepository.Update(user);

            //send message to others services

            return DomainResult<User>.CreateSuccess(user);
        }

    }
}
