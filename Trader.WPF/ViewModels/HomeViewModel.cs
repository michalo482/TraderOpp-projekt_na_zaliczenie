using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trader.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public CurrencyViewModel CurrencyViewModel { get; set; }

        public HomeViewModel(CurrencyViewModel currencyViewModel)
        {
            CurrencyViewModel = currencyViewModel;
        }
    }
}
