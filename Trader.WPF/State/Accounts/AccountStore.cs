using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraderOop.Domain.Models;

namespace Trader.WPF.State.Accounts
{
    internal class AccountStore : IAccountStore
    {
        public Account CurrentAccount { get; set; }
    }
}
