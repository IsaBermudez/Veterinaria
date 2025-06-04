using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VeterinariaServ.Clases;
using VeterinariaServ.Models;

namespace VeterinariaServ.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Prescripcion")]
    public class PrescripcionController : ApiController
    {

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Prescripcion> ConsultarTodos()
        {
            clsPrescripcion pre  = new clsPrescripcion();
            return pre.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Prescripcion ConsultarXId(int Id)
        {
            clsPrescripcion pre = new clsPrescripcion();
            return pre.Consultar(Id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Prescripcion prescripcion)
        {
            clsPrescripcion pre = new clsPrescripcion();
            pre.Prescripcion = prescripcion;
            return pre.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Prescripcion prescripcion)
        {
            clsPrescripcion pre = new clsPrescripcion();
            pre.Prescripcion = prescripcion;
            return pre.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXId")]
        public string EliminarXId(int Id)
        {
            clsPrescripcion pre = new clsPrescripcion();
            return pre.EliminarXId(Id);
        }
        [HttpGet]
        [Route("PrescripcionConMascota")]
        public IQueryable PrescripcionConMascota()
        {
            //Se crea el objeto de la clase ClsCliente, y se invoca el método Consultar
            clsPrescripcion prescripcion = new clsPrescripcion();
            return prescripcion.PrescripcionConMascota();
        }
    }
}