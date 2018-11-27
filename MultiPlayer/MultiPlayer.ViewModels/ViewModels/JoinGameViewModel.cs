using MultiPlayer.BusinessObjects.Models;
using MultiPlayer.BusinessRules.DataServices;
using MultiPlayer.ViewModels.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MultiPlayer.ViewModels.ViewModels
{
	public class JoinGameViewModel : ViewModelBase
	{
		private GameDataService DataService { get; set; }

		private ObservableCollection<Game> _Games;
		public ObservableCollection<Game> Games {
			get { return _Games; }
			set { _Games = value; OnPropertyChanged(); }
		}

		private ObservableCollection<User> _Users;
		public ObservableCollection<User> Users {
			get { return _Users; }
			set { _Users = value; OnPropertyChanged(); }
		}

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

		public RelayCommand JoinGame { get; set; }

		public JoinGameViewModel()
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

		public JoinGameViewModel(User user)
		{
			LoginUser = user;
			DataService = new GameDataService();	
			Games = new ObservableCollection<Game>();
			IEnumerable<Game> games = DataService.GetAll();
			foreach (var game in games)
			{
				if (!game.Users.Any(u => u.Id == LoginUser.Id))
					Games.Add(game);
			}

			JoinGame = new RelayCommand(OnJoinGame);
		}

		private void OnJoinGame()
		{
			SelectedGame.Users.Add(LoginUser);
			DataService.Update(SelectedGame);
		}
	}
}
