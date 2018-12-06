using System.Collections.Generic;
using System.ServiceModel;
using MultiPlayer.BusinessObjects.Models;

namespace MultiPlayer.BusinessRules
{
	[ServiceContract]
	public interface IUserDataService
	{
		[OperationContract]
		IEnumerable<User> GetAllUsers();
		[OperationContract]
		User CreateUser(User user);
		[OperationContract]
		User DeleteUser(User user);
		[OperationContract]
		User GetUserById(int? id);
		[OperationContract]
		User GetUserByName(string name);
		[OperationContract]
		User UpdateUser(User user);
	}
}