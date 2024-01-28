using MySql.Data.MySqlClient;
using System.Diagnostics.Eventing.Reader;
using watchlist.Models;
using watchlist.Models.PeliculasYSeriesDto;


namespace watchlist.Conexion_BBDD
{
    public class Conexion_bbdd
    {
        MySqlConnection sqlConexion;
        private const int COLUMNA_USUARIO = 1;
        private const int COLUMNA_ID_USUARIO = 0;
        private const int COLUMNA_PASSWORD = 2;
        private const int COLUMNA_ID_LISTA = 0;
        private const int COLUMNA_NOMBRELISTA = 2;


        private const int COLUMNA_ID_PELICULAS_SERIES = 0;
        private const int COLUMNA_NOMBRE_PELICULAS_SERIES = 1;
        private const int COLUMNA_DESCRIPCION_PELICULAS_SERIES = 2;
        private const int COLUMNA_GENERO_PELICULAS_SERIES = 3;
        private const int COLUMNA_FECHA_PELICULAS_SERIES = 4;
        private const int COLUMNA_CARATULA_PELICULAS_SERIES = 5;

        private const int COLUMNA_ID_PELICULAS_PELICULA_SERIES = 2;
        private const int COLUMNA_ID_SERIES_PELICULA_SERIES = 3;


        public Conexion_bbdd()
        {
            sqlConexion = new MySqlConnection("Server=127.0.0.1; PORT= 3307; Database=watchlist; user=root; password=");
        }

        public List<PeliculasYSeriesInfoDto> ObtenerListaPeliculasSeries(string login)
        {
            int idUsuario = ObtenerIdUsuarioPorLogin(login);
            List<PeliculasYSeriesInfoDto> listaPeliculasYSeries = new List<PeliculasYSeriesInfoDto>();

            MySqlCommand cmd = sqlConexion.CreateCommand();

            cmd.CommandText = $"SELECT * FROM LISTA_PELICULAS_SERIES where id_usuario = {idUsuario}";
            sqlConexion.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int? id = reader.GetInt32(COLUMNA_ID_LISTA);
                string nombreLista = reader.GetString(COLUMNA_NOMBRELISTA);
                listaPeliculasYSeries.Add(new PeliculasYSeriesInfoDto()
                {
                    Id = id,
                    NombreLista = nombreLista
                });
            }

            reader.Close();
            sqlConexion.Close();

            return listaPeliculasYSeries;
        }

        private int ObtenerIdUsuarioPorLogin(string login)
        {
            MySqlCommand cmd = sqlConexion.CreateCommand();

            cmd.CommandText = $"SELECT id FROM USUARIOS where usuario = '{login}'";

            sqlConexion.Open();

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int idUsuario = reader.GetInt32(COLUMNA_ID_USUARIO);
                if(idUsuario != 0)
                {
                    sqlConexion.Close();
                    return idUsuario;
                }
            }
            reader.Close();
            sqlConexion.Close();
            return 0;
        }

        public bool UsuarioValido(string usuario, string password)
        {
            MySqlCommand cmd = sqlConexion.CreateCommand();
            cmd.CommandText = "SELECT * FROM usuarios";

            sqlConexion.Open();

            MySqlDataReader reader = cmd.ExecuteReader();
            bool esUsuarioValido = false;

            while (reader.Read())
            {
                string usuarioBBDD = reader.GetString(COLUMNA_USUARIO);
                string passwordBBDD = reader.GetString(COLUMNA_PASSWORD);

                if (usuario.Equals(usuarioBBDD, StringComparison.OrdinalIgnoreCase) && password.Equals(passwordBBDD, StringComparison.OrdinalIgnoreCase))
                {
                    sqlConexion.Close();
                    return esUsuarioValido = true;
                }
                    
            }
            reader.Close();
            sqlConexion.Close();

            return esUsuarioValido;
        }        

        public List<DatosPeliculasYSeriesDto> ObtenerListaPeliculasYSeries(string idLista)
        {
            List<DatosPeliculasYSeriesDto> datosPeliculasYSeriesDtos = new List<DatosPeliculasYSeriesDto>();
            List<int> idPeliculas = new List<int>();
            List<int> idSeries = new List<int>();

            MySqlCommand cmd = sqlConexion.CreateCommand();
            cmd.CommandText = $"select * from peliculas_series where id_lista_peliculas_series = {idLista}";

            sqlConexion.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (!reader.IsDBNull(COLUMNA_ID_PELICULAS_PELICULA_SERIES))
                {
                    int idPeliculasBBDD = reader.GetInt32(COLUMNA_ID_PELICULAS_PELICULA_SERIES);
                    idPeliculas.Add(idPeliculasBBDD);
                }

                if (!reader.IsDBNull(COLUMNA_ID_SERIES_PELICULA_SERIES))
                {
                    int idSeriesBBDD = reader.GetInt32(COLUMNA_ID_SERIES_PELICULA_SERIES);
                    idSeries.Add(idSeriesBBDD);
                }
            }

            reader.Close();
            sqlConexion.Close();

            datosPeliculasYSeriesDtos.AddRange(ObtenerPeliculasPorListaId(idPeliculas));
            datosPeliculasYSeriesDtos.AddRange(ObtenerSeriesPorListaId(idSeries));

            return datosPeliculasYSeriesDtos;
        }


        private List<DatosPeliculasYSeriesDto> ObtenerPeliculasPorListaId(List<int> listaIdPeliculas)
        {
            List<DatosPeliculasYSeriesDto>  listaPeliculas = ObtenerPeliculas(listaIdPeliculas);

            return listaPeliculas;
        }

        private List<DatosPeliculasYSeriesDto> ObtenerSeriesPorListaId(List<int> listaIdSeries)
        {
            List<DatosPeliculasYSeriesDto> listaSeries = ObtenerSeries(listaIdSeries);

            return listaSeries;
        }

        public List<DatosPeliculasYSeriesDto> ObtenerPeliculas(List<int> listaIdPeliculas)
        {
            List<DatosPeliculasYSeriesDto> listaPeliculas = new List<DatosPeliculasYSeriesDto>();
            if (listaIdPeliculas == null || listaIdPeliculas.Count == 0)
                return listaPeliculas;

            MySqlCommand cmd = sqlConexion.CreateCommand();
            cmd.CommandText = $"SELECT * FROM peliculas where id in ({string.Join(',', listaIdPeliculas)} ) ";

            sqlConexion.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DatosPeliculasYSeriesDto datosPeliculasYSeriesDto = new DatosPeliculasYSeriesDto();

                int idPelicula = reader.GetInt32(COLUMNA_ID_PELICULAS_SERIES);                
                string nombrePelicula = reader.GetString(COLUMNA_NOMBRE_PELICULAS_SERIES);                
                string descripcionPelicula = reader.GetString(COLUMNA_DESCRIPCION_PELICULAS_SERIES);                
                string generoPelicula = reader.GetString(COLUMNA_GENERO_PELICULAS_SERIES);                
                int fechaPelicula = reader.GetInt32(COLUMNA_FECHA_PELICULAS_SERIES);                
                string caratulaPelicula = reader.GetString(COLUMNA_CARATULA_PELICULAS_SERIES);

                datosPeliculasYSeriesDto.Id = idPelicula;
                datosPeliculasYSeriesDto.Nombre = nombrePelicula;
                datosPeliculasYSeriesDto.Descripcion = descripcionPelicula;
                datosPeliculasYSeriesDto.Genero = generoPelicula;
                datosPeliculasYSeriesDto.Fecha = fechaPelicula;
                datosPeliculasYSeriesDto.Caratula = caratulaPelicula;

                listaPeliculas.Add(datosPeliculasYSeriesDto);
            }

            reader.Close();
            sqlConexion.Close();

            return listaPeliculas;
        }
        public List<DatosPeliculasYSeriesDto> ObtenerSeries(List<int> listaIdSeries)
        {
            List<DatosPeliculasYSeriesDto> listaSeries = new List<DatosPeliculasYSeriesDto>();

            if (listaIdSeries == null || listaIdSeries.Count == 0)
                return listaSeries;

            MySqlCommand cmd = sqlConexion.CreateCommand();
            cmd.CommandText = $"SELECT * FROM series where id in ({string.Join(',', listaIdSeries)} ) ";

            sqlConexion.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DatosPeliculasYSeriesDto datosPeliculasYSeriesDto = new DatosPeliculasYSeriesDto();

                int idSerie = reader.GetInt32(COLUMNA_ID_PELICULAS_SERIES);
                string nombreSerie = reader.GetString(COLUMNA_NOMBRE_PELICULAS_SERIES);
                string descripcionSerie = reader.GetString(COLUMNA_DESCRIPCION_PELICULAS_SERIES);
                string generoSerie = reader.GetString(COLUMNA_GENERO_PELICULAS_SERIES);                
                int fechaSerie = reader.GetInt32(COLUMNA_FECHA_PELICULAS_SERIES);
                string caratulaSerie = reader.GetString(COLUMNA_CARATULA_PELICULAS_SERIES);

                datosPeliculasYSeriesDto.Id = idSerie;
                datosPeliculasYSeriesDto.Nombre = nombreSerie;
                datosPeliculasYSeriesDto.Descripcion = descripcionSerie;
                datosPeliculasYSeriesDto.Genero = generoSerie;
                datosPeliculasYSeriesDto.Fecha = fechaSerie;
                datosPeliculasYSeriesDto.Caratula = caratulaSerie;

                listaSeries.Add(datosPeliculasYSeriesDto);
            }

            reader.Close();
            sqlConexion.Close();

            return listaSeries;
        }

        public bool CrearNuevaLista(string nombreLista, string Usuario)
        {
            int idUsuario = ObtenerIdUsuarioPorLogin(Usuario);

            MySqlCommand cmd = sqlConexion.CreateCommand();
            cmd.CommandText = $"INSERT INTO `lista_peliculas_series`(`id_usuario`, `nombre_lista`) VALUES ('{idUsuario}','{nombreLista}')";

            sqlConexion.Open();

            int numeroInsercciones = cmd.ExecuteNonQuery();

            cmd.Connection.Close();
            sqlConexion.Close();

            return numeroInsercciones > 0;

        }
    }
}

   


