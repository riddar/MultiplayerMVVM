using MultiPlayer.BusinessObjects.Models;
using MultiPlayer.BusinessRules;
using MultiPlayer.UI.Helpers;
using System.Collections.ObjectModel;
using System.Linq;

namespace MultiPlayer.UI.ViewModels
{
	public class JoinGameViewModel : BindableBase
	{
		private IGameDataService GameDataservice = new GameDataService();
		private IMatchDataService MatchDataService = new MatchDataService();
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
			Games = new ObservableCollection<Game>(GameDataservice.GetAllGames());
		}

		private void OnJoinGame()
		{
			Match match = new Match() { UserId=LoginUser.Id, GameId=SelectedGame.Id };
			MatchDataService.CreateMatch(match);
			LoadGames();
		}

		private bool CanJoinGame()
		{
			if (SelectedGame == null)
				return false;
			if (SelectedGame.Matches.Any(m => m.User.Id == LoginUser.Id))
				return false;

			return true;
		}

		private void OnUnJoinGame()
		{
			Match match = SelectedGame.Matches.FirstOrDefault(m => m.User.Id == LoginUser.Id);
			SelectedGame.Matches.Remove(match);
			GameDataservice.UpdateGame(SelectedGame);
			LoadGames();
		}

		private bool CanUnJoinGame()
		{
			if (SelectedGame == null)
				return false;

			if (SelectedGame.Matches.Any(m => m.User.Id == LoginUser.Id))
				return true;

			return false;
		}
	}
}
