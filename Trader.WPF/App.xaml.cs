using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Trader.FinancialModelingPrepAPI.Services;
using Trader.WPF.State.Navigators;
using Trader.WPF.ViewModels;
using Trader.WPF.ViewModels.Factories;
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
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();
            
            Window mainWindow = serviceProvider.GetRequiredService<MainWindow>(); 
            mainWindow.Show();
            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<TraderOop.EntityFramework.TraderDbContextFactory>();
            services.AddSingleton<IDataService<Account>, AccountDataService>();
            services.AddSingleton<ICurrencyPriceService, CurrencyPriceService>();
            services.AddSingleton<IBuyService, BuyService>();
            services.AddSingleton<ICurrencyService, CurrencyService>();

            services.AddSingleton<ITraderViewModelAbstractFactory, TradeViewModelAbstractFactory>();
            services.AddSingleton<ITraderViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            services.AddSingleton<ITraderViewModelFactory<PortfolioViewModel>, PortfolioViewModelFactory>();
            services.AddSingleton<ITraderViewModelFactory<CurrencyListingViewModel>, CurrencyListingViewModelFactory>();

            
            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();

            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
