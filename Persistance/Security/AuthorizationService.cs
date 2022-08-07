﻿using Application.Functions.User;
using Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Persistance.Security
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IConfiguration _configuration;
        public AuthorizationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateUserToken(string userEmail, List<string> roles)
        {
            List<Claim> userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, userEmail)
            };

            foreach (string role in roles)
            {
                userClaims.Add(new Claim(ClaimTypes.Role, role));
            }


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("SecretValidationKey").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public RefreshToken CreateRefreshToken()
        {
            var token = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Created = DateTime.Now,
                Expires = DateTime.Now.AddDays(3)
            };

            return token;
        }
    }
}
