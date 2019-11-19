using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab5.Models;
using Microsoft.Azure.CognitiveServices.AnomalyDetector;
using Lab5.Constants;
using Microsoft.Azure.CognitiveServices.AnomalyDetector.Models;
using Newtonsoft.Json;

namespace Lab5.Controllers
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

        public async Task<IActionResult> Check2020Sat(int mathSat)
        {
            var model = await CheckLatestSat(mathSat);

            return View("Index", model);
        }

        public async Task<IActionResult> CheckAllExtremeSnowDays()
        {
            var model = await CheckAllSnowDays();

            return View("Index", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<IndexModel> CheckLatestSat(int mathSat)
        {
            throw new NotImplementedException();
        }

        private async Task<IndexModel> CheckAllSnowDays()
        {
            throw new NotImplementedException();
        }

        private List<Point> GetAverageMathSatScore()
        {
            return new List<Point>
            {
                new Point { Timestamp = DateTime.Parse("1/1/1972"), Value = 509 },
                new Point { Timestamp = DateTime.Parse("1/1/1973"), Value = 506 },
                new Point { Timestamp = DateTime.Parse("1/1/1974"), Value = 505 },
                new Point { Timestamp = DateTime.Parse("1/1/1975"), Value = 498 },
                new Point { Timestamp = DateTime.Parse("1/1/1976"), Value = 497 },
                new Point { Timestamp = DateTime.Parse("1/1/1977"), Value = 496 },
                new Point { Timestamp = DateTime.Parse("1/1/1978"), Value = 494 },
                new Point { Timestamp = DateTime.Parse("1/1/1979"), Value = 493 },
                new Point { Timestamp = DateTime.Parse("1/1/1980"), Value = 492 },
                new Point { Timestamp = DateTime.Parse("1/1/1981"), Value = 492 },
                new Point { Timestamp = DateTime.Parse("1/1/1982"), Value = 493 },
                new Point { Timestamp = DateTime.Parse("1/1/1983"), Value = 494 },
                new Point { Timestamp = DateTime.Parse("1/1/1984"), Value = 497 },
                new Point { Timestamp = DateTime.Parse("1/1/1985"), Value = 500 },
                new Point { Timestamp = DateTime.Parse("1/1/1986"), Value = 500 },
                new Point { Timestamp = DateTime.Parse("1/1/1987"), Value = 501 },
                new Point { Timestamp = DateTime.Parse("1/1/1988"), Value = 501 },
                new Point { Timestamp = DateTime.Parse("1/1/1989"), Value = 510 },
                new Point { Timestamp = DateTime.Parse("1/1/1990"), Value = 501 },
                new Point { Timestamp = DateTime.Parse("1/1/1991"), Value = 500 },
                new Point { Timestamp = DateTime.Parse("1/1/1992"), Value = 501 },
                new Point { Timestamp = DateTime.Parse("1/1/1993"), Value = 503 },
                new Point { Timestamp = DateTime.Parse("1/1/1994"), Value = 504 },
                new Point { Timestamp = DateTime.Parse("1/1/1995"), Value = 506 },
                new Point { Timestamp = DateTime.Parse("1/1/1996"), Value = 508 },
                new Point { Timestamp = DateTime.Parse("1/1/1997"), Value = 511 },
                new Point { Timestamp = DateTime.Parse("1/1/1998"), Value = 512 },
                new Point { Timestamp = DateTime.Parse("1/1/1999"), Value = 511 },
                new Point { Timestamp = DateTime.Parse("1/1/2000"), Value = 514 },
                new Point { Timestamp = DateTime.Parse("1/1/2001"), Value = 514 },
                new Point { Timestamp = DateTime.Parse("1/1/2002"), Value = 516 },
                new Point { Timestamp = DateTime.Parse("1/1/2003"), Value = 519 },
                new Point { Timestamp = DateTime.Parse("1/1/2004"), Value = 518 },
                new Point { Timestamp = DateTime.Parse("1/1/2005"), Value = 520 },
                new Point { Timestamp = DateTime.Parse("1/1/2006"), Value = 518 },
                new Point { Timestamp = DateTime.Parse("1/1/2007"), Value = 514 },
                new Point { Timestamp = DateTime.Parse("1/1/2008"), Value = 514 },
                new Point { Timestamp = DateTime.Parse("1/1/2009"), Value = 514 },
                new Point { Timestamp = DateTime.Parse("1/1/2010"), Value = 515 },
                new Point { Timestamp = DateTime.Parse("1/1/2011"), Value = 514 },
                new Point { Timestamp = DateTime.Parse("1/1/2012"), Value = 514 },
                new Point { Timestamp = DateTime.Parse("1/1/2013"), Value = 514 },
                new Point { Timestamp = DateTime.Parse("1/1/2014"), Value = 513 },
                new Point { Timestamp = DateTime.Parse("1/1/2015"), Value = 511 },
                new Point { Timestamp = DateTime.Parse("1/1/2016"), Value = 508 },
                new Point { Timestamp = DateTime.Parse("1/1/2017"), Value = 527 },
                new Point { Timestamp = DateTime.Parse("1/1/2018"), Value = 531 },
                new Point { Timestamp = DateTime.Parse("1/1/2019"), Value = 528 },
            };
        }

        private List<Point> GetExtremeSnowDepthDaysInAlbany()
        {
            return new List<Point>
            {
                new Point { Timestamp = DateTime.Parse("1/1/1939"), Value = 14 },
                new Point { Timestamp = DateTime.Parse("1/1/1940"), Value = 10 },
                new Point { Timestamp = DateTime.Parse("1/1/1941"), Value = 10 },
                new Point { Timestamp = DateTime.Parse("1/1/1942"), Value = 7 },
                new Point { Timestamp = DateTime.Parse("1/1/1943"), Value = 13 },
                new Point { Timestamp = DateTime.Parse("1/1/1944"), Value = 10 },
                new Point { Timestamp = DateTime.Parse("1/1/1945"), Value = 19 },
                new Point { Timestamp = DateTime.Parse("1/1/1946"), Value = 14 },
                new Point { Timestamp = DateTime.Parse("1/1/1947"), Value = 18 },
                new Point { Timestamp = DateTime.Parse("1/1/1948"), Value = 26 },
                new Point { Timestamp = DateTime.Parse("1/1/1949"), Value = 8 },
                new Point { Timestamp = DateTime.Parse("1/1/1950"), Value = 16 },
                new Point { Timestamp = DateTime.Parse("1/1/1951"), Value = 12 },
                new Point { Timestamp = DateTime.Parse("1/1/1952"), Value = 12 },
                new Point { Timestamp = DateTime.Parse("1/1/1953"), Value = 14 },
                new Point { Timestamp = DateTime.Parse("1/1/1954"), Value = 11 },
                new Point { Timestamp = DateTime.Parse("1/1/1955"), Value = 7 },
                new Point { Timestamp = DateTime.Parse("1/1/1956"), Value = 20 },
                new Point { Timestamp = DateTime.Parse("1/1/1957"), Value = 7 },
                new Point { Timestamp = DateTime.Parse("1/1/1958"), Value = 22 },
                new Point { Timestamp = DateTime.Parse("1/1/1959"), Value = 12 },
                new Point { Timestamp = DateTime.Parse("1/1/1960"), Value = 13 },
                new Point { Timestamp = DateTime.Parse("1/1/1961"), Value = 19 },
                new Point { Timestamp = DateTime.Parse("1/1/1962"), Value = 17 },
                new Point { Timestamp = DateTime.Parse("1/1/1963"), Value = 17 },
                new Point { Timestamp = DateTime.Parse("1/1/1964"), Value = 16 },
                new Point { Timestamp = DateTime.Parse("1/1/1965"), Value = 10 },
                new Point { Timestamp = DateTime.Parse("1/1/1966"), Value = 19 },
                new Point { Timestamp = DateTime.Parse("1/1/1967"), Value = 13 },
                new Point { Timestamp = DateTime.Parse("1/1/1968"), Value = 9 },
                new Point { Timestamp = DateTime.Parse("1/1/1969"), Value = 36 },
                new Point { Timestamp = DateTime.Parse("1/1/1970"), Value = 36 },
                new Point { Timestamp = DateTime.Parse("1/1/1971"), Value = 22 },
                new Point { Timestamp = DateTime.Parse("1/1/1972"), Value = 13 },
                new Point { Timestamp = DateTime.Parse("1/1/1973"), Value = 11 },
                new Point { Timestamp = DateTime.Parse("1/1/1974"), Value = 11 },
                new Point { Timestamp = DateTime.Parse("1/1/1975"), Value = 12 },
                new Point { Timestamp = DateTime.Parse("1/1/1976"), Value = 14 },
                new Point { Timestamp = DateTime.Parse("1/1/1977"), Value = 11 },
                new Point { Timestamp = DateTime.Parse("1/1/1978"), Value = 23 },
                new Point { Timestamp = DateTime.Parse("1/1/1979"), Value = 10 },
                new Point { Timestamp = DateTime.Parse("1/1/1980"), Value = 10 },
                new Point { Timestamp = DateTime.Parse("1/1/1981"), Value = 14 },
                new Point { Timestamp = DateTime.Parse("1/1/1982"), Value = 13 },
                new Point { Timestamp = DateTime.Parse("1/1/1983"), Value = 19 },
                new Point { Timestamp = DateTime.Parse("1/1/1984"), Value = 15 },
                new Point { Timestamp = DateTime.Parse("1/1/1985"), Value = 9 },
                new Point { Timestamp = DateTime.Parse("1/1/1986"), Value = 12 },
                new Point { Timestamp = DateTime.Parse("1/1/1987"), Value = 21 },
                new Point { Timestamp = DateTime.Parse("1/1/1988"), Value = 15 },
                new Point { Timestamp = DateTime.Parse("1/1/1989"), Value = 5 },
                new Point { Timestamp = DateTime.Parse("1/1/1990"), Value = 8 },
                new Point { Timestamp = DateTime.Parse("1/1/1991"), Value = 9 },
                new Point { Timestamp = DateTime.Parse("1/1/1992"), Value = 4 },
                new Point { Timestamp = DateTime.Parse("1/1/1993"), Value = 28 },
                new Point { Timestamp = DateTime.Parse("1/1/1994"), Value = 18 },
                new Point { Timestamp = DateTime.Parse("1/1/1995"), Value = 13 },
                new Point { Timestamp = DateTime.Parse("1/1/1997"), Value = 11 },
                new Point { Timestamp = DateTime.Parse("1/1/1998"), Value = 6 },
                new Point { Timestamp = DateTime.Parse("1/1/1999"), Value = 10 },
                new Point { Timestamp = DateTime.Parse("1/1/2000"), Value = 14 },
                new Point { Timestamp = DateTime.Parse("1/1/2001"), Value = 13 },
                new Point { Timestamp = DateTime.Parse("1/1/2002"), Value = 16 },
                new Point { Timestamp = DateTime.Parse("1/1/2003"), Value = 24 },
                new Point { Timestamp = DateTime.Parse("1/1/2004"), Value = 8 },
                new Point { Timestamp = DateTime.Parse("1/1/2005"), Value = 13 },
                new Point { Timestamp = DateTime.Parse("1/1/2006"), Value = 5 },
                new Point { Timestamp = DateTime.Parse("1/1/2007"), Value = 13 },
                new Point { Timestamp = DateTime.Parse("1/1/2008"), Value = 13 },
                new Point { Timestamp = DateTime.Parse("1/1/2009"), Value = 10 },
                new Point { Timestamp = DateTime.Parse("1/1/2010"), Value = 10 },
                new Point { Timestamp = DateTime.Parse("1/1/2011"), Value = 19 },
                new Point { Timestamp = DateTime.Parse("1/1/2012"), Value = 10 },
                new Point { Timestamp = DateTime.Parse("1/1/2013"), Value = 11 },
                new Point { Timestamp = DateTime.Parse("1/1/2014"), Value = 18 },
                new Point { Timestamp = DateTime.Parse("1/1/2015"), Value = 17 },
                new Point { Timestamp = DateTime.Parse("1/1/2016"), Value = 4 },
                new Point { Timestamp = DateTime.Parse("1/1/2017"), Value = 15 },
                new Point { Timestamp = DateTime.Parse("1/1/2018"), Value = 14 },
            };
        }
    }
}
