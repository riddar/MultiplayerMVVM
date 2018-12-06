using MultiPlayer.BusinessObjects.Models;
using MultiPlayer.BusinessRules;
using MultiPlayer.UI.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MultiPlayer.UI.ViewModels
{
	public class CreateGameViewModel : BindableBase
	{
		IGameDataService GameDataService = new GameDataService();
		IMatchDataService MatchDataService = new MatchDataService();
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
			var games = new ObservableCollection<Game>(GameDataService.GetAllGames());
			Games = new ObservableCollection<Game>();
			foreach (var game in games)
			{
				if (game.Matches.Any(m => m.User.Id == LoginUser.Id) && game.Matches.Count() <= 1)
					Games.Add(game);
			}
		}

		private void OnCreateGame()
		{
			var game = new Game();
			game.Name = GameName;
			game = GameDataService.CreateGame(game);
			Match match = new Match();
			match.UserId = LoginUser.Id;
			match.GameId = game.Id;
			MatchDataService.CreateMatch(match);
			LoadGames();
		}

		private bool CanCreateGame()
		{
			if (string.IsNullOrEmpty(GameName))
				return false;

			return true;
		}

		private void OnDeleteGame()
		{
			GameDataService.DeleteGame(SelectedGame);
		}

		private bool CanDeleteGame()
		{
			if (SelectedGame?.Matches.Count() <= 1)
				return true;

			return false;
		}

	}
}
