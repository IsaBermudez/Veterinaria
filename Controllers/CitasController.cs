using global::VeterinariaServ.Clases;
using global::VeterinariaServ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;



namespace VeterinariaServ.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Citas")]
    public class CitasController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public IQueryable ConsultarTodos()
        {
            clsCita cit = new clsCita();
            return cit.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXID")]
        public Cita ConsultarXID(int ID)
        {
            clsCita cit = new clsCita();
            return cit.Consultar(ID);
        }

        [HttpGet]
        [Route("ConsultarXFecha")]
        public List<Cita> ConsultarXFecha(DateTime Fecha)
        {

            clsCita cit = new clsCita();
            return cit.ConsultarPorFecha(Fecha);
        }

        [HttpGet]
        [Route("ConsultarXIDMascota")]
        public List<Cita> ConsultarXIDMascota(int ID)
        {
            clsCita ciru = new clsCita();
            return ciru.ConsultarPorMascota(ID);
        }


        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Cita cita)
        {
            clsCita cit = new clsCita();
            cit.cita = cita;
            return cit.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Cita cita)
        {
            clsCita cit = new clsCita();
            cit.cita = cita;
            return cit.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXID")]
        public string EliminarXID(int ID)
        {
            clsCita cit = new clsCita();
            return cit.EliminarXID(ID);
        }

        // GET: api/citas/disponibles?desde=2025-06-02&hasta=2025-06-05&tipoDeCita=1
        [HttpGet]
        [Route("ConsultarRangoDisponible")]
        public IHttpActionResult ConsultarFechasDisponibles(DateTime desde, DateTime hasta, String tipoDeCita)
        {
            try
            {
                clsCita cit = new clsCita();
                List<DateTime> fechas = cit.ConsultarFechasDisponibles(desde, hasta, tipoDeCita);
                return Ok(fechas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("ObtenerCita")]
        public IQueryable CitaRegistro()
        {
            clsCita cit = new clsCita();
            return cit.ObtenerCitaDetallada();
        }
    }

}