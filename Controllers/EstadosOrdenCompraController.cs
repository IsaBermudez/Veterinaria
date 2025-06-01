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
    [RoutePrefix("api/EstadoOrdenCompra")]
    public class EstadosOrdenCompraController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<EstadosOrdenCompra> ConsultarTodos()
        {
            clsEstadosOrdenCompra asa = new clsEstadosOrdenCompra();
            return asa.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public EstadosOrdenCompra ConsultarXId(int Id)
        {

            clsEstadosOrdenCompra asa = new clsEstadosOrdenCompra();
            return asa.Consultar(Id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] EstadosOrdenCompra estadosOrden)
        {
            clsEstadosOrdenCompra asa = new clsEstadosOrdenCompra();
            asa.EstadoCompra = estadosOrden;
            return asa.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] EstadosOrdenCompra estadosOrden)
        {
            clsEstadosOrdenCompra asa = new clsEstadosOrdenCompra();
            asa.EstadoCompra = estadosOrden;
            return asa.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXId")]
        public string EliminarXId(int Id)
        {
            clsEstadosOrdenCompra asa = new clsEstadosOrdenCompra();
            return asa.EliminarXId(Id);
        }
    }
}