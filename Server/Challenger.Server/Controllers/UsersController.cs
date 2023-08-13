using Microsoft.AspNetCore.Mvc;

namespace Challenger.Server.Controllers;

public class UsersController : ControllerBase
{
	[HttpPost("/register")]
	public string Register(User userToRegister)
	{
		return "Registration";
	}

	[HttpPost("/auth")]
	public string Authorize(string userLogin, string passwordHash)
	{
		return "Authorization";
	}

	[HttpPost("/logout")]
	public string Logout(string userLogin)
	{
		return "Logout";
	}
}
