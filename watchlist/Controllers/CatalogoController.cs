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
    }
}
