using MultiPlayer.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;

namespace MultiPlayer.BusinessRules
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class GameDataService : IDisposable, IGameDataService
	{
		readonly MultiPlayerDBContext context = new MultiPlayerDBContext();
		public GameDataService() => context.Configuration.ProxyCreationEnabled = false;
		public void Dispose() => context.Dispose();

		public IEnumerable<MultiPlayer.BusinessObjects.Models.Game> GetAllGames()
		{
			return context.Games.Include(g => g.Users).ToList();
		}

		public MultiPlayer.BusinessObjects.Models.Game GetGameById(int id)
		{
			return context.Games.Include(g => g.Users).FirstOrDefault(g => g.Id == id);
		}

		public MultiPlayer.BusinessObjects.Models.Game DeleteGame(MultiPlayer.BusinessObjects.Models.Game game)
		{
			if (game == null)
				return null;

			MultiPlayer.BusinessObjects.Models.Game result = GetGameById(game.Id);
			context.Games.Remove(result);
			context.SaveChanges();
			return result;

		}

		public MultiPlayer.BusinessObjects.Models.Game UpdateGame(MultiPlayer.BusinessObjects.Models.Game game)
		{
			if (game == null)
				return null;

			context.Games.Attach(game);
			context.Entry(game).State = EntityState.Modified;
			context.SaveChanges();
			return game;
		}

		public MultiPlayer.BusinessObjects.Models.Game CreateGame(MultiPlayer.BusinessObjects.Models.Game game)
		{
			if (game == null)
				return null;
			game.Users = null;
			context.Games.Add(game);
			context.SaveChanges();

			return game;
		}
	}
}
