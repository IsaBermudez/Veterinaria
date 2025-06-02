using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsOrdenesCompra
    {
        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public OrdenesCompra ordenCompra { get; set; }

        public clsOrdenesCompra()
        {
            dbVeterinaria = new dbVeterinariaEntities();
            dbVeterinaria.Configuration.LazyLoadingEnabled = false;
        }

        public string Insertar()
        {
            try
            {
                dbVeterinaria.OrdenesCompras.Add(ordenCompra);
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
            OrdenesCompra oc = Consultar(ordenCompra.IdCompra);
            if (oc == null)
            {
                return "El id de la orden de compra no es válido";
            }
            dbVeterinaria.OrdenesCompras.AddOrUpdate(ordenCompra);
            dbVeterinaria.SaveChanges();
            return "Se actualizó el orden de compra correctamente";

        }

        public OrdenesCompra Consultar(int Id)
        {
            OrdenesCompra oc = dbVeterinaria.OrdenesCompras.FirstOrDefault(m => m.IdCompra == Id);
            return oc;

        }
        public List<OrdenesCompra> ConsultarTodos()
        {
            return dbVeterinaria.OrdenesCompras
                .OrderBy(p => p.FechaOrden)
                .ToList();
        }
        public string EliminarXId(int Id)
        {
            try
            {

                OrdenesCompra oc = Consultar(Id);
                if (oc == null)
                {
                    return "El id de la orden de compra no es válido";
                }
                dbVeterinaria.OrdenesCompras.Remove(oc);
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