using System.Collections.Generic;
using System.Threading.Tasks;
using MultiPlayer.BusinessObjects.Models;

namespace MultiPlayer.BusinessRules.DataServices
{
	public interface IUserDataService
	{
		Task<User> CreateUserAsync(User user);
		Task<User> DeleteByIdAsync(int? id);
		Task<List<User>> GetAllAsync();
		Task<User> GetByIdAsync(int? id);
		Task<User> GetUserByNameAsync(string name);
		Task<User> UpdateAsync(User user);
	}
}