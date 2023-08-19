using System;

using Microsoft.AspNetCore.Mvc;

using Challenger.Server.Data.Models;

namespace Challenger.Server.Controllers;

public class UsersController : ControllerBase
{
	[HttpPost("/register")]
	public string Register(User userToRegister)
	{
		Console.Write($"\"{nameof(Register)}\" method was called: ");
		Console.WriteLine("Request method: " + HttpContext.Request.Method);

		return "Registration";
	}

	[HttpPost("/auth")]
	public string Authorize(string userLogin, string passwordHash)
	{
		Console.Write($"\"{nameof(Authorize)}\" method was called: ");
		Console.WriteLine("Request method: " + HttpContext.Request.Method);

		return "Authorization";
	}

	[HttpPost("/logout")]
	public string Logout(string userLogin)
	{
		Console.Write($"\"{nameof(Logout)}\" method was called: ");
		Console.WriteLine("Request method: " + HttpContext.Request.Method);

		return "Logout";
	}
}
