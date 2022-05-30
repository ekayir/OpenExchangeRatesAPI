using OpenExchangeRatesAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenExchangeRatesAPI.Integration
{
    public interface IOpenExchangeRatesService
    {
        Result<CurrencyResponseData> GetCurrencyRates();
    }
}
