using OpenExchangeRatesAPI.Data;
using OpenExchangeRatesAPI.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenExchangeRatesAPI.Service
{
    public class CurrencyManagerService : ICurrencyManagerService
    {
        IOpenExchangeRatesService _openExchangeRatesService;

        public CurrencyManagerService()
        {
            _openExchangeRatesService = new OpenExchangeRatesService();
        }
        public List<CurrencyExchangeData> GetLiveCurrencies()
        {
            try
            {
                var currencyData = _openExchangeRatesService.GetCurrencyRates();

                if (currencyData.IsSuccess == false) return null;

                return currencyData.Data.Rates.Select(x => new CurrencyExchangeData { Currency = x.Key, ExchangeValue = x.Value }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
