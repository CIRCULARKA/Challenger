namespace Challenger.Server;

public class User
{
	public string Login { get; set; }

	public short Age { get; set; }

	public short Weight { get; set; }

	public string Email { get; set; }

	public byte[] PasswordHash { get; set; }
}
