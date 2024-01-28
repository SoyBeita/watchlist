using watchlist.Conexion_BBDD;
using watchlist.Models.PeliculasYSeriesDto;

namespace watchlist.Servicios
{
    public class PeliculasYSeriesService
    {
        private string Usuario;
        public PeliculasYSeriesService(string usuario)
        {
            Usuario = usuario;
        }

        public PeliculasYSeriesDto ObtenerListaPeliculasSeries()
        {
            PeliculasYSeriesDto dto = new PeliculasYSeriesDto();
            dto.Usuario = Usuario;

            Conexion_bbdd bbdd = new Conexion_bbdd();
            List<string> listaPeliculas =  bbdd.ObtenerListaPeliculasSeries(Usuario);
            dto.ListaPeliculasSeries = listaPeliculas;

            return dto;
        }
    }
}
