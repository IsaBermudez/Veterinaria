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
    [RoutePrefix("api/FacturaDetalle")]
    public class FacturaDetController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Detalle_Factura> ConsultarTodos()
        {
            clsFacturaDet oc = new clsFacturaDet();
            return oc.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Detalle_Factura ConsultarXId(int Id)
        {
            clsFacturaDet oc = new clsFacturaDet();
            return oc.Consultar(Id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Detalle_Factura factura)
        {
            clsFacturaDet oc = new clsFacturaDet();
            oc.facturaDet = factura;
            return oc.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Detalle_Factura factura)
        {
            clsFacturaDet oc = new clsFacturaDet();
            oc.facturaDet = factura;
            return oc.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXId")]
        public string EliminarXId(int Id)
        {
            clsFacturaDet oc = new clsFacturaDet();
            return oc.EliminarXId(Id);
        }

        [HttpGet]
        [Route("ConsultarXFactura")]
        public IQueryable ConsultarXFactura(int Id)
        {
            clsFacturaDet oc = new clsFacturaDet();
            return oc.ConsultarXFactura(Id);
        }
    }
}