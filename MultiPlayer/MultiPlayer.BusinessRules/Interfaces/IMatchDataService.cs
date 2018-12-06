using System.Collections.Generic;
using MultiPlayer.BusinessObjects.Models;

namespace MultiPlayer.BusinessRules
{
	public interface IMatchDataService
	{
		Match CreateMatch(Match match);
		Match DeleteMatch(Match match);
		IEnumerable<Match> GetAllMatches();
		Match GetMatchById(int id);
		Match GetMatchByUserId(int id);
		Match GetMatchByGameId(int id);
		Match UpdateMatch(Match match);
	}
}