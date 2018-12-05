using MultiPlayer.BusinessObjects.Models;
using MultiPlayer.UI.GameService;
using MultiPlayer.UI.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MultiPlayer.UI.ViewModels
{
	public class JoinGameViewModel : BindableBase
	{
		private IGameDataService Dataservice = new GameDataServiceClient();
		private ObservableCollection<Game> _games;
		public ObservableCollection<Game> Games 
		{
			get { return _games; }
			set { SetProperty(ref _games, value); OnPropertyChanged(); }
		}

		private Game _selectedGame;
		public Game SelectedGame 
		{
			get { return _selectedGame; }
			set 
			{
				SetProperty(ref _selectedGame, value);
				JoinGameCommand.RaiseCanExecuteChanged();
				UnJoinGameCommand.RaiseCanExecuteChanged();
				OnPropertyChanged();
			}
		}
		private User _loginUser;
		public User LoginUser {
			get { return _loginUser; }
			set { SetProperty(ref _loginUser, value); OnPropertyChanged(); }
		}


		public RelayCommand JoinGameCommand { get; set; }
		public RelayCommand UnJoinGameCommand { get; set; }

		public JoinGameViewModel() { }

		public JoinGameViewModel(User user)
		{
			LoginUser = user;
			JoinGameCommand = new RelayCommand(OnJoinGame, CanJoinGame);
			UnJoinGameCommand = new RelayCommand(OnUnJoinGame, CanUnJoinGame);
			LoadGames();
		}

		public void LoadGames()
		{
			var games = new ObservableCollection<Game>(Dataservice.GetAllGames());
			Games = new ObservableCollection<Game>();
			foreach (var game in games)
			{
				//if (game.Users.Any(u => u.Id == LoginUser.Id))
				//	continue;
				//else
					Games.Add(game);
			}
		}

		private void OnJoinGame()
		{
			Game game = new Game();
			game.Name = SelectedGame.Name;
			game.Id = SelectedGame.Id;
			foreach (var user in SelectedGame.Users )
			{
				game.Users.Add(user);
			}
			game.Users.Add(LoginUser);
			Dataservice.UpdateGame(game);
		}

		private bool CanJoinGame()
		{
			if (SelectedGame == null)
				return false;
			if (SelectedGame.Users.Any(u => u.Id == LoginUser.Id))
				return false;

			return true;
		}

		private void OnUnJoinGame()
		{
			Game game = new Game();
			game.Name = SelectedGame.Name;
			game.Id = SelectedGame.Id;
			foreach (var user in SelectedGame.Users)
			{
				game.Users.Add(user);
			}
			game.Users.Remove(LoginUser);
			Dataservice.UpdateGame(game);
		}

		private bool CanUnJoinGame()
		{
			if (SelectedGame == null)
				return false;

			if (SelectedGame.Users.Any(u => u.Id == LoginUser.Id))
				return true;

			return false;
		}
	}
}
