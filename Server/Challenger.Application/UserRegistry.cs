using System;
using Challenger.Data;
using Challenger.Data.Models;

namespace Challenger.Application;

public class UserRegistry
{
	private readonly IDataContext _dataContext;

	public UserRegistry(IDataContext dataContext)
	{
		if (dataContext is null) throw new ArgumentNullException($"Can't create {nameof(UserRegistry)} - data context is null");

		_dataContext = dataContext;
	}

	public User GetUserByLogin(string login)
	{
		if (login is null) throw new ArgumentNullException("Login can't be null");

		return _dataContext.GetUserByPrimaryKey(login);
	}

	public void RegisterUser(User newUser)
	{
		if (newUser is null) throw new ArgumentNullException("Can't register new user - the user is null");

		var existingUser = GetUserByLogin(newUser.Login);
		if (existingUser != null)
			throw new InvalidOperationException($"Can't register new user - there is already user with specified login ({newUser.Login})");

		_dataContext.AddUser(newUser);
	}
}
