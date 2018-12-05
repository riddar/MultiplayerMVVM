using System.Collections.Generic;
using System.ServiceModel;
using MultiPlayer.BusinessObjects.Models;

namespace MultiPlayer.BusinessRules
{
	[ServiceContract]
	public interface IUserDataService
	{
		[OperationContract]
		IEnumerable<MultiPlayer.BusinessObjects.Models.User> GetAllUsers();
		[OperationContract]
		MultiPlayer.BusinessObjects.Models.User CreateUser(MultiPlayer.BusinessObjects.Models.User user);
		[OperationContract]
		MultiPlayer.BusinessObjects.Models.User DeleteUser(MultiPlayer.BusinessObjects.Models.User user);
		[OperationContract]
		MultiPlayer.BusinessObjects.Models.User GetUserById(int? id);
		[OperationContract]
		MultiPlayer.BusinessObjects.Models.User GetUserByName(string name);
		[OperationContract]
		MultiPlayer.BusinessObjects.Models.User UpdateUser(MultiPlayer.BusinessObjects.Models.User user);
	}
}