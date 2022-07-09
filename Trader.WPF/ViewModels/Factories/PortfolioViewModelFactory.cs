using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trader.WPF.ViewModels.Factories
{
    public class PortfolioViewModelFactory : ITraderViewModelFactory<PortfolioViewModel>
    {

        public PortfolioViewModel CreateViewModel()
        {
            return new PortfolioViewModel();
        }
    }

}
