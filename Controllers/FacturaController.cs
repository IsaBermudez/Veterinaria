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
    [RoutePrefix("api/Factura")]
    public class FacturaController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Factura> ConsultarTodos()
        {
            clsFactura oc = new clsFactura();
            return oc.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Factura ConsultarXId(int Id)
        {
            clsFactura oc = new clsFactura();
            return oc.Consultar(Id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Factura factura)
        {
            clsFactura oc = new clsFactura();
            oc.factura = factura;
            return oc.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Factura factura)
        {
            clsFactura oc = new clsFactura();
            oc.factura = factura;
            return oc.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXId")]
        public string EliminarXId(int Id)
        {
            clsFactura oc = new clsFactura();
            return oc.EliminarXId(Id);
        }
    }
}