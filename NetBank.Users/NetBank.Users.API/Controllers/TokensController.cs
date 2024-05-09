using Microsoft.AspNetCore.Mvc;
using NetBank.Users.API.Util.JWT;
using NetBank.Users.Domain.Interfaces;

namespace NetBank.Users.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly ILoginUsecase _login;
        private readonly IConfiguration _configurationManager;

        public TokensController(ILoginUsecase login, IConfiguration configurationManager)
        {
            _login = login;
            _configurationManager = configurationManager;
        }

        [HttpPost(Name = "GenerateToken")]
        public async Task<IActionResult> Post(long documentId, string password)
        {
            var result = await _login.Execute(documentId, password);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(TokenGenerator.GenerateJWTToken(result.ResultObject!, _configurationManager));
        }
    }
}
