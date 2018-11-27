using MultiPlayer.BusinessObjects.Models;
using MultiPlayer.BusinessRules.DataServices;
using MultiPlayer.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlayer.ViewModels.ViewModels
{
	public class UserSettingsViewModel: ViewModelBase
	{
		public UserDataService DataService { get; set; }
		public RelayCommand SaveCommand;

		private User _LoginUser;
		public User LoginUser {
			get { return _LoginUser; }
			set { _LoginUser = value; OnPropertyChanged(); }
		}

		public UserSettingsViewModel()
		{
			LoginUser = new User() { Id=1, Username="test", Password="test", Firstname="test", Lastname="test", Email="test@gmail.com" };
		}

		public UserSettingsViewModel(User user)
		{
			DataService = new UserDataService();
			LoginUser = user;
			SaveCommand = new RelayCommand(OnSave);
		}

		private async void OnSave()
		{
			await DataService.UpdateAsync(LoginUser);
		}
	}
}
