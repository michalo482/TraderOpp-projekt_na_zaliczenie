using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Trader.WPF.Commands;
using Trader.WPF.State.Authenticators;
using Trader.WPF.State.Navigators;
using Trader.WPF.ViewModels.Factories;

namespace Trader.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ITraderViewModelAbstractFactory _traderViewModelFactory;

        public INavigator Navigator { get; set; }
        public IAuthenticator Authenticator { get; }
        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(INavigator navigator, ITraderViewModelAbstractFactory traderViewModelFactory, IAuthenticator authenticator)
        {
            Navigator = navigator;
            _traderViewModelFactory = traderViewModelFactory;
            Authenticator = authenticator;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _traderViewModelFactory);
            
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }
    }
}
