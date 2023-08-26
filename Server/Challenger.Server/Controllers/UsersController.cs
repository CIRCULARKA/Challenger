using System;

using Microsoft.AspNetCore.Mvc;

using FluentValidation;
using FluentValidation.Results;

using Challenger.Data.Models;
using Challenger.Data;

namespace Challenger.Server.Controllers;

[Route("api")]
[ApiController]
public class UsersController : ControllerBase
{
	private readonly IDataContext _dataContext;

	public UsersController(PSqlDataContext PSqlDataContext)
	{
		_dataContext = PSqlDataContext;
	}

	[HttpPost("register")]
	public IActionResult Register([FromForm] User userToRegister, [FromServices] IValidator<User> userValidator)
	{
		ValidationResult validationResult = userValidator.Validate(userToRegister);
		if (!validationResult.IsValid)
			return UnprocessableEntity(new ChallengerHttpErrorMessage(validationResult));

		_dataContext.AddUser(userToRegister);

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
		var targetUser = _dataContext.GetUserByPrimaryKey(login);

		return Ok(targetUser);
	}
}
