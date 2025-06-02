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
    [RoutePrefix("api/Propietarios")]
    public class PropietariosController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Propietario> ConsultarTodos()
        {
            clsPropietario prop = new clsPropietario();
            return prop.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXDocumento")]
        public Propietario ConsultarXDocumento(int Cedula)
        {
            clsPropietario prop = new clsPropietario();
            return prop.Consultar(Cedula);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Propietario propietario)
        {
            clsPropietario prop = new clsPropietario();
            clsUsuario user = new clsUsuario();
            prop.propietario = propietario;
            user.usuarioo = new User
            {
                Usuario = propietario.Correo,
                Clave = propietario.Cedula.ToString(),
                Rol = "Propietario"
            };
            user.Insertar();
            return prop.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Propietario propietario)
        {
            clsPropietario prop = new clsPropietario();
            prop.propietario = propietario;
            return prop.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXDocumento")]
        public string EliminarXDocumento(int Cedula)
        {
            clsPropietario prop = new clsPropietario();
            return prop.EliminarXDocumento(Cedula);
        }
    }
}