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
            List<PeliculasYSeriesInfoDto> listaPeliculas =  bbdd.ObtenerListaPeliculasSeries(Usuario);
            dto.ListaPeliculasSeries = listaPeliculas;

            return dto;
        }

        public bool CrearNuevaLista(string nuevaLista)
        {
            Conexion_bbdd bbdd = new Conexion_bbdd();
            bool inserccionCorrecta = bbdd.CrearNuevaLista(nuevaLista, Usuario);
            return inserccionCorrecta;
        }
    }
}
