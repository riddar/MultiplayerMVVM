using MultiPlayer.BusinessObjects.Models;
using MultiPlayer.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MultiPlayer.BusinessRules
{
	public class UserDataService : IDisposable, IUserDataService
	{
		readonly MultiPlayerDBContext context = new MultiPlayerDBContext();
		public void Dispose() => context.Dispose();

		public IEnumerable<User> GetAllUsers()
		{
			return context.Users.Include(u => u.Matches).ToList();
		}

		public User GetUserById(int? id)
		{
			if (id == null)
				return null;

			return context.Users.FirstOrDefault(u => u.Id == id);
		}


		public User GetUserByName(string name)
		{
			if (name == null)
				return null;

			return context.Users.Include(u => u.Matches).FirstOrDefault(u => u.Username == name);
		}

		public User DeleteUser(User user)
		{
			if (user == null)
				return null;

			var result = GetUserById(user.Id);

			if (result == null)
				return null;

			context.Users.Remove(result);
			foreach (var match in result.Matches)
			{
				context.Matches.Remove(match);
			}

			return user;
		}

		public User UpdateUser(User user)
		{
			context.Entry(user).State = user.Id == 0 ? EntityState.Added : EntityState.Modified;
			context.SaveChanges();
			return user;
		}

		public User CreateUser(User user)
		{
			if (user == null)
				return null;

			context.Users.Add(user);
			context.SaveChanges();
			return user;
		}
	}
}
