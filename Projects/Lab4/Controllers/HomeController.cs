using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab4.Models;
using Lab4.Contants;
using Runtime = Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
using RuntimeModels = Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using Newtonsoft.Json;
using Authoring = Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
using AuthoringModels = Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;

namespace Lab4.Controllers
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
            var model = new IndexModel();
            return View("Index", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> GetIntent(string checkText)
        {
            var model = await GetIntentModel(checkText);
            return View("Index", model);
        }

        public async Task<IActionResult> Incorrect(string checkText, string resultJson)
        {
            var model = await AddToNoneUtterance(checkText, resultJson);
            return View("Index", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<IndexModel> GetIntentModel(string checkText)
        {
            return null;
        }

        private async Task<IndexModel> AddToNoneUtterance(string checkText, string resultJson)
        {
            return null;
        }
    }
}
