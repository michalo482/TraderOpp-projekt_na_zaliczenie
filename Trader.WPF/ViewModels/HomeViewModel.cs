using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trader.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public CurrencyListingViewModel CurrencyListingViewModel { get; set; }

        public HomeViewModel(CurrencyListingViewModel currencyListingViewModel)
        {
            CurrencyListingViewModel = currencyListingViewModel;
        }
    }
}
