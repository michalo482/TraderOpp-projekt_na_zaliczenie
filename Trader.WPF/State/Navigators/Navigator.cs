using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Trader.WPF.Commands;
using Trader.WPF.Models;
using Trader.WPF.ViewModels;
using Trader.WPF.ViewModels.Factories;

namespace Trader.WPF.State.Navigators
{
    public class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }



        public ICommand UpdateCurrentViewModelCommand { get; set; }
        public Navigator(ITraderViewModelAbstractFactory traderViewModelAbstractFactory)
        {
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(this, traderViewModelAbstractFactory);
        }
    }
}
