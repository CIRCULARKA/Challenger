using Challenger.Data.Models;

namespace Challenger.Data;

public interface IDataContext
{
	public User GetUserByPrimaryKey(string pkey);

	public void AddUser(User userToAdd);
}
