using MultiPlayer.BusinessObjects.Models;
using MultiPlayer.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlayer.BusinessRules.DataServices
{
	public class UserDataService : IUserDataService
	{
		MultiPlayerDBContext ctx;
		public UserDataService() => ctx = new MultiPlayerDBContext();

		public async Task<IEnumerable<User>> GetAllAsync()
		{
			return await ctx.Users.AsNoTracking().ToListAsync();
		}

		public async Task<User> GetByIdAsync(int? id)
		{
			if (id == null)
				return null;

			return await ctx.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
		}


		public async Task<User> GetUserByNameAsync(string name)
		{
			if (name == null)
				return null;

			return await ctx.Users.Include(u => u.Games).AsNoTracking().FirstOrDefaultAsync(u => u.Username == name);
		}

		public async Task<User> DeleteByIdAsync(int? id)
		{
			if (id == null)
				return null;

			var user = await ctx.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

			if (user == null)
				return null;

			ctx.Users.Remove(user);
			return user;
		}

		public async Task<User> UpdateAsync(User user)
		{
			if (user == null)
				return null;

			ctx.Users.Attach(user);
			ctx.Entry(user).State = EntityState.Modified;
			await ctx.SaveChangesAsync();
			return user;
		}

		public async Task<User> CreateUserAsync(User user)
		{
			if (user == null)
				return null;

			ctx.Users.Add(user);
			await ctx.SaveChangesAsync();
			return user;
		}
	}
}
