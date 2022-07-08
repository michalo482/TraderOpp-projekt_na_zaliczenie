using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderOop.Domain.Services
{
    public interface ICurrencyPriceService
    {
        Task<decimal> GetPrice(string symbol);
    }
}
