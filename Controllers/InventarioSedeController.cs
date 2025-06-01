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
    [RoutePrefix("api/InventarioSede")]
    public class InventarioSedeController : ApiController
    {

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<InventarioSede> ConsultarTodos()
        {
            clsInventarioSede invs = new clsInventarioSede();
            return invs.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public InventarioSede ConsultarXId(int Id)
        {
            clsInventarioSede invs = new clsInventarioSede();
            return invs.Consultar(Id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] InventarioSede medicamento)
        {
            clsInventarioSede invs = new clsInventarioSede();
            invs.Inventario = medicamento;
            return invs.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] InventarioSede medicamento)
        {
            clsInventarioSede invs = new clsInventarioSede();
            invs.Inventario = medicamento;
            return invs.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXId")]
        public string EliminarXId(int Id)
        {
            clsInventarioSede invs = new clsInventarioSede();
            return invs.EliminarXId(Id);
        }
    }
}