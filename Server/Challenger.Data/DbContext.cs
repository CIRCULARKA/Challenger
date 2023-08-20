using Npgsql;
using NpgsqlTypes;

using System;

using Challenger.Data.Models;

namespace Challenger.Data;

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

	public User GetUser(string login)
	{
		var sql = @"SELECT login, name, age, weight, email, password_hash FROM users WHERE login = $1;";

		using (var source = CreateSource())
		{
			using (var cmd = source.CreateCommand(sql))
			{
				cmd.Parameters.AddWithValue(NpgsqlDbType.Varchar, login);

				using (var reader = cmd.ExecuteReader())
				{
					if (!reader.HasRows) throw new ArgumentException($"There is no user with login \"{login}\"");
					reader.Read();

					var resultedUser = new User()
					{
						Login = reader.GetString(0),
						Name = reader.GetString(1),
						Age = reader.GetInt16(2),
						Weight = reader.GetInt16(3),
						Email = reader.GetString(4),
						PasswordHash = reader.GetString(5)
					};
					return resultedUser;
				}
			}
		}
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
