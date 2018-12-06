using MultiPlayer.BusinessObjects.Models;
using MultiPlayer.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MultiPlayer.BusinessRules
{
	public class MatchDataService : IDisposable, IMatchDataService
	{
		readonly MultiPlayerDBContext context = new MultiPlayerDBContext();
		public void Dispose() => context.Dispose();
		public IEnumerable<Match> GetAllMatches()
		{
			return context.Matches;
		}

		public Match GetMatchById(int id)
		{
			return context.Matches.FirstOrDefault(m => m.Id == id);
		}
		
		public Match GetMatchByUserId(int id)
		{
			return context.Matches.FirstOrDefault(m => m.UserId == id);
		}

		public Match GetMatchByGameId(int id)
		{
			return context.Matches.FirstOrDefault(m => m.GameId == id);
		}

		public Match DeleteMatch(Match match)
		{
			if (match == null)
				return null;

			Match result = GetMatchById(match.Id);
			context.Matches.Remove(result);
			context.SaveChanges();
			return result;

		}

		public Match UpdateMatch(Match match)
		{
			if (match == null)
				return null;

			var original = context.Matches.FirstOrDefault(m => m.Id == match.Id);

			context.Matches.Attach(original);
			context.Entry(original).State = EntityState.Modified;
			context.SaveChanges();
			return match;
		}

		public Match CreateMatch(Match match)
		{
			if (match == null)
				return null;

			context.Matches.Add(match);
			context.SaveChanges();

			return match;
		}
	}
}
