using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.OData.Client;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace YogaManagement.Client.Helper
{
    public class JwtManager
    {
        public bool IsAuthenticated { get; set; }
        private JwtSecurityToken SecureToken;
        public string JwtTokenString { get; set; } = "";

        public JwtManager()
        {

        }

        public void SetToken(string token)
        {
            try
            {
                JwtTokenString = token;

                var handler = new JwtSecurityTokenHandler();
                SecureToken = handler.ReadJwtToken(JwtTokenString);
                IsAuthenticated = true;
            }
            catch (Exception)
            {
                IsAuthenticated = false;
            }
        }

        //Every time a OData request is build it adds an Authorization Header with the acesstoken 
        public static void OnBuildingRequest(object sender, BuildingRequestEventArgs e, string token)
        {
            e.Headers.Add("Authorization", "Bearer " + token);
        }

        public bool IsMember() => GetUserRole() == "Member";

        public bool IsTeacher() => GetUserRole() == "Teacher";

        public bool IsStaff() => GetUserRole() == "IsStaff";

        public bool IsAdmin() => GetUserRole() == "IsAdmin";

        private string GetUserId()
            => SecureToken.Claims.Where(c => c.Type == ClaimTypes.Sid).SingleOrDefault().Value;

        private string GetUserRole()
            => IsAuthenticated ? SecureToken.Claims.Where(c => c.Type == ClaimTypes.Role).SingleOrDefault().Value : "";

        private string GetUsername()
            => SecureToken.Claims.Where(c => c.Type == ClaimTypes.Name).SingleOrDefault().Value;


        //public ClaimsPrincipal GetPriciples()
        //{
        //    var claims = new List<Claim>();
        //    var tokenString = "Bearer " + JwtTokenString;
        //    claims.Add(new Claim(ClaimTypes.Sid, GetUserId()));
        //    claims.Add(new Claim(ClaimTypes.Name, GetUsername()));
        //    claims.Add(new Claim(ClaimTypes.Role, GetUserRole()));
        //    claims.Add(new Claim("AuthHeader",
        //        tokenString));

        //    var claimsIdentity = new ClaimsIdentity(
        //        claims, CookieAuthenticationDefaults.AuthenticationScheme);

        //    return new ClaimsPrincipal(claimsIdentity);
        //}
    }
}
