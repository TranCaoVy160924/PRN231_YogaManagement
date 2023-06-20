using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.OData.Client;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace YogaManagement.Client.Helper;

public class JwtManager
{
    public bool IsAuthenticated { get; private set; }
    private JwtSecurityToken SecureToken;
    private string JwtTokenString = "";

    public void Login(string token)
    {
        try
        {
            JwtTokenString = token;

            var handler = new JwtSecurityTokenHandler();
            SecureToken = handler.ReadJwtToken(JwtTokenString);
            IsAuthenticated = true;
        }
        catch (Exception ex)
        {
            JwtTokenString = "";
            SecureToken = null;
            IsAuthenticated = false;
        }
    }

    public void Logout()
    {
        JwtTokenString = "";
        IsAuthenticated = false;
    }

    //Every time a OData request is build it adds an Authorization Header with the acesstoken 
    public void OnBuildingRequest(object sender, BuildingRequestEventArgs e)
    {
        e.Headers.Add("Authorization", "Bearer " + JwtTokenString);
    }

    public bool IsMember() => GetUserRole() == "Member";

    public bool IsTeacher() => GetUserRole() == "Teacher";

    public bool IsStaff() => GetUserRole() == "Staff";

    public bool IsAdmin() => GetUserRole() == "Admin";

    private string GetUserId()
        => IsAuthenticated ? SecureToken.Claims.Where(c => c.Type == ClaimTypes.Sid).SingleOrDefault().Value : "";

    private string GetUserRole()
        => IsAuthenticated ? SecureToken.Claims.Where(c => c.Type == ClaimTypes.Role).SingleOrDefault().Value : "";

    private string GetEmail()
        => IsAuthenticated ? SecureToken.Claims.Where(c => c.Type == ClaimTypes.Email).SingleOrDefault().Value : "";


    public ClaimsPrincipal TryGetPriciples()
    {
        if (!IsAuthenticated)
        {
            throw new Exception("User havent login");
        }

        var claims = new List<Claim>();
        var tokenString = "Bearer " + JwtTokenString;
        claims.Add(new Claim(ClaimTypes.Sid, GetUserId()));
        claims.Add(new Claim(ClaimTypes.Email, GetEmail()));
        claims.Add(new Claim(ClaimTypes.Role, GetUserRole()));
        claims.Add(new Claim("AuthHeader",
            tokenString));

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        return new ClaimsPrincipal(claimsIdentity);
    }
}
