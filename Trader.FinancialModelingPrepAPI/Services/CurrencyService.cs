using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraderOop.Domain.Models;
using TraderOop.Domain.Services;

namespace Trader.FinancialModelingPrepAPI.Services
{
    public class CurrencyService : ICurrencyService
    {
        public async Task<CurrencyModel> GetCurrency(CurrencyCode currencyCode)
        {
            string uri = $"https://api.nbp.pl/api/exchangerates/rates/A/{currencyCode}/today/?format=json";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response =  await client.GetAsync(uri);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                CurrencyModel currency = JsonConvert.DeserializeObject<CurrencyModel>(jsonResponse);    
                
                return currency;
            }
        }
    }
}
