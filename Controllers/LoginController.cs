using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VeterinariaServ.Clases;
using VeterinariaServ.Models;

namespace VeterinariaServ.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("Ingresar")]
        public IQueryable<LoginRespuesta> Ingresar([FromBody] Login login)
        {
            clsLogin _login = new clsLogin();
            _login.login = login;
            return _login.Ingresar();
        }
    }
}