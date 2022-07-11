using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Trader.WPF.Commands;
using Trader.WPF.State.Authenticators;
using Trader.WPF.State.Navigators;

namespace Trader.WPF.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private string _email;
        public string Email
        {
            get { return _email; }
            set { OnPropertyChanged(nameof(Email)); }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { OnPropertyChanged(nameof(Username)); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { OnPropertyChanged(nameof(Password)); }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { OnPropertyChanged(nameof(ConfirmPassword)); }
        }

        public ICommand RegisterCommand { get; }
        public ICommand ViewLoginCommand { get; }

        public MessageViewModel ErrorMessageViewModel { get; }
        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;

        }
        public RegisterViewModel(IRenavigator loginRenavigator, IAuthenticator authenticator, IRenavigator registerRenavigator)
        {
            ErrorMessageViewModel = new MessageViewModel();
            
            RegisterCommand = new RegisterCommand(this, authenticator, registerRenavigator);
            ViewLoginCommand = new RenavigateCommand(loginRenavigator);
        }
    }
}
