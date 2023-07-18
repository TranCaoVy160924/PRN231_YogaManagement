using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.OData.Client;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace YogaManagement.Client.Helper;

public class JwtManager
{
    public bool IsAuthenticated { get; private set; }
    private JwtSecurityToken SecureToken;
    public string JwtTokenString { get; private set; } = "";
    private readonly IHttpContextAccessor _contextAccessor;

    public JwtManager(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
        var session = _contextAccessor.HttpContext.Session;
        JwtTokenString = session.GetString("SecureToken");
        if (JwtTokenString != null)
        {
            var handler = new JwtSecurityTokenHandler();
            SecureToken = handler.ReadJwtToken(JwtTokenString);
            IsAuthenticated = true;
        }
        else
        {
            JwtTokenString = "";
            SecureToken = null;
            IsAuthenticated = false;
        }
    }

    public void Login(string token)
    {
        try
        {
            JwtTokenString = token;

            var handler = new JwtSecurityTokenHandler();
            SecureToken = handler.ReadJwtToken(JwtTokenString);
            IsAuthenticated = true;

            var session = _contextAccessor.HttpContext.Session;
            session.SetString("SecureToken", token);
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

    public int GetUserId()
        => IsAuthenticated ? int.Parse(SecureToken.Claims.Where(c => c.Type == ClaimTypes.Sid).SingleOrDefault().Value) : 0;

    public double GetTotalDeposit()
        => IsAuthenticated ? double.Parse(SecureToken.Claims.Where(c => c.Type == "TotalDeposit").SingleOrDefault().Value) : 0;

    public string GetUserRole()
        => IsAuthenticated ? SecureToken.Claims.Where(c => c.Type == ClaimTypes.Role).SingleOrDefault().Value : "";

    public string GetEmail()
        => IsAuthenticated ? SecureToken.Claims.Where(c => c.Type == ClaimTypes.Email).SingleOrDefault().Value : "";

    public int GetProfileId()
    {
        if (IsMember() || IsTeacher())
        {
            return int.Parse(SecureToken.Claims.Where(c => c.Type == "Profile").SingleOrDefault().Value);
        }
        else
        {
            return 0;
        }
    }
    public ClaimsPrincipal TryGetPriciples()
    {
        if (!IsAuthenticated)
        {
            throw new Exception("User havent login");
        }

        var claims = new List<Claim>();
        var tokenString = "Bearer " + JwtTokenString;
        claims.Add(new Claim(ClaimTypes.Sid, GetUserId().ToString()));
        claims.Add(new Claim(ClaimTypes.Email, GetEmail()));
        claims.Add(new Claim(ClaimTypes.Role, GetUserRole()));
        claims.Add(new Claim("AuthHeader",
            tokenString));

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        return new ClaimsPrincipal(claimsIdentity);
    }
}
