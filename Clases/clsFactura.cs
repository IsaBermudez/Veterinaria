using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsFactura
    {
        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public Factura factura { get; set; }

        public clsFactura()
        {
            dbVeterinaria = new dbVeterinariaEntities();
            dbVeterinaria.Configuration.LazyLoadingEnabled = false;
        }

        public string Insertar()
        {
            try
            {
                dbVeterinaria.Facturas.Add(factura);
                dbVeterinaria.SaveChanges();
                return "Se agrego correctamente la factura";
            }
            catch (Exception ex)
            {
                return "Error al insertar la factura " + ex.Message;
            }
        }

        public string Actualizar()
        {
            Factura oc = Consultar(factura.ID);
            if (oc == null)
            {
                return "El id de la factura no es válido";
            }
            dbVeterinaria.Facturas.AddOrUpdate(factura);
            dbVeterinaria.SaveChanges();
            return "Se actualizó la factura correctamente";

        }

        public Factura Consultar(int Id)
        {
            Factura oc = dbVeterinaria.Facturas.FirstOrDefault(m => m.ID == Id);
            return oc;

        }
        public List<Factura> ConsultarTodos()
        {
            return dbVeterinaria.Facturas
                .OrderBy(p => p.Fecha)
                .ToList();
        }
        public string EliminarXId(int Id)
        {
            try
            {

                Factura oc = Consultar(Id);
                if (oc == null)
                {
                    return "El id de la factura no es válido";
                }
                dbVeterinaria.Facturas.Remove(oc);
                dbVeterinaria.SaveChanges();
                return "Se eliminó la factura correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}