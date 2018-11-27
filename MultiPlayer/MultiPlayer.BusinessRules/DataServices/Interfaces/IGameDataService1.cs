using System.Collections.Generic;
using MultiPlayer.BusinessObjects.Models;

namespace MultiPlayer.BusinessRules.DataServices
{
	public interface IGameDataService1
	{
		Game Create(Game game);
		Game Delete(Game game);
		IEnumerable<Game> GetAll();
		Game GetById(int id);
		Game Update(Game game);
	}
}