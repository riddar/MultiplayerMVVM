using MultiPlayer.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;

namespace MultiPlayer.BusinessRules
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class UserDataService : IDisposable, IUserDataService
	{
		readonly MultiPlayerDBContext context = new MultiPlayerDBContext();
		public UserDataService() => context.Configuration.ProxyCreationEnabled = false;
		public void Dispose() => context.Dispose();

		public IEnumerable<MultiPlayer.BusinessObjects.Models.User> GetAllUsers()
		{
			return context.Users.Include(u => u.Games).ToList();
		}

		public MultiPlayer.BusinessObjects.Models.User GetUserById(int? id)
		{
			if (id == null)
				return null;

			return context.Users.FirstOrDefault(u => u.Id == id);
		}


		public MultiPlayer.BusinessObjects.Models.User GetUserByName(string name)
		{
			if (name == null)
				return null;

			return context.Users.Include(u => u.Games).FirstOrDefault(u => u.Username == name);
		}

		public MultiPlayer.BusinessObjects.Models.User DeleteUser(MultiPlayer.BusinessObjects.Models.User user)
		{
			if (user == null)
				return null;

			var result = context.Users.FirstOrDefault(u => u == user);

			if (result == null)
				return null;

			context.Users.Remove(result);
			return user;
		}

		public MultiPlayer.BusinessObjects.Models.User UpdateUser(MultiPlayer.BusinessObjects.Models.User user)
		{
			if (user == null)
				return null;

			context.Users.Attach(user);
			context.Entry(user).State = EntityState.Modified;
			context.SaveChanges();
			return user;
		}

		public MultiPlayer.BusinessObjects.Models.User CreateUser(MultiPlayer.BusinessObjects.Models.User user)
		{
			if (user == null)
				return null;

			context.Users.Add(user);
			context.SaveChanges();
			return user;
		}
	}
}
