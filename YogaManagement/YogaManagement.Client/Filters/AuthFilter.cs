using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using YogaManagement.Client.Helper;

namespace YogaManagement.Client.Filters;

public class AuthFilter : ActionFilterAttribute
{
    private readonly JwtManager _jwtManager;

    public AuthFilter(JwtManager jwtManager)
    {
        _jwtManager = jwtManager;
    }

    //After Method execution
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        //Do stuff
    }

    //Before Method execution
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!_jwtManager.IsAuthenticated)
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Auth", action = "Login" }));
        }
    }
}
