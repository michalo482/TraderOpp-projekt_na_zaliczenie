using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Trader.WPF.ViewModels;
using TraderOop.Domain.Models;
using TraderOop.Domain.Services.TransactionServices;

namespace Trader.WPF.Commands
{
    public class BuyCurrencyCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private BuyViewModel _buyViewModel;
        private IBuyService _buyService;

        public BuyCurrencyCommand(BuyViewModel buyViewModel, IBuyService buyService)
        {
            _buyViewModel = buyViewModel;
            _buyService = buyService;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                Account account = await _buyService.BuyCurrency(new Account()
                {
                    Id = 1,
                    Balance = 500,
                    AssetTransactions = new List<AssetTransaction>()
                }, _buyViewModel.Symbol, _buyViewModel.SharesToBuy);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
