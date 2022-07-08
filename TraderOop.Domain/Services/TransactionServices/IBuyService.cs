using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraderOop.Domain.Models;

namespace TraderOop.Domain.Services.TransactionServices
{
    public interface IBuyService
    {
        Task<Account> BuyCurrency(Account buyer, string symbol, int amount);
    }
}
