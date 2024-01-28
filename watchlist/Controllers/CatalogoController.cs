using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using watchlist.Models.Catalogo;
using watchlist.Models.PeliculasYSeriesDto;
using watchlist.Servicios;

namespace watchlist.Controllers
{
    public class CatalogoController : Controller    
    {
        [HttpPost]
        public ActionResult DatosListaUsuario(string usuario, string idLista)
        {
            CatalogoService catalogoService = new CatalogoService(usuario);
            List<DatosPeliculasYSeriesDto>  listaSeriesYPeliculas = catalogoService.ObtenerPeliculasYSeries(idLista);
            
            InfoCompletaPeliculasYSeriesDto infoCompletaPeliculasYSeriesDto = new InfoCompletaPeliculasYSeriesDto();
            infoCompletaPeliculasYSeriesDto.listaSeriesYPeliculas = listaSeriesYPeliculas;

            return PartialView(infoCompletaPeliculasYSeriesDto);
        }
        
        [HttpPost]
        public ActionResult CatalogoCompleto()
        {
            CatalogoService catalogoService = new CatalogoService();
            List<DatosPeliculasYSeriesDto> listaSeriesYPeliculasCompletas = catalogoService.ObtenerTodoCatalogo();

            InfoCompletaPeliculasYSeriesDto infoCompletaPeliculasYSeriesDto = new InfoCompletaPeliculasYSeriesDto();
            infoCompletaPeliculasYSeriesDto.listaSeriesYPeliculas = listaSeriesYPeliculasCompletas;

            return PartialView(infoCompletaPeliculasYSeriesDto);

        }

        [HttpPost]
        public ActionResult AddNuevaPeliculaSerieALista(string idLista, string tipo, int idPeliculaSerie)
        {

            CatalogoService catalogoService = new CatalogoService();
            bool insertadoCorrectamente = catalogoService.AddNuevaPeliculaSerieALista(idLista, tipo, idPeliculaSerie);

            return Json(insertadoCorrectamente);
        }
    }
}
