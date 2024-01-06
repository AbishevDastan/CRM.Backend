//using Domain;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace Application.AuthenticationHandlers.JwtManager
//{
//    public class JwtManager : IJwtManager
//    {
//        private readonly IConfiguration _configuration;

//        public JwtManager(IConfiguration configuration)
//        {
//            _configuration = configuration;

//        }
//        public string GenerateJwtToken(Admin admin)
//        {
//            List<Claim> claims = new List<Claim>
//            {
//               new Claim(ClaimTypes.Name, admin.Id.ToString()),
//               new Claim(ClaimTypes.Role, admin.Role),
//               new Claim(ClaimTypes.Email, admin.Email)
//            };

//            var secret = Encoding.UTF8.GetBytes(_configuration.GetSection("ApplicationSettings:Secret").Value);
//            var key = new SymmetricSecurityKey(secret);

//            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
//            var token = new JwtSecurityToken
//                (
//                    claims: claims,
//                    signingCredentials: credentials,
//                    expires: DateTime.Now.AddHours(12)
//                );

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }
//    }
//}
