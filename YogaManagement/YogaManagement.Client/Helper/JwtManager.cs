using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web;

namespace YogaManagement.Client.Helper
{
    public class JwtManager
    {
        public bool IsAuthenticated { get; set; }
        private readonly JwtSecurityToken _secureToken;
        public string JwtTokenString { get; set; } = "";

        public JwtManager(string token)
        {
            try
            {
                JwtTokenString = token;

                var handler = new JwtSecurityTokenHandler();
                _secureToken = handler.ReadJwtToken(JwtTokenString);
                IsAuthenticated = true;
            }
            catch (Exception)
            {
                IsAuthenticated = false;
            }
        }

        public string GetUserId()
            => _secureToken.Claims.Where(c => c.Type == ClaimTypes.Sid).SingleOrDefault().Value;

        public string GetUserRole()
            => _secureToken.Claims.Where(c => c.Type == ClaimTypes.Role).SingleOrDefault().Value;

        public string GetUsername()
            => _secureToken.Claims.Where(c => c.Type == ClaimTypes.Name).SingleOrDefault().Value;


        public ClaimsPrincipal GetPriciples()
        {
            var claims = new List<Claim>();
            var tokenString = "Bearer " + JwtTokenString;
            claims.Add(new Claim(ClaimTypes.Sid, GetUserId()));
            claims.Add(new Claim(ClaimTypes.Name, GetUsername()));
            claims.Add(new Claim(ClaimTypes.Role, GetUserRole()));
            claims.Add(new Claim("AuthHeader",
                tokenString));

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}
