using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraderOop.Domain.Models;
using TraderOop.Domain.Services;

namespace Trader.WPF.ViewModels
{
    public class CurrencyViewModel
    {
        private readonly ICurrencyService _currencyService;

        

        public CurrencyModel USD { get; set; }
        public CurrencyModel CHF { get; set; }
        public CurrencyModel GBP { get; set; }

        public CurrencyViewModel(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public static CurrencyViewModel LoadCurrencyViewModel(ICurrencyService currencyService)
        {
            CurrencyViewModel currencyViewModel = new CurrencyViewModel(currencyService);
            currencyViewModel.LoadCurrencies();
            return currencyViewModel;
        }

        private void LoadCurrencies()
        {
            _currencyService.GetCurrency(CurrencyCode.USD).ContinueWith(task =>
            {
                if(task.Exception == null)
                {
                    USD = task.Result;
                }
            } );
            _currencyService.GetCurrency(CurrencyCode.CHF).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    CHF = task.Result;
                }
            }); ;
            _currencyService.GetCurrency(CurrencyCode.GBP).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    GBP = task.Result;
                }
            }); ;
        }
    }
}
