using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using System.Web;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsFacturaDet
    {
        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public Detalle_Factura facturaDet { get; set; }

        public clsFacturaDet()
        {
            dbVeterinaria = new dbVeterinariaEntities();
            dbVeterinaria.Configuration.LazyLoadingEnabled = false;
        }

        public string Insertar()
        {
            try
            {
                dbVeterinaria.Detalle_Factura.Add(facturaDet);
                dbVeterinaria.SaveChanges();
                return "Se agrego correctamente el detalle de la factura";
            }
            catch (Exception ex)
            {
                return "Error al insertar el detalle de la factura " + ex.Message;
            }
        }

        public string Actualizar()
        {
            Detalle_Factura oc = Consultar(facturaDet.ID);
            if (oc == null)
            {
                return "El id del detalle de la factura no es válido";
            }
            dbVeterinaria.Detalle_Factura.AddOrUpdate(facturaDet);
            dbVeterinaria.SaveChanges();
            return "Se actualizó el detalle de la factura correctamente";

        }

        public Detalle_Factura Consultar(int Id)
        {
            Detalle_Factura oc = dbVeterinaria.Detalle_Factura.FirstOrDefault(m => m.ID_Factura == Id);
            return oc;

        }
        public List<Detalle_Factura> ConsultarTodos()
        {
            return dbVeterinaria.Detalle_Factura
                .OrderBy(p => p.ID_Factura)
                .ToList();
        }
        public string EliminarXId(int Id)
        {
            try
            {

                Detalle_Factura oc = Consultar(Id);
                if (oc == null)
                {
                    return "El id del detalle de la factura no es válido";
                }
                dbVeterinaria.Detalle_Factura.Remove(oc);
                dbVeterinaria.SaveChanges();
                return "Se eliminó el detalle de la factura correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IQueryable ConsultarXFactura(int ID)
        {
            var consulta = from f in dbVeterinaria.Detalle_Factura
                           where f.ID_Factura == ID
                           select new 
                           {
                               precio = f.PrecioUnitario,
                           };


            return consulta;
        }
    }
}