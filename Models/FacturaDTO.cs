using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeterinariaServ.Models
{
    public class FacturaDTO
    {
        public string NombreCliente { get; set; }
        public DateTime Fecha { get; set; }
        public int ID { get; set; }
        public decimal Total { get; set; }
    }
}