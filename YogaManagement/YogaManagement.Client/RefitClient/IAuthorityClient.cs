using AutoMapper.Internal;
using YogaManagement.Contracts.Authority.Request;
using YogaManagement.Contracts.Authority.Response;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaManagement.Client.RefitClient;
[Headers("Content-Type: application/json")]

public interface IAuthorityClient
{
    [Post("/Authority/")]
    Task<UserResponse> RegisterAsync([Body] RegisterRequest registerRequest);
    [Post("/Authority/auth/token/")]
    Task<string> AuthenticateAsync([Body] LoginRequest loginRequest);
}
