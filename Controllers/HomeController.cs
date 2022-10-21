using Calculadora.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Calculadora.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Calcu calc) {
            int a, b;
            a = calc.value1;
            b = calc.value2;
            if (calc.Acao == "somar") {
            calc.resultado = a + b;
            }else if (calc.Acao == "subtrair") {
                calc.resultado = a - b;
            } else if (calc.Acao == "dividir") {
                calc.resultado = a / b;
            } else if (calc.Acao == "multiplicar") {
                calc.resultado = a * b;
            } else if (calc.Acao == "Limpar") {
                calc.resultado = 0;
                calc.value1 = 0;
                calc.value2=0;
            }

            ViewData["resultado"]= calc.resultado;
                return View();
        }
        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}