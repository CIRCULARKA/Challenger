namespace Challenger.Server.Data.Models;

public class User
{
	public string Login { get; set; }

	public string Name { get; set; }

	public short Age { get; set; }

	public short Weight { get; set; }

	public string Email { get; set; }

	public string PasswordHash { get; set; }
}
