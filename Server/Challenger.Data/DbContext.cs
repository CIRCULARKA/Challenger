using Npgsql;
using NpgsqlTypes;

using Challenger.Server.Data.Models;
using System;

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

	public void AddUser(User userToAdd)
	{
		var sql = @"
			INSERT INTO users (login, name, age, weight, email, password_hash)
			VALUES ($1, $2, $3, $4, $5, $6);
		";

		using (var source = CreateSource())
		{
			using (var cmd = source.CreateCommand(sql))
			{
				cmd.Parameters.AddWithValue(NpgsqlDbType.Varchar, userToAdd.Login);
				cmd.Parameters.AddWithValue(NpgsqlDbType.Varchar, userToAdd.Name);
				cmd.Parameters.AddWithValue(NpgsqlDbType.Smallint, userToAdd.Age);
				cmd.Parameters.AddWithValue(NpgsqlDbType.Smallint, userToAdd.Weight);
				cmd.Parameters.AddWithValue(NpgsqlDbType.Varchar, userToAdd.Email);
				cmd.Parameters.AddWithValue(NpgsqlDbType.Varchar, userToAdd.PasswordHash);

				cmd.ExecuteNonQuery();
			}
		}
	}

	private NpgsqlDataSource CreateSource() =>
		NpgsqlDataSource.Create(_connectionString);
}
