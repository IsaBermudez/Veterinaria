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
    [RoutePrefix("api/Camas")]
    public class CamasController : ApiController
    {

        [HttpGet]
        [Route("ConsultarXID")]
        public Cama ConsultarXID(int ID)
        {
            clsCama cam = new clsCama();
            return cam.Consultar(ID);
        }

        [HttpGet]
        [Route("ConsultarXEstado")]
        public List<Cama> ConsultarXEstado(String estado)
        {
            clsCama ca = new clsCama();
            return ca.ConsultarPorEstado(estado);
        }


        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Cama cama)
        {
            clsCama cam = new clsCama();
            cam.cama = cama;
            return cam.Insertar();
        }

        [HttpPut]
        [Route("ActualizarEstado")]
        public String ActualizarEstado(int id, String nuevoEstado)
        {
            clsCama cam = new clsCama();
            return cam.ActualizarEstado(id, nuevoEstado);

        }

        [HttpDelete]
        [Route("EliminarXID")]
        public string EliminarXID(int ID)
        {
            clsCama hospi = new clsCama();
            return hospi.Eliminar(ID);
        }
    }
}