using Refit;
using YogaManagement.Contracts.Authority.Request;

namespace YogaManagement.Client.RefitClient;
[Headers("Content-Type: application/json")]

public interface IAppUserClient
{
    [Post("/Authority/auth")]
    Task RegisterAsync([Body] RegisterRequest registerRequest);
}
