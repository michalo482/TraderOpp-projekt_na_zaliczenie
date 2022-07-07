using Trader.FinancialModelingPrepAPI.Services;

namespace Testy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new MajorIndexService().GetMajorIndex(TraderOop.Domain.Models.CurrencyCode.USD)
                .ContinueWith(t =>
                {
                    var index = t.Result;
                    Console.WriteLine(index);
                });

            
        }
    }
}