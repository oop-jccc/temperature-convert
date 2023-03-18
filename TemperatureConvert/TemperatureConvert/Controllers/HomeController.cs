using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TemperatureConvert.Models;

namespace TemperatureConvert.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new TemperatureConversionViewModel
            {
                TemperatureConversion = new TemperatureConversion
                {
                    Celsius = 100,
                    Fahrenheit = 212
                }
            });
        }

        [HttpPost]
        public IActionResult Index(TemperatureConversionViewModel model)
        {
            if (!double.IsNaN(model.TemperatureConversion.Celsius) && model.TemperatureConversion.LastEnteredUnit == "Celsius")
            {
                model.TemperatureConversion.Fahrenheit = model.TemperatureConversion.Celsius * 9 / 5 + 32;
            }
            else if (!double.IsNaN(model.TemperatureConversion.Fahrenheit) && model.TemperatureConversion.LastEnteredUnit == "Fahrenheit")
            {
                model.TemperatureConversion.Celsius = (model.TemperatureConversion.Fahrenheit - 32) * 5 / 9;
            }

            return View(model);
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
