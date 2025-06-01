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

    [RoutePrefix("api/Hospitalizaciones")]
    public class HospitalizacionesController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Hospitalizacion> ConsultarTodos()
        {
            clsHospitalizacion hospita = new clsHospitalizacion();
            return hospita.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXID")]
        public Hospitalizacion ConsultarXID(int ID)
        {
            clsHospitalizacion hospita = new clsHospitalizacion();
            return hospita.Consultar(ID);
        }

        [HttpGet]
        [Route("ConsultarXFechaEntrada")]
        public List<Hospitalizacion> ConsultarXFecha(DateTime Fecha)
        {
            clsHospitalizacion hospita = new clsHospitalizacion();
            return hospita.ConsultarPorFechaEntrada(Fecha);
        }

        [HttpGet]
        [Route("ConsultarXIDMascota")]
        public List<Hospitalizacion> ConsultarXIDMascota(int idMascota)
        {
            clsHospitalizacion hospita = new clsHospitalizacion();
            return hospita.ConsultarPorMascota(idMascota);
        }

        [HttpGet]
        [Route("ConsultarTodosPorCosto")]
        public List<Hospitalizacion> ConsultarTodosPorCosto()
        {
            clsHospitalizacion hospita = new clsHospitalizacion();
            return hospita.ConsultarTodosPorCosto();
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Hospitalizacion hospitalizacion)
        {
            clsHospitalizacion hospi = new clsHospitalizacion();
            hospi.hospitalizacion = hospitalizacion;
            return hospi.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Hospitalizacion hospitalizacion)
        {
            clsHospitalizacion hospi = new clsHospitalizacion();
            hospi.hospitalizacion = hospitalizacion;
            return hospi.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXID")]
        public string EliminarXID(int ID)
        {
            clsHospitalizacion hospi = new clsHospitalizacion();
            return hospi.EliminarXID(ID);
        }
    }
}

