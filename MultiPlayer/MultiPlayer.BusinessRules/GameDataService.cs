using MultiPlayer.BusinessObjects.Models;
using MultiPlayer.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MultiPlayer.BusinessRules
{
	public class GameDataService : IDisposable, IGameDataService
	{
		readonly MultiPlayerDBContext context = new MultiPlayerDBContext();
		public void Dispose() => context.Dispose();
		public IEnumerable<Game> GetAllGames()
		{
			return context.Games.Include(g => g.Matches).ToList();
		}

		public Game GetGameById(int id)
		{
			return context.Games.Include(g => g.Matches).FirstOrDefault(g => g.Id == id);
		}

		public Game GetGameByName(string name)
		{
			return context.Games.Include(g => g.Matches).FirstOrDefault(g => g.Name == name);
		}

		public Game DeleteGame(Game game)
		{
			if (game == null)
				return null;

			Game result = GetGameById(game.Id);
			context.Games.Remove(result);
			context.SaveChanges();
			return result;

		}

		public Game UpdateGame(Game game)
		{
			if (game == null)
				return null;

			var original = context.Games.Include(g => g.Matches).FirstOrDefault(g => g.Id == game.Id);
			original.Matches = game.Matches;

			context.Games.Attach(original);
			context.Entry(original).State = EntityState.Modified;
			context.SaveChanges();
			return game;
		}

		public Game CreateGame(Game game)
		{
			if (game == null)
				return null;

			context.Games.Add(game);
			context.SaveChanges();
			var result = GetGameByName(game.Name);
			return result;
		}
	}
}
