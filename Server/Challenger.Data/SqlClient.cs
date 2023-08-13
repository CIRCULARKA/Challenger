using Microsoft.Data.SqlClient;

namespace Challenger.Server.Data;

public class SqlClient
{
	private SqlConnection _connection;

	public SqlClient()
	{
		_connection = new SqlConnection("postgresql://localhost/challenger");
	}
}
