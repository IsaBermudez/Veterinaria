using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsCiudad
    {
        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public Ciudad ciudad { get; set; }

        public clsCiudad()
        {
            dbVeterinaria = new dbVeterinariaEntities();
            dbVeterinaria.Configuration.LazyLoadingEnabled = false;
        }
        public string Insertar()
        {
            try
            {
                dbVeterinaria.Ciudads.Add(ciudad);
                dbVeterinaria.SaveChanges();
                return "Ciudad agregada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la Ciudad: " + ex.Message;
            }


        }

        public string Actualizar()
        {
            Ciudad ciu = Consultar(ciudad.ID);
            if (ciu == null)
            {
                return "El Id de la ciudad no es válido";
            }
            dbVeterinaria.Ciudads.AddOrUpdate(ciudad);
            dbVeterinaria.SaveChanges();
            return "Se actualizó la ciudad correctamente";

        }

        public Ciudad Consultar(int Id)
        {
            Ciudad ciu = dbVeterinaria.Ciudads.FirstOrDefault(c => c.ID == Id);
            return ciu;

        }
        public List<Ciudad> ConsultarTodos()
        {
            return dbVeterinaria.Ciudads
                .OrderBy(c => c.Nombre)
                .ToList();
        }
        public string EliminarXId(int Id)
        {
            try
            {

                Ciudad ciu = Consultar(Id);
                if (ciu == null)
                {
                    return "El Id de la ciudad no es válida";
                }
                dbVeterinaria.Ciudads.Remove(ciu);
                dbVeterinaria.SaveChanges();
                return "Se eliminó la ciudad correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}