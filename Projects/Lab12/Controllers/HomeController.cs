using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab12.Models;
using System.Net;
using Lab12.Constants;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats;

namespace Lab12.Controllers
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

            evaluationResult = await GetEvaluationResult(Images.Image2);
            result.SecondImageType = evaluationResult.ImageType;

            evaluationResult = await GetEvaluationResult(Images.Image3);
            result.ThirdImageType = evaluationResult.ImageType;

            evaluationResult = await GetEvaluationResult(Images.Image4);
            result.FourthImageType = evaluationResult.ImageType;

            return result;

        }

        private async Task<EvaluationResult> GetEvaluationResult(string imageLocation)
        {
            int resize = 96;
            // Load our image into a stream
            var url = "https://" + HttpContext.Request.Host.ToString() + "/" + imageLocation;
            var request = WebRequest.Create(url);

            using (var response = await request.GetResponseAsync())
            {
                string base64String;
                using (var stream = response.GetResponseStream())
                {
                    var sourceImage = Image.Load(stream);
                    sourceImage.Mutate(x => x
                        .Resize(resize, resize)
                        .Grayscale());
                    using(var ms = new MemoryStream())
                    {
                        
                        //sourceImage.Save(ms, IImageEncoder.);
                    }

                    byte[] imageBytes = ReadFully(stream);
                    base64String = Convert.ToBase64String(imageBytes);


                    //var resizedImage = ResizeImage(image, resize, resize);
                }
            }

            return null;
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public Image ResizeImage(Image image, int width, int height)
        {

            image.Resize() .Mutate(x => x
                 .Resize(image.Width / 2, image.Height / 2)
                 .Grayscale());
            return destImage;
        }
    }
}