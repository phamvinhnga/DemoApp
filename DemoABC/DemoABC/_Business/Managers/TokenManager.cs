using DemoABC.Dtos;
using DemoABC.EntityFramework.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace DemoABC.Business.Managers
{
    public class TokenManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public TokenManager(
            IConfiguration configuration,
            UserManager<User> userManager
        )
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<AuthenticateOutputDto> BuildToken(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var credsKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Authentication:JwtBearer:SecurityKey").Value));

            var creds = new SigningCredentials(credsKey, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddDays(int.Parse(_configuration.GetSection("Authentication:JwtBearer:Expires").Value));

            var token = new JwtSecurityToken(
                issuer: _configuration.GetSection("Authentication:JwtBearer:Issuer").Value,
                audience: _configuration.GetSection("Authentication:JwtBearer:Audience").Value,
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new AuthenticateOutputDto()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                Expire = (DateTime?)expires
            };
        }
    }
}
