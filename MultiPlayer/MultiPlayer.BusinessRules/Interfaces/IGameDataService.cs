using System.Collections.Generic;
using System.ServiceModel;
using MultiPlayer.BusinessObjects.Models;

namespace MultiPlayer.BusinessRules
{
	[ServiceContract]
	public interface IGameDataService
	{
		[OperationContract]
		IEnumerable<MultiPlayer.BusinessObjects.Models.Game> GetAllGames();
		[OperationContract]
		MultiPlayer.BusinessObjects.Models.Game CreateGame(MultiPlayer.BusinessObjects.Models.Game game);
		[OperationContract]
		MultiPlayer.BusinessObjects.Models.Game DeleteGame(MultiPlayer.BusinessObjects.Models.Game game);
		[OperationContract]
		MultiPlayer.BusinessObjects.Models.Game GetGameById(int id);
		[OperationContract]
		MultiPlayer.BusinessObjects.Models.Game UpdateGame(MultiPlayer.BusinessObjects.Models.Game game);
	}
}