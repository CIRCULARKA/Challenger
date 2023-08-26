using System;

using Microsoft.AspNetCore.Mvc;

using FluentValidation;
using FluentValidation.Results;

using Challenger.Data.Models;
using Challenger.Application;
using Challenger.Server.Errors;

namespace Challenger.Server.Controllers;

[Route("api")]
[ApiController]
public class UsersController : ControllerBase
{
	private readonly UserRegistry _userRegistry;

	public UsersController(UserRegistry userRegistry)
	{
		_userRegistry = userRegistry;
	}

	[HttpPost("register")]
	public IActionResult Register([FromForm] User userToRegister, [FromServices] IValidator<User> userValidator)
	{
		ValidationResult validationResult = userValidator.Validate(userToRegister);
		if (!validationResult.IsValid)
			return UnprocessableEntity(new ChallengerHttpErrorMessage(validationResult));

		try { _userRegistry.RegisterUser(userToRegister); }
		catch (Exception e) { return BadRequest(new ChallengerHttpErrorMessage(ChallengerErrorTypes.ActionError, e.Message)); }

		return Ok();
	}

	[HttpPost("auth")]
	public string Authorize(string userLogin, string passwordHash)
	{
		Console.Write($"\"{nameof(Authorize)}\" method was called: ");
		Console.WriteLine("Request method: " + HttpContext.Request.Method);

		return "Authorization";
	}

	[HttpPost("logout")]
	public string Logout(string userLogin)
	{
		Console.Write($"\"{nameof(Logout)}\" method was called: ");
		Console.WriteLine("Request method: " + HttpContext.Request.Method);

		return "Logout";
	}

	[HttpGet("user")]
	public IActionResult GetUser([FromQuery] string login)
	{
		var targetUser = _userRegistry.GetUserByLogin(login);

		return Ok(targetUser);
	}
}
