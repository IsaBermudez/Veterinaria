using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsProductoFarmacia
    {
        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public Productos_Farmacia ProductosFarmacia { get; set; }

        public clsProductoFarmacia()
        {
            dbVeterinaria = new dbVeterinariaEntities();
            dbVeterinaria.Configuration.LazyLoadingEnabled = false;
        }

        public string Insertar()
        {
            try
            {
                dbVeterinaria.Productos_Farmacia.Add(ProductosFarmacia);
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
            Productos_Farmacia pf = Consultar(ProductosFarmacia.ID);
            if (pf == null)
            {
                return "El id del medicamento de la farmacia no es válido";
            }
            dbVeterinaria.Productos_Farmacia.AddOrUpdate(ProductosFarmacia);
            dbVeterinaria.SaveChanges();
            return "Se actualizó el medicamento correctamente";

        }

        public Productos_Farmacia Consultar(int Id)
        {
            Productos_Farmacia pf = dbVeterinaria.Productos_Farmacia.FirstOrDefault(m => m.ID == Id);
            return pf;

        }
        public List<Productos_Farmacia> ConsultarTodos()
        {
            return dbVeterinaria.Productos_Farmacia
                .OrderBy(p => p.Nombre )
                .ToList();
        }
        public string EliminarXId(int Id)
        {
            try
            {

                Productos_Farmacia pf = Consultar(Id);
                if (pf == null)
                {
                    return "El id del medicamento no es válido";
                }
                dbVeterinaria.Productos_Farmacia.Remove(pf);
                dbVeterinaria.SaveChanges();
                return "Se eliminó el medicamento correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}