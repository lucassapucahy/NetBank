using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetBank.Users.API.HttpModels.Request;
using NetBank.Users.API.HttpModels.Response;
using NetBank.Users.Domain.Interfaces;

namespace NetBank.Users.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly INewUserUseCase _newUserUseCase;
        private readonly IInactivateUserUseCase _inactivateUserUseCase;
        private readonly IUserRepository _userRepository;
        public UserController(INewUserUseCase newUserUseCase, IInactivateUserUseCase inactivateUserUseCase, ILogger<UserController> logger,
            IUserRepository userRepository)
        {
            _logger = logger;
            _newUserUseCase = newUserUseCase;
            _inactivateUserUseCase = inactivateUserUseCase;
            _userRepository = userRepository;
        }
        [Authorize]
        [HttpGet("{documentNumber}")]
        public async Task<IActionResult> Get(long documentNumber)
        {
            var user = await _userRepository.GetByPropEager(x => x.DocumentNumber == documentNumber, z=> z.Address);

            if (user == null) 
            {
                _logger.LogInformation("User not found");
                return NotFound();
            }

            return Ok(UserReponse.BuildFromDomain(user!));
        }

        [Authorize]
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var users = await _userRepository.GetAllEager(x => x.Address);

            return Ok(users.Select(x => UserReponse.BuildFromDomain(x!)));
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<IActionResult> Post(UserRequest user)
        {
            var domainResult = await _newUserUseCase.Execute(user.ToDomain());

            if (!domainResult.Success) 
            {
                _logger.LogError("Failed to create a new User for object. Payload:{User} Message:{ErrorMessages}", 
                    user, string.Join(";", domainResult.ErrorMessages!));

                return BadRequest(domainResult);
            }

            return Created($"/user/{domainResult.ResultObject!.Id}", UserReponse.BuildFromDomain(domainResult.ResultObject));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var domainResult = await _inactivateUserUseCase.Execute(id);

            if (!domainResult.Success)
            {
                _logger.LogError("Failed to inactivate the User for object. Id:{id} Message:{ErrorMessages}",
                    id, string.Join(";", domainResult.ErrorMessages!));

                return BadRequest(domainResult);
            }

            return Ok();
        }
    }
}