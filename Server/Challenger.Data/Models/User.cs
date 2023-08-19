namespace Challenger.Server.Data.Models;

public class User
{
	public string Login { get; init; }

	public string Name { get; init; }

	public short Age { get; init; }

	public short Weight { get; init; }

	public string Email { get; init; }

	public string PasswordHash { get; init; }
}
