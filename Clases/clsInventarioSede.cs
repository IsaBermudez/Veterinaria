using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsInventarioSede
    {
        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public InventarioSede Inventario { get; set; }
        public clsInventarioSede()
        {
            dbVeterinaria = new dbVeterinariaEntities();
            dbVeterinaria.Configuration.LazyLoadingEnabled = false;
        }

        public string Insertar()
        {
            try
            {
                dbVeterinaria.InventarioSedes.Add(Inventario);
                dbVeterinaria.SaveChanges();
                return "El producto se agrego correctamente al inventario de la sede";
            }
            catch (Exception ex)
            {
                return "Error al insertar el producto al inventario de la sede " + ex.Message;
            }


        }

        public string Actualizar()
        {
            InventarioSede invs = Consultar(Inventario.IdInventarioSede);
            if (invs == null)
            {
                return "El id del medicamento del inventario de la sede no es válido";
            }
            dbVeterinaria.InventarioSedes.AddOrUpdate(Inventario);
            dbVeterinaria.SaveChanges();
            return "Se actualizó el medicamento del inventario de la sede correctamente";

        }

        public InventarioSede Consultar(int Id)
        {
            InventarioSede invs = dbVeterinaria.InventarioSedes.FirstOrDefault(m => m.IdInventarioSede == Id);
            return invs;

        }
        public List<InventarioSede> ConsultarTodos()
        {
            return dbVeterinaria.InventarioSedes
                .OrderBy(p => p.FechaVencimiento)
                .ToList();
        }
        public string EliminarXId(int Id)
        {
            try
            {

                InventarioSede invs = Consultar(Id);
                if (invs == null)
                {
                    return "El id del medicamento no es válido";
                }
                dbVeterinaria.InventarioSedes.Remove(invs);
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