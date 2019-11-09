using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab2.Models;
using System.Net;
using Lab2.Constants;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training;

namespace Lab2.Controllers
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

        public async Task<IActionResult> Evaluate()
        {
            var model = await EvaluateImages();

            return View("Index", model);
        }

        public async Task<IActionResult> Incorrect(string image)
        {
            if (image != string.Empty)
            {
                await IncorrectImage(image);
            }

            var model = await EvaluateImages();

            return View("Index", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<IndexModel> EvaluateImages()
        {

            var result = new IndexModel();

            var evaluationResult = await GetEvaluationResult(Images.Image1);
            result.FirstImageType = evaluationResult.ImageType;
            result.FirstImageConfidence = evaluationResult.Confidence;

            evaluationResult = await GetEvaluationResult(Images.Image2);
            result.SecondImageType = evaluationResult.ImageType;
            result.SecondImageConfidence = evaluationResult.Confidence;

            evaluationResult = await GetEvaluationResult(Images.Image3);
            result.ThirdImageType = evaluationResult.ImageType;
            result.ThirdImageConfidence = evaluationResult.Confidence;

            evaluationResult = await GetEvaluationResult(Images.Image4);
            result.FourthImageType = evaluationResult.ImageType;
            result.FourthImageConfidence = evaluationResult.Confidence;

            return result;

        }

        private async Task<EvaluationResult> GetEvaluationResult(string imageLocation)
        {

        }

        private async Task IncorrectImage(string imageLocation)
        {
        }
    }
}