using System;

using Microsoft.AspNetCore.Mvc;

using Challenger.Server.Data.Models;
using Challenger.Server.Data;

namespace Challenger.Server.Controllers;

[Route("api")]
[ApiController]
public class UsersController : ControllerBase
{
	private DbContext _dbContext;

	public UsersController(DbContext dbContext)
	{
		_dbContext = dbContext;
	}

	[HttpPost("register")]
	public IActionResult Register([FromForm] User userToRegister)
	{
		_dbContext.AddUser(userToRegister);

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
		var targetUser = _dbContext.GetUser(login);

		return Ok(targetUser);
	}
}
