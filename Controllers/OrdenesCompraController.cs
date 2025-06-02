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
    [RoutePrefix("api/OrdenesCompra")]
    public class OrdenesCompraController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<OrdenesCompra> ConsultarTodos()
        {
            clsOrdenesCompra oc = new clsOrdenesCompra();
            return oc.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public OrdenesCompra ConsultarXId(int Id)
        {
            clsOrdenesCompra oc = new clsOrdenesCompra();
            return oc.Consultar(Id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] OrdenesCompra ordenCompra)
        {
            clsOrdenesCompra oc = new clsOrdenesCompra();
            oc.ordenCompra = ordenCompra;
            return oc.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] OrdenesCompra ordenCompra)
        {
            clsOrdenesCompra oc = new clsOrdenesCompra();
            oc.ordenCompra = ordenCompra;
            return oc.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXId")]
        public string EliminarXId(int Id)
        {
            clsOrdenesCompra oc = new clsOrdenesCompra();
            return oc.EliminarXId(Id);
        }
    }
}