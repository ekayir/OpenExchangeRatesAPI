using OpenExchangeRatesAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenExchangeRatesAPI.Service
{
    public interface ICurrencyManagerService
    {
        List<CurrencyExchangeData> GetLiveCurrencies();
    }
}
