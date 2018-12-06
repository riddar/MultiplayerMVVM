using MultiPlayer.UI.Helpers;
using System;
using System.Windows;
using MultiPlayer.BusinessObjects.Models;
using MultiPlayer.BusinessRules;

namespace MultiPlayer.UI.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		public IUserDataService DataService; 
		private BindableBase _CurrentViewModel;
		public BindableBase CurrentViewModel 
		{
			get { return _CurrentViewModel; }
			set { SetProperty(ref _CurrentViewModel, value); }
		}
		private Visibility _visibility1;
		public Visibility Visibility1 {
			get { return _visibility1; }
			set { _visibility1 = value; OnPropertyChanged(); }
		}
		private Visibility _visibility2;
		public Visibility Visibility2 {
			get { return _visibility2; }
			set { _visibility2 = value; OnPropertyChanged(); }
		}
		private Visibility _visibility3;
		public Visibility Visibility3 {
			get { return _visibility3; }
			set { _visibility3 = value; OnPropertyChanged(); }
		}
		private string _Username;
		public string Username 
		{
			get { return _Username; }
			set 
			{
				_Username = value;
				LoginCommand.RaiseCanExecuteChanged();
				OnPropertyChanged();
			}
		}
		private string _Password;
		public string Password 
		{
			get { return _Password; }
			set 
			{
				_Password = value;
				LoginCommand.RaiseCanExecuteChanged();
				OnPropertyChanged();
			}
		}
		private User _loginUser;
		public User LoginUser 
		{
			get { return _loginUser; }
			set { SetProperty(ref _loginUser, value); OnPropertyChanged(); }
		}

		private CreateGameViewModel _createGameViewModel;
		private JoinGameViewModel _joinGameViewModel;
		private UserSettingsViewModel _userSettingsViewModel;
		private CreateUserViewModel _createUserViewModel;

		public RelayCommand LoginCommand { get; set; }
		public RelayCommand QuitCommand { get; set; }
		public RelayCommand<string> NavCommand { get; private set; }

		public MainWindowViewModel()
		{
			DataService = new UserDataService();
			Visibility1 = Visibility.Visible;
			Visibility2 = Visibility.Hidden;
			Visibility3 = Visibility.Hidden;
			LoginCommand = new RelayCommand(OnLogin, CanLogin);
			QuitCommand = new RelayCommand(OnQuit);
			NavCommand = new RelayCommand<string>(OnNav);
		}

		private bool CanLogin() => Username != null;

		private void OnLogin()
		{
			var user = DataService.GetUserByName(Username);
			if (user != null && user?.Password == Password)
			{
				LoginUser = user;
				Visibility1 = Visibility.Hidden;
				Visibility2 = Visibility.Visible;
				Visibility3 = Visibility.Visible;
			}
		}

		private void OnQuit() => Environment.Exit(0);

		private void OnNav(string destination)
		{
			switch (destination)
			{
				case "CreateGame":
					_createGameViewModel = new CreateGameViewModel(LoginUser);
					CurrentViewModel = _createGameViewModel;
					break;
				case "JoinGame":
					_joinGameViewModel = new JoinGameViewModel(LoginUser);
					CurrentViewModel = _joinGameViewModel;
					break;
				case "UserSettings":
					_userSettingsViewModel = new UserSettingsViewModel(LoginUser);
					CurrentViewModel = _userSettingsViewModel;
					break;
				case "CreateUser":
					_createUserViewModel = new CreateUserViewModel();
					CurrentViewModel = _createUserViewModel;
					Visibility1 = Visibility.Hidden;
					Visibility2 = Visibility.Visible;
					Visibility3 = Visibility.Hidden;
					break;
				case "Logout":
					LoginUser = null;
					Visibility1 = Visibility.Visible;
					Visibility2 = Visibility.Hidden;
					Visibility3 = Visibility.Hidden;
					CurrentViewModel = null;
					break;
				default:
					_joinGameViewModel = new JoinGameViewModel(LoginUser);
					CurrentViewModel = _joinGameViewModel;
					break;
			}
		}
	}
}
