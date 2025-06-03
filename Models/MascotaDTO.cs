using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeterinariaServ.Models
{
    public class MascotaDTO
    {
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string NombreEspecie { get; set; }
        public string NombreRaza { get; set; }
        public string Sexo { get; set; }
    }
}