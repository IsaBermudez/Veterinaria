using global::VeterinariaServ.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{


    namespace VeterinariaServ.Clases
    {
    public class clsHospitalizacion
    {
        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public Hospitalizacion hospitalizacion { get; set; }

            public clsHospitalizacion()
            {
                dbVeterinaria = new dbVeterinariaEntities();
                dbVeterinaria.Configuration.LazyLoadingEnabled = false;
            }
        public string Insertar()
        {
            try
            {
                dbVeterinaria.Hospitalizacions.Add(hospitalizacion);
                dbVeterinaria.SaveChanges();
                return "Hospitalización agregada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la hospitalizacioó:  " + ex.Message;
            }


        }

            public string Actualizar()
            {
                Hospitalizacion hospi = Consultar(hospitalizacion.ID);
                if (hospi == null)
                {
                    return "El ID de la hospitalización no es válida";
                }
                dbVeterinaria.Hospitalizacions.AddOrUpdate(hospitalizacion);
                dbVeterinaria.SaveChanges(); 
                return "Se actualizó la hospitalización correctamente ";

        }

        public Hospitalizacion Consultar(int ID)
        {
            Hospitalizacion hospi = dbVeterinaria.Hospitalizacions.FirstOrDefault(h => h.ID == ID);
            return hospi;

        }
        public List<Hospitalizacion> ConsultarTodos()
        {
            return dbVeterinaria.Hospitalizacions
                .OrderBy(h => h.ID)
                .ToList();
        }

        public List<Hospitalizacion> ConsultarPorFechaEntrada(DateTime fecha)
        {
            return dbVeterinaria.Hospitalizacions
                .Where(h => h.FechaIngreso == fecha)
                .OrderBy(h => h.FechaIngreso)
                .ToList();
        }

        public List<Hospitalizacion> ConsultarPorMascota(int mascotaID)
        {
            return dbVeterinaria.Hospitalizacions
                .Where(h => h.ID_Mascota == mascotaID)
                .ToList();
        }

        public List<Hospitalizacion> ConsultarTodosPorCosto()
        {
            return dbVeterinaria.Hospitalizacions
                .OrderBy(h => h.Costo)
                .ToList();
        }
        public string EliminarXID(int ID)
        {
            try
            {

                Hospitalizacion hospi = Consultar(ID);
                if (hospi == null)
                {
                    return "El ID de la hospitalizacion no existe";
                }
                dbVeterinaria.Hospitalizacions.Remove(hospi);
                dbVeterinaria.SaveChanges();
                return "Se eliminó la hospitalizacion correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

         
            
        }
    }
}
}