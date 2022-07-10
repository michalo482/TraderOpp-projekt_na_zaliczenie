using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Trader.WPF.State.Accounts;
using Trader.WPF.ViewModels;
using TraderOop.Domain.Models;
using TraderOop.Domain.Services.TransactionServices;

namespace Trader.WPF.Commands
{
    public class BuyCurrencyCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly BuyViewModel _buyViewModel;
        private readonly IBuyService _buyService;
        private readonly IAccountStore _accountStore;

        public BuyCurrencyCommand(BuyViewModel buyViewModel, IBuyService buyService, IAccountStore accountStore)
        {
            _buyViewModel = buyViewModel;
            _buyService = buyService;
            _accountStore = accountStore;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                Account account = await _buyService.BuyCurrency(_accountStore.CurrentAccount, _buyViewModel.Symbol, _buyViewModel.SharesToBuy);

                _accountStore.CurrentAccount = account;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
