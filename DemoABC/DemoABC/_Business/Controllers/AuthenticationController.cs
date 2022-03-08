using DemoABC.Base;
using DemoABC.Base.interfaces;
using DemoABC.Business.Managers;
using DemoABC.Dtos;
using DemoABC.EntityFramework.Entities;
using DemoABC.Exceptions;
using DemoABC.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Threading.Tasks;

namespace DemoABC.Business.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class TestController : ControllerBase
    {
        private readonly IRepository<Organization, Guid> _repository;

        public TestController(IRepository<Organization, Guid> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [NotAllowSpecialCharacters("CodeValue")]
        public IActionResult Abc([FromBody] OrganizationInputDto input)
        {
            var p = User;
            return null;
        }
    }

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly TokenManager _tokenManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RegiterManager _regiterManager;

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
        }

        [HttpPost]
        public async Task<ActionResult<AuthenticateOutputDto>> LoginAsync([FromBody] AuthenticateDto input)
        {
            var result = await _signInManager.PasswordSignInAsync(input.UserName, input.Password, false, lockoutOnFailure: true);

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    throw new LoginException("User account locked out.");
                }

                throw new LoginException("Incorrect account or password");
            }
            
            var output = await _tokenManager.BuildToken(input.UserName);

            Log.Information("User logged in.");

            return output;
        }

        [HttpPost]
        public async Task<ActionResult<RegisterUserOutputDto>> RegisterAsync([FromBody] RegisterUserInputDto input)
        {
            var result = await _regiterManager.RegisterAsync(input);
            
            if (!result.Succeeded)
            {
                throw new RegisterException(result.Errors.ConvertToJson());
            }

            return result.JsonMapTo<RegisterUserOutputDto>();
        }
    }
  
}
