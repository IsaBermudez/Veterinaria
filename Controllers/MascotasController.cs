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
    
    [RoutePrefix("api/Mascotas")]
    public class MascotasController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
       

        public List<Mascota> ConsultarTodos()
        {
            clsMascota mascota = new clsMascota();

            return mascota.ConsultarTodos();
        }


        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Mascota Mascota)
        {
            clsMascota mascota = new clsMascota();
            mascota.Mascota = Mascota;
            return mascota.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Mascota Mascota)
        {
            clsMascota mascota = new clsMascota();
            mascota.Mascota = Mascota;
            return mascota.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int IdMascota)
        {
            clsMascota mascota = new clsMascota();
            return mascota.Eliminar(IdMascota);
        }
    }
}
