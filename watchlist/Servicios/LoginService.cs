using watchlist.Conexion_BBDD;

namespace watchlist.Servicios
{
    public class LoginService
    {
        private readonly string Usuario;
        private readonly string Password;

        public LoginService(Models.Login login)         
        {
            Usuario = login.Usuario;
            Password = login.Password;
        }

        public bool EsLoginValido()
        {
            if (String.IsNullOrEmpty(Usuario) || string.IsNullOrEmpty(Password))
                return false;

            //Valido Usuario y contraseña con base de datos

            Conexion_bbdd bbdd = new Conexion_bbdd();
            return bbdd.UsuarioValido(Usuario, Password);

        }


    }
}
