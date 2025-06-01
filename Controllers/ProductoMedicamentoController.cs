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
    [RoutePrefix("api/ProductoFarmacia")]
    public class ProductoMedicamentoController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Productos_Farmacia> ConsultarTodos()
        {
            clsProductoFarmacia pf = new clsProductoFarmacia();
            return pf.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Productos_Farmacia ConsultarXId(int Id)
        {
            clsProductoFarmacia pf = new clsProductoFarmacia();
            return pf.Consultar(Id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Productos_Farmacia Producto)
        {
            clsProductoFarmacia pf = new clsProductoFarmacia();
            pf.ProductosFarmacia = Producto;
            return pf.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Productos_Farmacia Producto)
        {
            clsProductoFarmacia pf = new clsProductoFarmacia();
            pf.ProductosFarmacia = Producto;
            return pf.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXId")]
        public string EliminarXId(int Id)
        {
            clsProductoFarmacia pf = new clsProductoFarmacia();
            return pf.EliminarXId(Id);
        }
    }
}