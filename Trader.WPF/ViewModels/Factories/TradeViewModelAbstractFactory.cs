using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trader.FinancialModelingPrepAPI.Services;
using Trader.WPF.State.Navigators;

namespace Trader.WPF.ViewModels.Factories
{
    public class TradeViewModelAbstractFactory : ITraderViewModelAbstractFactory
    {

        private readonly ITraderViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly ITraderViewModelFactory<PortfolioViewModel> _portfolioViewModelFactory;

        public TradeViewModelAbstractFactory(ITraderViewModelFactory<HomeViewModel> homeViewModelFactory, ITraderViewModelFactory<PortfolioViewModel> portfolioViewModelFactory)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _portfolioViewModelFactory = portfolioViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.Portfolio:
                    return _portfolioViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("No ViewModel for that ViewType", "viewType");
            }
        }
    }
}
