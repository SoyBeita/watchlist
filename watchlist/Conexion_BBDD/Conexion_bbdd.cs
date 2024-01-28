using MySql.Data.MySqlClient;
using System.Diagnostics.Eventing.Reader;


namespace watchlist.Conexion_BBDD
{
    public class Conexion_bbdd
    {
        MySqlConnection sqlConexion;
        private const int COLUMNA_USUARIO = 1;
        private const int COLUMNA_ID_USUARIO = 0;
        private const int COLUMNA_PASSWORD = 2;
        private const int COLUMNA_NOMBRELISTA = 2;



        public Conexion_bbdd()
        {
            sqlConexion = new MySqlConnection("Server=127.0.0.1; PORT= 3307; Database=watchlist; user=root; password=");
        }

        public List<string> ObtenerListaPeliculasSeries(string login)
        {
            int idUsuario = ObtenerIdUsuarioPorLogin(login);
            List<string> listaPeliculasYSeries = new List<string>();

            MySqlCommand cmd = sqlConexion.CreateCommand();

            cmd.CommandText = $"SELECT * FROM LISTA_PELICULAS_SERIES where id_usuario = {idUsuario}";
            sqlConexion.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string nombreLista = reader.GetString(COLUMNA_NOMBRELISTA);
                listaPeliculasYSeries.Add(nombreLista);
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
    }
}
