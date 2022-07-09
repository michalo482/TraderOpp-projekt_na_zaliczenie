using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Trader.WPF.ViewModels;
using TraderOop.Domain.Services;

namespace Trader.WPF.Commands
{
    public class SearchSymbolCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private BuyViewModel _buyViewModel;
        private ICurrencyPriceService _currencyPriceService;

        public SearchSymbolCommand(BuyViewModel buyViewModel, ICurrencyPriceService currencyPriceService)
        {
            _buyViewModel = buyViewModel;
            _currencyPriceService = currencyPriceService;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                decimal currencyPrice = await _currencyPriceService.GetPrice(_buyViewModel.Symbol);
                _buyViewModel.SearchResultSymbol = _buyViewModel.Symbol.ToUpper();
                _buyViewModel.CurrencyPrice = currencyPrice;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
