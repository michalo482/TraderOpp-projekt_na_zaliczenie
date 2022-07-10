using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trader.WPF.State.Assets;

namespace Trader.WPF.ViewModels
{
    public class AssetSummaryViewModel : ViewModelBase
    {
        private readonly AssetStore _assetStore;

        private readonly ObservableCollection<StockViewModel> _topAssets;
        public IEnumerable<StockViewModel> TopAssets => _topAssets;

        public decimal AccountBalance => _assetStore.AccountBalance;
        
        

        public AssetSummaryViewModel(AssetStore assetStore)
        {
            _assetStore = assetStore;

            _topAssets = new ObservableCollection<StockViewModel>();

            _assetStore.StateChanged += AssetStore_StateChanged;

            ResetAssets();
        }

        private void AssetStore_StateChanged()
        {
            OnPropertyChanged(nameof(AccountBalance));
            ResetAssets();
        }

        private void ResetAssets()
        {
            IEnumerable<StockViewModel> assetsViewModel = (IEnumerable<StockViewModel>)_assetStore.AssetTransactions
                .GroupBy(t => t.Stock.Symbol)
                .Select(g => new StockViewModel(g.Key, g.Sum(t => t.IsPurchase ? t.Shares : -t.Shares)))
                .Where(s => s.Shares > 0)
                .OrderByDescending(s => s.Shares)
                .Take(3);

            _topAssets.Clear();

            foreach (StockViewModel asset in assetsViewModel)
            {
                _topAssets.Add(asset);
            }
        }
    }
}
