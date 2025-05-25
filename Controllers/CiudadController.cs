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
    [RoutePrefix("api/Ciudad")]
    public class CiudadController : ApiController
    {
            [HttpGet]
            [Route("ConsultarTodos")]
            public List<Ciudad> ConsultarTodos()
            {
                clsCiudad ciu = new clsCiudad();
                return ciu.ConsultarTodos();
            }

            [HttpGet]
            [Route("ConsultarXId")]
            public Ciudad ConsultarXId(int Id)
            {
                clsCiudad ciu = new clsCiudad();
                return ciu.Consultar(Id);
            }

            [HttpPost]
            [Route("Insertar")]
            public string Insertar([FromBody] Ciudad ciudad)
            {
                clsCiudad ciu = new clsCiudad();
                ciu.ciudad = ciudad;
                return ciu.Insertar();
            }

            [HttpPut]
            [Route("Actualizar")]
            public string Actualizar([FromBody] Ciudad ciudad)
            {
                clsCiudad ciu = new clsCiudad();
                ciu.ciudad = ciudad;
                return ciu.Actualizar();
            }

            [HttpDelete]
            [Route("EliminarXId")]
            public string EliminarXId(int Id)
            {
                clsCiudad ciu = new clsCiudad();
                return ciu.EliminarXId(Id);
            }

    }
}