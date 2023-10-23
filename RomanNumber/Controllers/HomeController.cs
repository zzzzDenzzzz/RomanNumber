using Microsoft.AspNetCore.Mvc;
using RomanNumber.Models;
using System.Diagnostics;

namespace RomanNumber.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult ConvertToRoman(int number)
        {
            ViewBag.RomanNumber = ToRoman(number);

            return View("Index");
        }

        public IActionResult Index()
        {
            return View();
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

        private static string ToRoman(int number)
        {
            if (number < 1 || number > 3999)
            {
                return "Неверное число";
            }

            Dictionary<int, string> romanNumerals = new()
            {
                { 1000, "M" },
                { 900, "CM" },
                { 500, "D" },
                { 400, "CD" },
                { 100, "C" },
                { 90, "XC" },
                { 50, "L" },
                { 40, "XL" },
                { 10, "X" },
                { 9, "IX" },
                { 5, "V" },
                { 4, "IV" },
                { 1, "I" }
            };

            string result = "";
            // 553
            // 500 ==> D
            // 50  ==> L
            // 3   ==> III

            foreach (var pair in romanNumerals)
            {
                while (number >= pair.Key)
                {
                    result += pair.Value;
                    number -= pair.Key;
                }
            }

            return result;
        }
    }
}