using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsServiciosAdicionales
    {
        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public ServiciosAdicionale servicios { get; set; }
        public clsServiciosAdicionales()
        {
            dbVeterinaria = new dbVeterinariaEntities();
            dbVeterinaria.Configuration.LazyLoadingEnabled = false;
        }

        public string Insertar()
        {
            try
            {
                dbVeterinaria.ServiciosAdicionales.Add(servicios);
                dbVeterinaria.SaveChanges();
                return "El servicio adicional se agrego correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el servicio adicional " + ex.Message;
            }


        }

        public string Actualizar()
        {
            ServiciosAdicionale sa = Consultar(servicios.IdServicio);
            if (sa == null)
            {
                return "El id del servicio adicional no es valido";
            }
            dbVeterinaria.ServiciosAdicionales.AddOrUpdate(servicios);
            dbVeterinaria.SaveChanges();
            return "Se actualizó el servicio adicional correctamente";

        }

        public ServiciosAdicionale Consultar(int Id)
        {
            ServiciosAdicionale sa = dbVeterinaria.ServiciosAdicionales.FirstOrDefault(m => m.IdServicio == Id);
            return sa;

        }
        public List<ServiciosAdicionale> ConsultarTodos()
        {
            return dbVeterinaria.ServiciosAdicionales
                .OrderBy(p => p.IdServicio)
                .ToList();
        }
        public string EliminarXId(int Id)
        {
            try
            {

                ServiciosAdicionale sa = Consultar(Id);
                if (sa == null)
                {
                    return "El id del servicio adicional no es valido";
                }
                dbVeterinaria.ServiciosAdicionales.Remove(sa);
                dbVeterinaria.SaveChanges();
                return "Se eliminó el servicio adicional correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}