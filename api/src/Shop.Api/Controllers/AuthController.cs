
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Features.Auth;
using ISession = Shop.Domain.Entities.Auth.Interfaces.ISession;

namespace Boilerplate.Api.Controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{

    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [AllowAnonymous]
    [Route("login")]
    public async Task LoginWithGoogle()
    {
        await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
        {
            RedirectUri = Url.Action("GoogleResponse")
        });
    }


    [HttpGet]
    [Route("google-response")]
    [AllowAnonymous]
    public async Task<IActionResult> GoogleResponse()
    {
        var request = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        if (request.Succeeded)
        {
            var jwtToken = await _mediator.Send(new AuthenticateRequest { RequestResult = request });
            return Ok(jwtToken.Value);
        } else
        {
           return Unauthorized();
        }
        
    }


    [HttpGet]
    [AllowAnonymous]
    [Route("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return Redirect("/");
    }

    
}
