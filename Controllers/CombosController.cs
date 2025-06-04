using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;
using VeterinariaServ.Clases;

namespace VeterinariaServ.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Combos")]
    public class CombosController : Controller
    {
        [HttpGet]
        [Route("LlenarComboCirugia")]
        public IQueryable LlenarComboCirugia()
        {
            clsCombos mascota = new clsCombos();
            return mascota.LlenarComboCirugia();
        }

        [HttpGet]
        [Route("LlenarComboCita")]
        public IQueryable LlenarComboCita()
        {
            clsCombos mascota = new clsCombos();
            return mascota.LlenarComboCita();
        }

        [HttpGet]
        [Route("LlenarComboHospitalizacion")]
        public IQueryable LlenarComboHospitalizacion()
        {
            clsCombos mascota = new clsCombos();
            return mascota.LlenarComboHospitalizacion();
        }

    }
}
