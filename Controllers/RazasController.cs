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
    [RoutePrefix("api/Razas")]
    public class RazasController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Raza> ConsultarTodos()
        {
            clsRaza raz = new clsRaza();
            return raz.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXNit")]
        public Raza ConsultarXNit(int id)
        {
            clsRaza raz = new clsRaza();
            return raz.Consultar(id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Raza raza)
        {
            clsRaza raz = new clsRaza();
            raz.raza = raza;
            return raz.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Raza raza)
        {
            clsRaza raz = new clsRaza();
            raz.raza = raza;
            return raz.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXNit")]
        public string EliminarXNit(int id)
        {
            clsRaza raz = new clsRaza();
            return raz.EliminarXDocumento(id);
        }
    }
}