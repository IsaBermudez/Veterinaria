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
    [RoutePrefix("api/ServiciosAdicionales")]
    public class ServiciosAdicionalesController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<ServiciosAdicionale> ConsultarTodos()
        {
           clsServiciosAdicionales sa = new clsServiciosAdicionales();
            return sa.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public ServiciosAdicionale ConsultarXId(int Id)
        {
            clsServiciosAdicionales sa = new clsServiciosAdicionales();
            return sa.Consultar(Id);
        }
            
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] ServiciosAdicionale servicios)
        {
            clsServiciosAdicionales sa = new clsServiciosAdicionales();
            sa.servicios = servicios;
            return sa.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] ServiciosAdicionale servicios)
        {
            clsServiciosAdicionales sa = new clsServiciosAdicionales();
            sa.servicios = servicios;
            return sa.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXId")]
        public string EliminarXId(int Id)
        {
            clsServiciosAdicionales sa = new clsServiciosAdicionales();
            return sa.EliminarXId(Id);
        }
    }
}