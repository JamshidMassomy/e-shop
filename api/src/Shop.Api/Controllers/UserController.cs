
﻿using Ardalis.Result;
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
[Authorize]
public class UserController : ControllerBase
{
    private readonly ISession _session;
    private readonly IMediator _mediator;

    public UserController(ISession session, IMediator mediator)
    {
        _session = session;
        _mediator = mediator;
    }

    [HttpGet]
    [AllowAnonymous]
    [Route("GetMyRequest")]
    public String GetMyRequest()
    {
        return "I am doing great!";

    }

    [HttpGet("LockedRout")]
    [Authorize]
    public String GetMyLockedRoute()
    {
        return "I am doing great!";

    }


    [HttpGet("login-with-google")]
    public async Task LoginWithGoogle()
    {
        await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
        {
            RedirectUri = Url.Action("GoogleResponse")
        });
    }


    [HttpGet("google-response")]
    public async Task<IActionResult> GoogleResponse()
    {
        var request = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        if (request.Succeeded)
        {
            var jwtToken = await _mediator.Send(new AuthenticateRequest { RequestResult = request });
            return Ok(jwtToken.Value);
        } else
        {
            Unauthorized();
        }
        
        return Ok("jwt token here");
    }
    


    /// <summary>
    /// Authenticates the user and returns the token information.
    /// </summary>
    /// <param name="request">Email and password information</param>
    /// <returns>Token information</returns>
    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    // [TranslateResultToActionResult]
    // [ExpectedFailures(ResultStatus.Invalid)]
    public async Task<Result<Jwt>> Authenticate([FromBody] AuthenticateRequest request)
    {
        var jwt = await _mediator.Send(request);
        return jwt;
    }

  


}
