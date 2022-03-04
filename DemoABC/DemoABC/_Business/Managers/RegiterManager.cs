using DemoABC.Base;
using DemoABC.Dtos;
using DemoABC.EntityFramework.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoABC.Business.Managers
{
    public class RegiterManager
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger _logger;

        public RegiterManager(
            UserManager<User> userManager,
            ILoggerFactory loggerFactory
        )
        {
            _userManager = userManager;
            _logger = loggerFactory.CreateLogger<RegiterManager>();
        }

        public async Task<IdentityResult> RegisterAsync(RegisterUserInputDto input)
        {
            var entity = input.JsonMapTo<User>();

            entity.PasswordHash = new PasswordHasher<User>().HashPassword(entity, input.Password);

            var result = await _userManager.CreateAsync(entity);

            return result;
        }

    }
}
