using EmailSenderApp.Domain.Entites.AuthModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Globalization;
using System.Text.Json;

namespace EmailSenderApp.Application.Services.AutServices
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateToken(User user)
        {
            if(user == null)
            {
                return "User not found";
            }
            if(await UserExist(user))
            {
                var permissionIds=new List<int>();
                if (user.Role == "Teacher") permissionIds=new List<int>() { 1,2,3,4};
                else if(user.Role =="Student")permissionIds=new List<int>() { 3,4,5,6};
                else if(user.Role =="Manager")permissionIds=new List<int>() { 1,2,3,4,5,6,7,8,9,10};

                var jsonContent=JsonSerializer.Serialize(permissionIds);

                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Role,user.Role),
                    new Claim("UserName",user.Name),
                    new Claim("UserId",user.Id.ToString()),
                    new Claim("CreatedDate",DateTime.UtcNow.ToString()),
                    new Claim("Permissions",jsonContent)
                };
                return  await GenerateToken(claims);
            }
            else
            {
                return "User UnAuthorite";
            }
        }

        public async Task<string> GenerateToken(IEnumerable<Claim> additionalClaims)
        {
            var secirutyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretCode"]));
            var credentials = new SigningCredentials(secirutyKey, SecurityAlgorithms.HmacSha256);

            var expireInMinutes = Convert.ToInt64(_configuration["JWT:ExpireDate"] ?? "10");

            var claims=new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64)
            };
            if (additionalClaims.Any() == true)
                claims.AddRange(additionalClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expireInMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<bool> UserExist(User user)
        {
            var login = "elyor";
            var password = "1234";
            if(user.Password == password && user.Login==login) 
            {
                return true;
            }
            return false;
        }
    }
}
