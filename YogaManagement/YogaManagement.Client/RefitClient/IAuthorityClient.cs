using Refit;
using YogaManagement.Contracts.Authority.Request;
using YogaManagement.Contracts.Authority.Response;

namespace YogaManagement.Client.RefitClient;
[Headers("Content-Type: application/json")]

public interface IAuthorityClient
{
    [Post("/Authority/auth")]
    Task RegisterAsync([Body] RegisterRequest registerRequest);

    [Post("/Users/auth")]
    Task<LoginResponse> AuthenticateAsync([Body] LoginRequest loginRequest);

    [Post("/Users/auth/refresh")]
    Task<LoginResponse> RefreshTokenAsync([Header("Authorization")] string jwtToken);
}
