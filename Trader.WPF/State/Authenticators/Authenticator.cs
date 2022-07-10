using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trader.WPF.Models;
using TraderOop.Domain.Models;
using TraderOop.Domain.Services.AuthenticationServices;

namespace Trader.WPF.State.Authenticators
{
    public class Authenticator : ObservableObject, IAuthenticator
    {

        private readonly IAuthenticationService _authenticationService;

        public Authenticator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        private Account _currentAccount;
        public Account CurrenctAccount { 
            get
            {
                return _currentAccount;
            }
            private set
            {
                _currentAccount = value;
                OnPropertyChanged(nameof(CurrenctAccount));
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }

        public bool IsLoggedIn => CurrenctAccount != null;

        public async Task<bool> Login(string username, string password)
        {
            bool success = true;

            try
            {
                CurrenctAccount = await _authenticationService.Login(username, password);
            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }

            public void Logout()
        {
            CurrenctAccount = null;
        }

        public async Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword)
        {
            return await _authenticationService.Register(email, username, password, confirmPassword);
        }
    }
}
