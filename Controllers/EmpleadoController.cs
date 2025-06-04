using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using System.Web.Http.Cors;
using VeterinariaServ.Clases;
using VeterinariaServ.Models;

namespace VeterinariaServ.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Empleado")]
    public class EmpleadoController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Empleado> ConsultarTodos()
        {
            clsEmpleado pf = new clsEmpleado();
            return pf.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Empleado ConsultarXId(int Id)
        {
            clsEmpleado pf = new clsEmpleado();
            return pf.Consultar(Id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Empleado em)
        {
            clsEmpleado pf = new clsEmpleado();
            pf.empleado = em;
            return pf.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Empleado em)
        {
            clsEmpleado pf = new clsEmpleado();
            pf.empleado = em;
            return pf.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXId")]
        public string EliminarXId(int Id)
        {
            clsEmpleado pf = new clsEmpleado();
            return pf.EliminarXId(Id);
        }
        [HttpGet]
        [Route("LlenarCombo")]
        public IQueryable LlenarCombo()
        {
            clsEmpleado pf = new clsEmpleado();
            return pf.LlenarCombo();
        }
    }
}