using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VeterinariaServ.Clases;
using VeterinariaServ.Models;

namespace VeterinariaServ.Controllers
{
    
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Propietarios")]
    public class PropietariosController : ApiController
    {
        [Authorize(Roles = "Administrador")]
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

        [Authorize(Roles = "Administrador")]
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
                Rol = "Usuario"
            };
            user.Insertar();
            return prop.Insertar();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Propietario propietario)
        {
            clsPropietario prop = new clsPropietario();
            prop.propietario = propietario;
            return prop.Actualizar();
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete]
        [Route("EliminarXDocumento")]
        public string EliminarXDocumento(int Cedula)
        {
            clsPropietario prop = new clsPropietario();
            return prop.EliminarXDocumento(Cedula);
        }

        [HttpGet]
        [Route("LlenarCombo")]
        public IQueryable LlenarCombo()
        {
            clsPropietario mascota = new clsPropietario();
            return mascota.LlenarCombo();
        }

    }
}