using MultiPlayer.BusinessObjects.Models;
using MultiPlayer.DataAccess.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MultiPlayer.BusinessRules.DataServices
{
	public class GameDataService : IGameDataService1
	{

		public IEnumerable<Game> GetAll()
		{
			using (var ctx = new MultiPlayerDBContext())
				return ctx.Games.Include(g => g.Users).AsNoTracking().ToList();
		}

		public Game GetById(int id)
		{
			using (var ctx = new MultiPlayerDBContext())
				return ctx.Games.Include(g => g.Users).AsNoTracking().FirstOrDefault(g => g.Id == id);
		}

		public Game Delete(Game game)
		{
			using (var ctx = new MultiPlayerDBContext())
			{
				Game result = ctx.Games.Include(g => g.Users).FirstOrDefault(g => g == game);
				ctx.Games.Remove(result);
				ctx.SaveChanges();
				return result;
			}

		}

		public Game Update(Game game)
		{
			using (var ctx = new MultiPlayerDBContext())
			{
				ctx.Games.Attach(game);
				ctx.Entry(game).State = EntityState.Modified;
				ctx.SaveChangesAsync();
				return game;
			}
		}

		public Game Create(Game game)
		{
			if (game == null)
				return null;
			using (var ctx = new MultiPlayerDBContext())
			{
				ctx.Games.Add(game);
				ctx.SaveChangesAsync();
				return game;
			}
		}
	}
}
