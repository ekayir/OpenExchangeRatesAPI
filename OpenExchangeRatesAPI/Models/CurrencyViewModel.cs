using OpenExchangeRatesAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenExchangeRatesAPI.Models
{
    public class CurrencyViewModel
    {
        public List<CurrencyExchangeData> Currencies { get; set; }
    }
}
