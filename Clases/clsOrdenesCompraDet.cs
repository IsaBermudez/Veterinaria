using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsOrdenesCompraDet
    {
        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public OrdenesCompraDetalle ordenDet { get; set; }

        public clsOrdenesCompraDet()
        {
            dbVeterinaria = new dbVeterinariaEntities();
            dbVeterinaria.Configuration.LazyLoadingEnabled = false;
        }

        public string Insertar()
        {
            try
            {
                dbVeterinaria.OrdenesCompraDetalles.Add(ordenDet);
                dbVeterinaria.SaveChanges();
                return "Se agrego correctamente la orden de compra";
            }
            catch (Exception ex)
            {
                return "Error al insertar la orden de compra " + ex.Message;
            }


        }

        public string Actualizar()
        {
            OrdenesCompraDetalle oc = Consultar(ordenDet.OrdenCompraDetalleID);
            if (oc == null)
            {
                return "El id de la orden de compra no es válido";
            }
            dbVeterinaria.OrdenesCompraDetalles.AddOrUpdate(ordenDet);
            dbVeterinaria.SaveChanges();
            return "Se actualizó el orden de compra correctamente";

        }

        public OrdenesCompraDetalle Consultar(int Id)
        {
            OrdenesCompraDetalle oc = dbVeterinaria.OrdenesCompraDetalles.FirstOrDefault(m => m.OrdenCompraDetalleID == Id);
            return oc;

        }
        public List<OrdenesCompraDetalle> ConsultarTodos()
        {
            return dbVeterinaria.OrdenesCompraDetalles
                .OrderBy(p => p.OrdenCompraDetalleID)
                .ToList();
        }
        public string EliminarXId(int Id)
        {
            try
            {

                OrdenesCompraDetalle oc = Consultar(Id);
                if (oc == null)
                {
                    return "El id de la orden de compra no es válido";
                }
                dbVeterinaria.OrdenesCompraDetalles.Remove(oc);
                dbVeterinaria.SaveChanges();
                return "Se eliminó la orden de compra correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}