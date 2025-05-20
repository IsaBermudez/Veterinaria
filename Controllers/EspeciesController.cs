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
    [RoutePrefix("api/Especies")]
    public class EspeciesController : ApiController
    {


        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Especie> ConsultarTodos()
        {
            clsEspecie espe = new clsEspecie();
            return espe.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXID")]
        public Especie ConsultarXDocumento(int ID)
        {
            clsEspecie espe = new clsEspecie();
            return espe.Consultar(ID);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Especie especie)
        {
            clsEspecie espe = new clsEspecie();
            espe.especie = especie;
            return espe.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Especie especie)
        {
            clsEspecie espe = new clsEspecie();
            espe.especie = especie;
            return espe.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXID")]
        public string EliminarXID(int ID)
        {
            clsEspecie espe = new clsEspecie();
            return espe.EliminarXID(ID);
        }
    }
}