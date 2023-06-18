using Refit;
using YogaManagement.Contracts.Authority.Request;

namespace YogaManagement.Client.RefitClient;
[Headers("Content-Type: application/json")]

public interface IAuthorityClient
{
    [Post("/Authority/auth")]
    Task RegisterAsync([Body] RegisterRequest registerRequest);

    [Post("/Users/auth")]
    Task<string> AuthenticateAsync([Body] LoginRequest loginRequest);
}
