using MoneyManager.Main.Commands;
using MoneyManager.Main.States.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoneyManager.Main.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{
		private string _email = "Аноним";
		public string Email
		{
			get
			{
				return _email;
			}
			set
			{
				_email = value;
				OnPropertyChanged(nameof(Email));
				OnPropertyChanged(nameof(CanLogin));
			}
		}

		private string _password;
		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				_password = value;
				OnPropertyChanged(nameof(Password));
				OnPropertyChanged(nameof(CanLogin));
			}
		}
		public ICommand UpdateViewCommand { get; set; }
		public bool CanLogin => !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);

		public MessageViewModel ErrorMessageViewModel { get; }

		public string ErrorMessage
		{
			set => ErrorMessageViewModel.Message = value;
		}

		public ICommand LoginCommand { get; }

		public LoginViewModel(IAuthenticator authenticator)
		{
			ErrorMessageViewModel = new MessageViewModel();

			LoginCommand = new LoginCommand(this, authenticator);

			UpdateViewCommand = new UpdateViewCommand(MainWindow.MainView);
		}

	}
}
