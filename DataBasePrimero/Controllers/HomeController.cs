using DataBasePrimero.AccesoViews;
using DataBasePrimero.Models;
using EntityBasicoDAL.Modelo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DataBasePrimero.Controllers
{
    public class HomeController : Controller
    {
        //Eliminamos esta linea y el parametro del metodo HomeController
        //private readonly ILogger<HomeController> _logger;
        private readonly entityBasicoContext context;

        public HomeController(entityBasicoContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var accesos = this.context.Empleados.Include(a => a.NivelAccesos).Select(m => new AccesoViewModel
            {
                nombre = m.NombreEmpleado,
                nivel = String.Join(", ", m.NivelAccesos.Select(a => a.NivelAcceso1)),
                desc = String.Join(", ", m.NivelAccesos.Select(a => a.DescAcceso))

            });
            return View(accesos);
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
    }
}