using Microsoft.AspNetCore.Mvc;

namespace Challenger.Server.Controllers;

public class TestController : ControllerBase
{
	[HttpGet("/")]
	public string ExecSql()
	{
		return "Hello";
	}
}
