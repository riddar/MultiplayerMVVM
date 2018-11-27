using MultiPlayer.BusinessObjects.Models;
using MultiPlayer.BusinessRules.DataServices;
using MultiPlayer.ViewModels.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MultiPlayer.ViewModels.ViewModels
{
	public class GamesViewModel: ViewModelBase
	{
		private GameDataService DataService { get; set; }
		public ObservableCollection<Game> Games { get; set; }

		private User _LoginUser;
		public User LoginUser {
			get { return _LoginUser; }
			set { _LoginUser = value; OnPropertyChanged(); }
		}

		private Game _SelectedGame;
		public Game SelectedGame {
			get { return _SelectedGame; }
			set { _SelectedGame = value; OnPropertyChanged(); }
		}


		public RelayCommand RemoveFromGameCommand { get; set; }

		public GamesViewModel()
		{
			var Users = new Collection<User>()
			{
				new User() { Username="test1" },
				new User() { Username="test2" },
				new User() { Username="test3" }
			};

			Games = new ObservableCollection<Game>()
			{
				new Game { Id=1, Name="test1", Users=Users },
				new Game { Id=2, Name="test2", Users=Users },
				new Game { Id=3, Name="test3", Users=Users }
			};
		}

		public GamesViewModel(User user)
		{
			DataService = new GameDataService();
			Games = new ObservableCollection<Game>();
			LoginUser = user;
			LoadGames();
			RemoveFromGameCommand = new RelayCommand(OnRemoveFromGame);
		}

		private void LoadGames()
		{
			var games = DataService.GetAll();
			foreach (var game in games)
			{
				if (game.Users.Any(u => u.Id == LoginUser.Id))
					Games.Add(game);
			}
		}

		private void OnRemoveFromGame()
		{
			throw new NotImplementedException();
		}
	}
}
