using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OpenExchangeRatesAPI.Data
{

    public partial class CurrencyResponseData
    {
        [JsonProperty("disclaimer")]
        public string Disclaimer { get; set; }

        [JsonProperty("license")]
        public Uri License { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("rates")]
        public Dictionary<string, decimal> Rates { get; set; }
    }

    public partial class CurrencyResponseData
    {
        public static CurrencyResponseData FromJson(string json) => JsonConvert.DeserializeObject<CurrencyResponseData>(json, OpenExchangeRatesAPI.Data.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this CurrencyResponseData self) => JsonConvert.SerializeObject(self, OpenExchangeRatesAPI.Data.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
