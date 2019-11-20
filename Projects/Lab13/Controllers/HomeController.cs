using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab13.Models;
using System.Net;
using Lab13.Constants;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;

namespace Lab13.Controllers
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

            var evaluationResult =  GetEvaluationResult(Images.Image1);
            result.FirstImageType = evaluationResult.ImageType;

            evaluationResult = GetEvaluationResult(Images.Image2);
            result.SecondImageType = evaluationResult.ImageType;

            evaluationResult =  GetEvaluationResult(Images.Image3);
            result.ThirdImageType = evaluationResult.ImageType;

            evaluationResult =  GetEvaluationResult(Images.Image4);
            result.FourthImageType = evaluationResult.ImageType;

            return result;

        }

        private EvaluationResult GetEvaluationResult(string imageLocation)
        {
            try
            {
                var returnValue = new EvaluationResult();

                int resize = 96;
                // Load our image into a stream
                var url = "https://" + HttpContext.Request.Host.ToString() + "/" + imageLocation;
                var request = WebRequest.Create(url);

                using (var response = request.GetResponse())
                {
                    string imageString;
                    using (var stream = response.GetResponseStream())
                    {
                        var sourceImage = Image.Load(stream);

                        var sfsd = sourceImage.PixelType;
                        var wh = sourceImage.Height;
                        var ww = sourceImage.Width;
                        sourceImage.Mutate(x => x
                            .Resize(resize, resize));
                        imageString = FromImage(sourceImage, resize, resize);
                    }

                    var uploadData = $"{{\"instances\": [{{\"flatten_5_input\": {imageString}}}]}}";

                    var request1 = (HttpWebRequest)WebRequest.Create(TensorFlowML.RegressionEndpoint);
                    request1.Method = "POST";
                    request1.ContentType = "application/json";
                    request1.ContentLength = uploadData.Length;

                    using (var webStream =  request1.GetRequestStream())
                    {
                        using (var requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
                        {
                            requestWriter.Write(uploadData);
                        }
                    }

                    var webResponse = request1.GetResponse();
                    using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            returnValue.ImageType = responseReader.ReadToEnd();
                        }
                    }

                }

                return returnValue;
            }
            catch (WebException e)
            {
                var a = e;
                using (Stream webStream = e.Response.GetResponseStream() ?? Stream.Null)
                {
                    using (StreamReader responseReader = new StreamReader(webStream))
                    {
                        var b = responseReader.ReadToEnd();
                    }
                }
                throw;
            }
        }

        public byte[] ReadFully(Stream input)
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


        public string FromImage(Image img, int height, int width)
        {
            var returnValue = "";
            returnValue += "[";
            for (var h = 0; h < height; h++)
            {
                if (h != 0)
                {
                    returnValue += ", ";
                }
                returnValue += "[";
                var data = SixLabors.ImageSharp.Advanced.AdvancedImageExtensions.GetPixelRowSpan<Rgba32>((ImageFrame<Rgba32>)img.Frames.RootFrame, h);
                for (var w = 0; w < width; w++)
                {
                    if (w != 0)
                    {
                        returnValue += ", ";
                    }
                    returnValue += "[";
                    Rgba32 dest = new Rgba32();
                    data[w].ToRgba32(ref dest);
                    returnValue += dest.R + ", ";
                    returnValue += dest.G + ", ";
                    returnValue += dest.B;
                    returnValue += "]";
                }
                returnValue += "]";
            }
            returnValue += "]";
            return returnValue;
        }
    }
}