using OpenExchangeRatesAPI.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenExchangeRatesAPI.Integration
{
    public class OpenExchangeRatesService : IOpenExchangeRatesService
    {
        public Result<CurrencyResponseData> GetCurrencyRates()
        {
            try
            {
                string endPoint = "https://openexchangerates.org/api/";
                string serviceName = "latest.json";
                string appId = "257f58ba818843739ed61b2448169d12";
                string fullPath = endPoint + serviceName + "?app_id=" + appId;

                var httpResponse = MakeGetRequest(fullPath);
                var jsonResponse = httpResponse.Result.Data.Content.ReadAsStringAsync().Result;

                if (httpResponse.Result.IsSuccess == false) return new Result<CurrencyResponseData> { IsSuccess = false, Message = httpResponse.Result.Message };

                return new Result<CurrencyResponseData> { Data = CurrencyResponseData.FromJson(jsonResponse), IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new Result<CurrencyResponseData> { IsSuccess = false, Message = Result.FromException(ex).Message };
            }
        }

        private async Task<Result<HttpResponseMessage>> MakeGetRequest(string fullPath)
        {
            try
            {
                HttpClient client = new HttpClient();

                var response = await client.GetAsync(fullPath);
                var jsonResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode == false) return new Result<HttpResponseMessage> { Data = null, IsSuccess = false, Message = response.ReasonPhrase + " : " + jsonResponse };

                return new Result<HttpResponseMessage> { Data = response, IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new Result<HttpResponseMessage> { Data = null, IsSuccess = false, Message = Result.FromException(ex).Message };
            }
        }
    }
}
