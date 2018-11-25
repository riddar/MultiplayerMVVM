using MultiPlayer.BusinessObjects.Models;
using MultiPlayer.BusinessRules.DataServices;
using MultiPlayer.ViewModels.Helpers;
using System;
using System.Windows;

namespace MultiPlayer.ViewModels.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public UserDataService DataService;
		public RelayCommand LoginCommand { get; set; }
		public RelayCommand QuitCommand { get; set; }
		public BindableBase<string> NavCommand { get; private set; }
		public CreateGameViewModel createGameViewModel;
		public JoinGameViewModel joinGameViewModel;
		public GamesViewModel gamesViewModel;
		public UserSettingsViewModel userSettingsViewModel;
		public User User = new User();

		private ViewModelBase _CurrentViewModel;
		public ViewModelBase CurrentViewModel {
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

		private string _Username;
		public string Username {
			get { return _Username; }
			set { _Username = value; LoginCommand.RaiseCanExecuteChanged(); }
		}

		private string _Password;
		public string Password {
			get { return _Password; }
			set { _Password = value; LoginCommand.RaiseCanExecuteChanged(); }
		}

		public MainWindowViewModel()
		{
			DataService = new UserDataService();
			Visibility1 = Visibility.Visible;
			Visibility2 = Visibility.Hidden;
			LoginCommand = new RelayCommand(OnLogin, CanLogin);
			QuitCommand = new RelayCommand(OnQuit);
			NavCommand = new BindableBase<string>(OnNav);
		}

		private bool CanLogin() => Username != null;

		private async void OnLogin()
		{
			var user = await DataService.GetUserByNameAsync(Username);
			if (user != null && user?.Password == Password)
			{
				User = user;
				OnNav("UserSettings");
				Visibility1 = Visibility.Hidden;
				Visibility2 = Visibility.Visible;
			}
		}

		private void OnQuit() => Environment.Exit(0);

		private void OnNav(string destination)
		{

			switch (destination)
			{
				case "CreateGame":
					createGameViewModel = new CreateGameViewModel(User);
					CurrentViewModel = createGameViewModel;
					break;
				case "JoinGame":
					joinGameViewModel = new JoinGameViewModel(User);
					CurrentViewModel = joinGameViewModel;
					break;
				case "Games":
					gamesViewModel = new GamesViewModel(User);
					CurrentViewModel = gamesViewModel;
					break;
				case "UserSettings":
					userSettingsViewModel = new UserSettingsViewModel(User);
					CurrentViewModel = userSettingsViewModel;
					break;
				case "Logout":
					User = null;
					Visibility1 = Visibility.Visible;
					Visibility2 = Visibility.Hidden;
					CurrentViewModel = null;
					break;
				default:
					userSettingsViewModel = new UserSettingsViewModel(User);
					CurrentViewModel = userSettingsViewModel;
					break;
			}
		}
	}
}
