using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Auth;
using Shop.Application.Features.Auth;
using static Google.Apis.Auth.GoogleJsonWebSignature;

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
    [Route("test")]
    public String Test()
    {
        return "Hi test";

    }

    [HttpGet]
    [Route("test-locked")]
    [Authorize]
    public String TestLocked()
    {
        return "Hi test";

    }



    [HttpPost]
    [AllowAnonymous]
    [Route("authenticate-google")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Consumes("application/json")]
    public async Task<IActionResult> LoginWithGoogle([FromBody] TokenRequest tokenRequest)
    {
        if (ValidateAsync(tokenRequest.tokenId, new ValidationSettings()).IsCompletedSuccessfully)
        {
            var request = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
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