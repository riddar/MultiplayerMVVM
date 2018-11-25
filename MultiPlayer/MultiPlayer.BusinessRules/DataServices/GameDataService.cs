using MultiPlayer.BusinessObjects.Models;
using MultiPlayer.DataAccess.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MultiPlayer.BusinessRules.DataServices
{
	public class GameDataService : IGameDataService
	{
		MultiPlayerDBContext ctx;

		public GameDataService() => ctx = new MultiPlayerDBContext();

		public async Task<IEnumerable<Game>> GetAllAsync()
		{
			return await ctx.Games.Include(g => g.Users).AsNoTracking().ToListAsync();
		}

		public async Task<Game> GetById(int id)
		{
			return await ctx.Games.Include(g => g.Users).AsNoTracking().FirstOrDefaultAsync(g => g.Id == id);
		}

		public async Task<Game> DeleteAsync(Game game)
		{
				Game result = await ctx.Games.Include(g => g.Users).FirstOrDefaultAsync(g => g == game);
				ctx.Games.Remove(result);
				await ctx.SaveChangesAsync();
				return result;
		}

		public async Task<Game> UpdateAsync(Game game)
		{
			ctx.Games.Attach(game);
			ctx.Entry(game).State = EntityState.Modified;
			await ctx.SaveChangesAsync();
			return game;
		}

		public async Task<Game> CreateAsync(Game game)
		{
			if (game == null)
				return null;

			ctx.Games.Add(game);
			await ctx.SaveChangesAsync();
			return game;
		}
	}
}
