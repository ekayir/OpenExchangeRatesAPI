using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenExchangeRatesAPI.Models;
using OpenExchangeRatesAPI.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OpenExchangeRatesAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICurrencyManagerService _currencyManagerService;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _currencyManagerService = new CurrencyManagerService();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Currency()
        {
            return View(new CurrencyViewModel { Currencies = _currencyManagerService.GetLiveCurrencies() });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
