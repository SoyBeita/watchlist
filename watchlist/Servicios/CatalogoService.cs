using watchlist.Conexion_BBDD;
using watchlist.Models.PeliculasYSeriesDto;

namespace watchlist.Servicios
{
    public class CatalogoService
    {
        private string? Usuario;

        private readonly string? NombrePelicula;
        public CatalogoService( string usuario)
        {
            Usuario = usuario;
        }

        public List<DatosPeliculasYSeriesDto> ObtenerPeliculasYSeries(string idLista)
        {
            Conexion_bbdd bbdd = new Conexion_bbdd();
            return bbdd.ObtenerListaPeliculasYSeries(idLista);
        }      

    }
}
