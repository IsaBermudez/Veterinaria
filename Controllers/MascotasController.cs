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
        [HttpGet]
        [Route("LlenarCombo")]
        public IQueryable LlenarCombo()
        {
            clsMascota mascota = new clsMascota();
            return mascota.LlenarCombo();
        }
<<<<<<< Updated upstream
=======
        [HttpGet]
        [Route("ConsultarXID")]
        public Mascota ConsultarXId(int ID)
        {
            clsMascota pre = new clsMascota();
            return pre.Consultar(ID);
        }

        [HttpGet]
        [Route("ConsultarPorPropietario")]
        public List<MascotaDTO> ConsultarPorPropietario(int CedulaPropietario)
        {
            clsMascota mascota = new clsMascota();

            return mascota.ConsultarPorPropietario(CedulaPropietario);
        }
        [HttpGet]
        [Route("LlenarComboPorPropietario")]
        public IQueryable LlenarComboPorPropietario(int cedulaPropietario)
        {
            clsMascota mascota = new clsMascota();
            return mascota.LlenarComboPorPropietario(cedulaPropietario);
        }

>>>>>>> Stashed changes
    }
}
