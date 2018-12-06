using MultiPlayer.UI.Helpers;
using MultiPlayer.BusinessObjects.Models;
using MultiPlayer.BusinessRules;

namespace MultiPlayer.UI.ViewModels
{
	public class UserSettingsViewModel : BindableBase
	{
		IUserDataService DataService = new UserDataService();
		public RelayCommand SaveCommand { get; set; }
		public RelayCommand CancelCommand { get; set; }

		private User _loginUser;
		public User LoginUser {
			get { return _loginUser; }
			set { SetProperty(ref _loginUser, value); OnPropertyChanged(); }
		}

		public UserSettingsViewModel() { }

		public UserSettingsViewModel(User user)
		{
			LoginUser = user;
			SaveCommand = new RelayCommand(OnSave);
			CancelCommand = new RelayCommand(OnCancel);
		}

		private void OnSave()
		{
			DataService.UpdateUser(LoginUser);
		}

		private void OnCancel()
		{
			LoginUser = LoginUser;
		}


	}
}
