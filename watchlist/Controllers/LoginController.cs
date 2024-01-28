using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using watchlist.Models;
using watchlist.Servicios;

namespace watchlist.Controllers
{
    public class LoginController : Controller
    {
        
        [HttpPost]        
        public ActionResult UsuarioValido(Login datosLogin)
        {
            try
            {

                LoginService loginService = new LoginService(datosLogin);
                bool esUsuarioValido = loginService.EsLoginValido();

                return Json(esUsuarioValido);
            }
            catch
            {
                return Json(false);
            }
        }
    }
}
