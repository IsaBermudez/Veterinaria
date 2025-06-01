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
    [RoutePrefix("api/InventarioFarmacia")]
    public class InventarioFarmaciaController : ApiController
    {

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<InventarioFarmacia> ConsultarTodos()
        {
            clsInventarioFarmacia inf = new clsInventarioFarmacia();
            return inf.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public InventarioFarmacia ConsultarXId(int Id)
        {
            clsInventarioFarmacia inf = new clsInventarioFarmacia();
            return inf.Consultar(Id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] InventarioFarmacia medicamento)
        {
            clsInventarioFarmacia inf = new clsInventarioFarmacia();
            inf.Inventario = medicamento;
            return inf.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] InventarioFarmacia medicamento)
        {
            clsInventarioFarmacia inf = new clsInventarioFarmacia();
            inf.Inventario = medicamento;
            return inf.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXId")]
        public string EliminarXId(int Id)
        {
            clsInventarioFarmacia inf = new clsInventarioFarmacia();
            return inf.EliminarXId(Id);
        }
    }
}