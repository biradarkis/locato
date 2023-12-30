using InfraStructure.Services.Interfaces;
using Locato.Data.Entities.UserEntities;
using Shared.helpers;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Locato.Infrastructure.Services.Implementations
{
    public class JwtHandler : IJwtHandler
    {
        private readonly AppSettings _appSettings;
        public JwtHandler(AppSettings appSettings)
        {
            _appSettings = appSettings; 
        }
        public string GenerateJwtRefreshToken(User user, int expiresInHours = 720)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.RefreshSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("id", user.Id.ToString(), ClaimValueTypes.Integer64),
                    new Claim("date", DateTimeOffset.UtcNow.ToString(), ClaimValueTypes.DateTime),
                }),
                Expires = DateTime.UtcNow.AddHours(expiresInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public string GenerateJwtToken(User user, int expiresInHours = 12)
        {
            var handler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject =  new ClaimsIdentity(
                    new []
                    {
                        new Claim("id" , user.Id.ToString(), ClaimValueTypes.Integer64),
                        new Claim("orgid" , user.OrganizationId.ToString() , ClaimValueTypes.Integer64),
                        new Claim("role" ,user.RoleId.ToString(), ClaimValueTypes.String),
                    }),
                Expires = DateTime.UtcNow.AddHours(expiresInHours),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
        
    }
}
