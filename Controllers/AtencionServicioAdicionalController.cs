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
    [RoutePrefix("api/AtencionServiciosAdicionales")]
    public class AtencionServicioAdicionalController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<AtencionServicioAdicional> ConsultarTodos()
        {
            clsAtencionServicioAdicional asa = new clsAtencionServicioAdicional();
            return asa.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public AtencionServicioAdicional ConsultarXId(int Id)
        {

            clsAtencionServicioAdicional asa = new clsAtencionServicioAdicional();
            return asa.Consultar(Id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] AtencionServicioAdicional atencionServicio)
        {
            clsAtencionServicioAdicional asa = new clsAtencionServicioAdicional();
            asa.AtencionAS = atencionServicio;
            return asa.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] AtencionServicioAdicional atencionServicio)
        {
            clsAtencionServicioAdicional asa = new clsAtencionServicioAdicional();
            asa.AtencionAS = atencionServicio;
            return asa.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXId")]
        public string EliminarXId(int Id)
        {
            clsAtencionServicioAdicional asa = new clsAtencionServicioAdicional();
            return asa.EliminarXId(Id);
        }
    }
}