using Npgsql;
using Npgsql.Internal;

namespace Challenger.Server.Data;

/// <summary>
///	Database context for application PostgreSQL DBMS
///	</summary>

public class DbContext
{
	private string _connectionString;

	public DbContext(string host, string username, string password, string dbName)
	{
		_connectionString = $"Host={host};Username={username};Password={password};Database={dbName}";
	}
}
