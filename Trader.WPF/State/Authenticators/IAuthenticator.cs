using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraderOop.Domain.Models;
using TraderOop.Domain.Services.AuthenticationServices;

namespace Trader.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        Account CurrenctAccount { get; }
        bool IsLoggedIn { get; }

        event Action StateChange;
        Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);
        Task<bool> Login(string username, string password);
        void Logout();
    }
}
