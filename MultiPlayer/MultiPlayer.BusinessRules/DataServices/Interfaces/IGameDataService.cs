using System.Collections.Generic;
using System.Threading.Tasks;
using MultiPlayer.BusinessObjects.Models;

namespace MultiPlayer.BusinessRules.DataServices
{
	public interface IGameDataService
	{
		Task<Game> CreateAsync(Game game);
		Task<Game> DeleteAsync(Game game);
		Task<IEnumerable<Game>> GetAllAsync();
		Task<Game> GetById(int id);
		Task<Game> UpdateAsync(Game game);
	}
}