using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsInventarioFarmacia
    {
        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public InventarioFarmacia Inventario { get; set; }

        public clsInventarioFarmacia()
        {
            dbVeterinaria = new dbVeterinariaEntities();
            dbVeterinaria.Configuration.LazyLoadingEnabled = false;
        }

        public string Insertar()
        {
            try
            {
                dbVeterinaria.InventarioFarmacias.Add(Inventario);
                dbVeterinaria.SaveChanges();
                return "El producto se agrego correctamente al inventario de la farmacia";
            }
            catch (Exception ex)
            {
                return "Error al insertar el producto al inventario de la farmacia " + ex.Message;
            }


        }

        public string Actualizar()
        {
            InventarioFarmacia inf = Consultar(Inventario.IdInventario);
            if (inf == null)
            {
                return "El id del medicamento de la farmacia no es válido";
            }
            dbVeterinaria.InventarioFarmacias.AddOrUpdate(Inventario);
            dbVeterinaria.SaveChanges();
            return "Se actualizó el medicamento de la farmacia correctamente";

        }

        public InventarioFarmacia Consultar(int Id)
        {
            InventarioFarmacia inf = dbVeterinaria.InventarioFarmacias.FirstOrDefault(m => m.IdInventario == Id);
            return inf;

        }
        public List<InventarioFarmacia> ConsultarTodos()
        {
            return dbVeterinaria.InventarioFarmacias
                .OrderBy(p => p.FechaVencimiento)
                .ToList();
        }
        public string EliminarXId(int Id)
        {
            try
            {

                InventarioFarmacia inf = Consultar(Id);
                if (inf == null)
                {
                    return "El id del medicamento no es válido";
                }
                dbVeterinaria.InventarioFarmacias.Remove(inf);
                dbVeterinaria.SaveChanges();
                return "Se eliminó el medicamento de la farmacia correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}