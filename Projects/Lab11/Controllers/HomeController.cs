using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab11.Models;
using Lab11.Constants;
using System.Net;
using System.IO;

namespace Lab11.Controllers
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
            return View(new IndexModel());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> GetPrediction(string yearToPredict)
        {
            var returnValue = await Predict(yearToPredict);
            return View("Index", returnValue);
        }

        private async Task<IndexModel> Predict(string yearToPredict)
        {
            throw new NotImplementedException();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
