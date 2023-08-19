using Npgsql;

using System.Collections.Generic;

using Challenger.Server.Data.Models;

namespace Challenger.Server.Data;

/// <summary>
///	Database context for application PostgreSQL DBMS
///	</summary>

public class DbContext
{
	private string _connectionString;

	public DbContext(string connectionString)
	{
		_connectionString = connectionString;
	}

	public IEnumerable<User> GetUsers()
	{
		var dataSource = NpgsqlDataSource.Create(_connectionString);

		return null;
	}
}
