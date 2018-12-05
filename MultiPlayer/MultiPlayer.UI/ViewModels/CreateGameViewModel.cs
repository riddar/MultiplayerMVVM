using MultiPlayer.BusinessObjects.Models;
using MultiPlayer.UI.GameService;
using MultiPlayer.UI.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MultiPlayer.UI.ViewModels
{
	public class CreateGameViewModel : BindableBase
	{
		IGameDataService DataService = new GameDataServiceClient();
		private ObservableCollection<Game> _games;
		public ObservableCollection<Game> Games {
			get { return _games; }
			set { SetProperty(ref _games, value); OnPropertyChanged(); }
		}
		private Game _selectedGame;
		public Game SelectedGame {
			get { return _selectedGame; }
			set 
			{
				SetProperty(ref _selectedGame, value);
				DeleteGameCommand.RaiseCanExecuteChanged();
				OnPropertyChanged();
			}
		}

		private string _gameName;
		public string GameName {
			get { return _gameName; }
			set 
			{
				_gameName = value;
				CreateGameCommand.RaiseCanExecuteChanged();
				OnPropertyChanged();
			}
		}

		private User _loginUser;
		public User  LoginUser {
			get { return _loginUser; }
			set { SetProperty(ref _loginUser, value); OnPropertyChanged(); }
		}

		public RelayCommand CreateGameCommand { get; set; }
		public RelayCommand DeleteGameCommand { get; set; }

		public CreateGameViewModel() { }

		public CreateGameViewModel(User user)
		{
			LoginUser = user;
			CreateGameCommand = new RelayCommand(OnCreateGame, CanCreateGame);
			DeleteGameCommand = new RelayCommand(OnDeleteGame, CanDeleteGame);
			LoadGames();
		}

		public void LoadGames()
		{
			var games = new ObservableCollection<Game>(DataService.GetAllGames());
			Games = new ObservableCollection<Game>();
			foreach (var game in games)
			{
				if (game.Users.Any(u => u.Id == LoginUser.Id) && game.Users.Count() <= 1)
					Games.Add(game);
			}
		}

		private void OnCreateGame()
		{
			Game game = new Game();
			game.Name = GameName;
			game.Users.Add(LoginUser);
			DataService.CreateGame(game);
			Games.Add(game);
		}

		private bool CanCreateGame()
		{
			if (string.IsNullOrEmpty(GameName))
				return false;

			return true;
		}

		private void OnDeleteGame()
		{
			DataService.DeleteGame(SelectedGame);
		}

		private bool CanDeleteGame()
		{
			if (SelectedGame?.Users.Count() <= 1)
				return true;

			return false;
		}

	}
}
