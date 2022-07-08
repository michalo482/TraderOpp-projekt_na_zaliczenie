using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Trader.FinancialModelingPrepAPI.Services;
using Trader.WPF.ViewModels;
using TraderOop.Domain;
using TraderOop.Domain.Models;
using TraderOop.Domain.Services;
using TraderOop.Domain.Services.TransactionServices;
using TraderOop.EntityFramework.Services;

namespace Trader.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            ICurrencyPriceService currencyPriceService = new CurrencyPriceService();
            IDataService<Account> accountService = new AccountDataService(new TraderOop.EntityFramework.TraderDbContextFactory());
            IBuyService buyService = new BuyService(currencyPriceService, accountService);

            Account buyer = await accountService.Get(1);

            await buyService.BuyCurrency(buyer, "USD", 200);

            Window mainWindow = new MainWindow();
            mainWindow.DataContext = new MainViewModel();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
