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
    [RoutePrefix("api/Sedes")]
    public class SedesController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Sede> ConsultarTodos()
        {
            clsSede sed = new clsSede();
            return sed.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXNit")]
        public Sede ConsultarXNit(int id)
        {
            clsSede sed = new clsSede();
            return sed.Consultar(id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Sede sede)
        {
            clsSede sed = new clsSede();
            sed.sede = sede;
            return sed.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Sede sede)
        {
            clsSede sed = new clsSede();
            sed.sede = sede;
            return sed.Actualizar();
        }

        [HttpGet]
        [Route("LlenarCombo")]
        public IQueryable LlenarCombo()
        {
            clsSede sed = new clsSede();
            return sed.LlenarCombo();
        }

        [HttpDelete]
        [Route("EliminarXNit")]
        public string EliminarXNit(int id)
        {
            clsSede sed = new clsSede();
            return sed.EliminarXDocumento(id);
        }
    }
}