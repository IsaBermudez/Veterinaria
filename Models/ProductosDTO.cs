using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeterinariaServ.Models
{
    public class ProductosDTO
    {
        public int ID { get; set; }
        public string Mascota { get; set; }
        public decimal Costo { get; set; }
        public string NombreDueño { get; set; }
    }
}