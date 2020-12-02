using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class SumadoraController : Controller
    {
        // GET: Sumadora
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Operacion, int num1, int num2)
        {
            int resultado;
            switch (Operacion)
            {
                case "+":
                    resultado = num1 + num2;
                    ViewBag.resultado = resultado;
                    break;
                case "-":
                    resultado = num1 - num2;
                    ViewBag.resultado = resultado;
                    break;
                case "x":
                    resultado = num1 * num2;
                    ViewBag.resultado = resultado;
                    break;
                case "/":
                    resultado = num1 / num2;
                    ViewBag.resultado = resultado;
                    break;

            }
            return View();
        }
        [HttpGet]
        public ActionResult CalcularTemperatura()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CalcularTemperatura(string Convertir, double valor)
        {
            double result;
            switch (Convertir)
            {
                case "Farenheit":
                    result = (valor * 1.8) + 32;
                    ViewBag.result = result;
                    break;
                case "Celsius":
                    result = (valor - 32)/ 1.8;
                    ViewBag.result = result;
                    break;
            }
            return View();
        }
        [HttpGet]
        public ActionResult CalcularMoneda()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CalcularMoneda(string Conversor, double valor)
        {
            double resultado;
            switch (Conversor)
            {
                case "Dolares":
                    resultado = 58.61 * valor;
                    ViewBag.resultado = resultado;
                    break;
                case "Peso":
                    resultado = 0.017 * valor;
                    ViewBag.resultado = resultado;
                    break;
            }
            return View();
        }
    }
}