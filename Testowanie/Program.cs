// See https://aka.ms/new-console-template for more information


using Trader.FinancialModelingPrepAPI.Services;

new MajorIndexService().GetMajorIndex(TraderOop.Domain.Models.CurrencyCode.USD)
                .ContinueWith(t =>
                {
                    var index = t.Result;
                });
