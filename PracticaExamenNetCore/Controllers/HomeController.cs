using Microsoft.AspNetCore.Mvc;
using PracticaExamenNetCore.Models;
using PracticaExamenNetCore.Repositories;
using System.Diagnostics;

namespace PracticaExamenNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private RepositorySeriesPersonajes repo;
        public HomeController(ILogger<HomeController> logger, RepositorySeriesPersonajes repo)
        {
            _logger = logger;
            this.repo= repo;
        }

        public async Task<IActionResult> Index(int? posicion, int idserie)
        {
            if (posicion == null)
            {
                posicion = 1;
                return View();
            }
            else
            {
                ViewBag.IDSERIE = idserie;
                PaginarPersonajes model = await this.repo.GetGrupoPersonajesSerieAsync(posicion.Value, idserie);
                List<Personaje> personajes = model.Personajes;
                int numRegistros = model.NumRegistros;
                ViewBag.REGISTROS = numRegistros;
                //ViewBag.RANGO = (int)model.Rango;
                return View(personajes);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Index(int? idserie)
        {
            int posicion = 1;
            ViewBag.IDSERIE = idserie;
            PaginarPersonajes model = await this.repo.GetGrupoPersonajesSerieAsync(posicion, idserie.Value);
            List<Personaje> personajes = model.Personajes;
            int numRegistros = model.NumRegistros;
            ViewBag.REGISTROS = numRegistros;
            //ViewBag.RANGO = (int)model.Rango;
            return View(personajes);
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