using Microsoft.IdentityModel.Tokens;
using petro_home_back.Data.Advice.Exceptions;
using petro_home_back.Model.Base;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace petro_home_back.Data.Security
{
    public class JwtTokenProvider
    {
        private readonly string _secretKey;
        private readonly long _tokenValidDay = 1;

        public JwtTokenProvider(IConfiguration config)
        {
            _secretKey = config["Jwt:SecretKey"];
        }

        public string CreateToken(UserModel user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.id),
                new Claim(JwtRegisteredClaimNames.Name, user.nm),
                new Claim(ClaimTypes.Role, "ADMIN"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(_tokenValidDay), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public JwtSecurityToken GetAuthentication(string token)
        {
            var readToken = new JwtSecurityTokenHandler().ReadToken(token);
            if (readToken == null)
            {
                throw new AccessDeniedException();
            }

            return readToken as JwtSecurityToken ?? throw new AccessDeniedException();
        }
        public bool IsValidateToken(string token)
        {
            var auth = GetAuthentication(token);
            if (auth.ValidTo >= DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
