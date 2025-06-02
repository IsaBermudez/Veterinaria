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
    [RoutePrefix("api/OrdenesCompraDetalle")]
    public class OrdenesCompraDetController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<OrdenesCompraDetalle> ConsultarTodos()
        {
            clsOrdenesCompraDet oc = new clsOrdenesCompraDet();
            return oc.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public OrdenesCompraDetalle ConsultarXId(int Id)
        {
            clsOrdenesCompraDet oc = new clsOrdenesCompraDet();
            return oc.Consultar(Id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] OrdenesCompraDetalle ordenCompra)
        {
            clsOrdenesCompraDet oc = new clsOrdenesCompraDet();
            oc.ordenDet = ordenCompra;
            return oc.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] OrdenesCompraDetalle ordenCompra)
        {
            clsOrdenesCompraDet oc = new clsOrdenesCompraDet();
            oc.ordenDet = ordenCompra;
            return oc.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXId")]
        public string EliminarXId(int Id)
        {
            clsOrdenesCompraDet oc = new clsOrdenesCompraDet();
            return oc.EliminarXId(Id);
        }
    }
}