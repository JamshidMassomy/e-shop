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
    private readonly IConfiguration _configuration;
    public AuthController(IMediator mediator, IConfiguration configuration)
    {
        _mediator = mediator;
        _configuration = configuration;
    }


    [HttpPost]
    [Route("authenticate-google")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Consumes("application/json")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginWithGoogle([FromBody] TokenRequest tokenRequest)
    {
        var settings = new ValidationSettings()
        {
            Audience = new [] { _configuration["Google:ClientId"] }
        };
        await ValidateAsync(tokenRequest.tokenId, settings); 
        var request = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        var jwtToken = await _mediator.Send(new AuthenticateRequest { RequestResult = request });
        return Ok(jwtToken.Value);
        
    }


}