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
    [RoutePrefix("api/MetodoPago")]
    public class MetodoPagoController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<MetodoPago> ConsultarTodos()
        {
            clsMetodoPago mp = new clsMetodoPago();
            return mp.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public MetodoPago ConsultarXId(int Id)
        {
            clsMetodoPago mp = new clsMetodoPago();
            return mp.Consultar(Id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] MetodoPago metodoPago)
        {
            clsMetodoPago mp = new clsMetodoPago();
            mp.metPago = metodoPago;
            return mp.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] MetodoPago metodoPago)
        {
            clsMetodoPago mp = new clsMetodoPago();
            mp.metPago = metodoPago;
            return mp.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXId")]
        public string EliminarXId(int Id)
        {
            clsMetodoPago mp = new clsMetodoPago();
            return mp.EliminarXId(Id);
        }

    }
}