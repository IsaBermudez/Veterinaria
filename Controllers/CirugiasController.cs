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
    [RoutePrefix("api/Cirugias")]
   
    public class CirugiasController : ApiController
    {
        
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Cirugia> ConsultarTodos()
        {
            clsCirugia ciru = new clsCirugia();
            return ciru.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXID")]
        public Cirugia ConsultarXID(int ID)
        {
            clsCirugia ciru = new clsCirugia();
            return ciru.Consultar(ID);
        }

        [HttpGet]
        [Route("ConsultarXFecha")]
        public List<Cirugia> ConsultarXFecha(DateTime Fecha)
        {

            clsCirugia ciru = new clsCirugia();
            return ciru.ConsultarPorFecha(Fecha);
        }

        [HttpGet]
        [Route("ConsultarXIDMascota")]
        public List<Cirugia> ConsultarXIDMascota(int ID)
        {
            clsCirugia ciru = new clsCirugia();
            return ciru.ConsultarPorMascota(ID);
        }

        [HttpGet]
        [Route("ConsultarTodosPorCosto")]
        public List<Cirugia> ConsultarTodosPorCosto(double Costo)
        {
            clsCirugia ciru = new clsCirugia();
            return ciru.ConsultarTodosPorCosto(Costo);
        }


        [HttpGet]
        [Route("ConsultarPorNombreEmpleado")]
        public List<Cirugia> ConsultarPorNombreEmpleado(string nombreEmpleado)
        {
            clsCirugia ciru = new clsCirugia();
            return ciru.ConsultarPorNombreEmpleado(nombreEmpleado);
        }


        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Cirugia cirugia)
        {
            clsCirugia ciru = new clsCirugia();
            ciru.cirugia = cirugia;
            return ciru.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Cirugia cirugia)
        {
            clsCirugia ciru = new clsCirugia();
            ciru.cirugia = cirugia;
            return ciru.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXID")]
        public string EliminarXID(int ID)
        {
            clsCirugia ciru = new clsCirugia();
            return ciru.EliminarXID(ID);
        }
    }
}