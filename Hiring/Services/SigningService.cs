using Hiring.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hiring.Services
{
    public class SigningService
    {
        private readonly Jwt _jwt;

        public SigningService(Jwt jwt)
        {
            _jwt = jwt;
        }
        protected string generateToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwt.Issuer,
                Audience = _jwt.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SigningKey))
                , SecurityAlgorithms.HmacSha256Signature),
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    //new (ClaimTypes.Name,user.name),
                    //new (ClaimTypes.Email,user.email),
                    new(ClaimTypes.NameIdentifier,userId.ToString()),
                }) ,
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(securityToken);
            return accessToken;
        }
        protected string hashPassword(string passord)
        {
            return BCrypt.Net.BCrypt.HashPassword(passord);
        }
        protected bool verifyPassword(string password,string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password,hashPassword);
        }
        
    }
}
