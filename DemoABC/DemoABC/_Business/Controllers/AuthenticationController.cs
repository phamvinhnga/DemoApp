using DemoABC.Base;
using DemoABC.Business.Managers;
using DemoABC.Dtos;
using DemoABC.EntityFramework.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DemoABC.Business.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TestController : ControllerBase
    {
        [HttpPost]
        public IActionResult Abc()
        {
            if (true)
            {
                return BadRequest("a");
            }
        }
    }

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly TokenManager _tokenManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RegiterManager _regiterManager;
        private readonly ILogger _logger;

        public AuthenticationController(
            SignInManager<User> signInManager,
            RegiterManager regiterManager,
            TokenManager tokenManager,
            ILoggerFactory loggerFactory
        )
        {
            _tokenManager = tokenManager;
            _signInManager = signInManager;
            _regiterManager = regiterManager;
            _logger = loggerFactory.CreateLogger<AuthenticationController>();
        }

        [HttpPost]
        public async Task<ActionResult<AuthenticateOutputDto>> LoginAsync([FromBody] AuthenticateDto input)
        {
            var result = await _signInManager.PasswordSignInAsync(input.UserName, input.Password, false, lockoutOnFailure: true);
 
            if (result.IsLockedOut)
            {
                _logger.LogWarning("User account locked out.");
                return null;
            }

            if (!result.Succeeded)
            {
                _logger.LogWarning("Incorrect account or password");
                return null;
            }

            var output = await _tokenManager.BuildToken(input.UserName);

            _logger.LogInformation(1, "User logged in.");

            return output;
        }

        [HttpPost]
        public async Task<ActionResult<RegisterUserOutputDto>> RegisterAsync([FromBody] RegisterUserInputDto input)
        {
            var result = await _regiterManager.RegisterAsync(input);
            
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    _logger.LogWarning(item.Description);
                }
                throw new Exception();
            }

            return result.JsonMapTo<RegisterUserOutputDto>();
        }
    }
  
}
