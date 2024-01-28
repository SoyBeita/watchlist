using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using watchlist.Conexion_BBDD;
using watchlist.Models;
using watchlist.Models.PeliculasYSeriesDto;
using watchlist.Servicios;

namespace watchlist.Controllers
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
            return View();
        }

        public IActionResult VistaDatos(Login datosLogin)
        {
            //Obtengo la lista de peliculas y series de este usuario

            PeliculasYSeriesService peliculasYSeriesService = new PeliculasYSeriesService(datosLogin.Usuario);
            PeliculasYSeriesDto peliculasYSeries = peliculasYSeriesService.ObtenerListaPeliculasSeries();



            return View(peliculasYSeries);
        }

      

    
    }
}
