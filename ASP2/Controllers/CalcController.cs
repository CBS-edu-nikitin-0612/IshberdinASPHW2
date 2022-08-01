using Microsoft.AspNetCore.Mvc;
using System;

namespace ASP2.Controllers
{
    public class CalcController : Controller
    {
        public IActionResult Add(int x, int y)
        {
            int result = x + y;
            return View("Index", result.ToString());
        }
        public IActionResult Mul(int x, int y)
        {
            int result = x * y;
            return View("Index", result.ToString());
        }
        public IActionResult Div(int x, int y)
        {
            string result;
			if (y == 0)
			{
                result = "Деление на ноль";
			}
            else result = (Convert.ToDouble(x) / y).ToString();
            return View("Index", result);
        }
        public IActionResult Sub(int x, int y)
        {
            int result = x - y;
            return View("Index", result.ToString());
        }
    }
}
