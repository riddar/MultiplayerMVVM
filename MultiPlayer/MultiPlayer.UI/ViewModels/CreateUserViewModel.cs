using MultiPlayer.BusinessObjects.Models;
using MultiPlayer.UI.Helpers;
using MultiPlayer.UI.UserService;
using System;
using System.Windows;

namespace MultiPlayer.UI.ViewModels
{
	public class CreateUserViewModel: BindableBase
	{
		IUserDataService DataService = new UserDataServiceClient();
		public RelayCommand SaveCommand { get; set; }

		private string _Username;
		public string Username {
			get { return _Username; }
			set 
			{
				_Username = value;
				SaveCommand.RaiseCanExecuteChanged();
				OnPropertyChanged();
			}
		}

		private string _Password;
		public string Password {
			get { return _Password; }
			set { _Password = value; OnPropertyChanged(); }
		}

		private string _firstname;
		public string Firstname {
			get { return _firstname; }
			set { _firstname = value; OnPropertyChanged(); }
		}

		private string _Lastname;
		public string Lastname {
			get { return _Lastname; }
			set { _Lastname = value; OnPropertyChanged(); }
		}

		private string _Email;
		public string Email {
			get { return _Email; }
			set { _Email = value; OnPropertyChanged(); }
		}

		private Visibility _visibility;
		public Visibility Visibility {
			get { return _visibility; }
			set { _visibility = value; OnPropertyChanged(); }
		}

		public CreateUserViewModel()
		{
			SaveCommand = new RelayCommand(OnSave, CanSave);
		}

		private void OnSave() => DataService.CreateUser(new User() { Username=this.Username, Password=this.Password, Firstname=this.Firstname, Lastname=this.Lastname, Email=this.Email });

		private bool CanSave()
		{
			if (Username != null)
				return true;

			return false;
		}
	}
}
