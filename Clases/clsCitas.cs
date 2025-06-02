using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsCita
    {
        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public Cita cita { get; set; }


        public string Insertar()
        {
            try
            {


                dbVeterinaria.Citas.Add(cita);
                dbVeterinaria.SaveChanges();
                return "Cita agregada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la cita:  " + ex.Message;
            }


        }

        public string Actualizar()
        {
            Cita cit = Consultar(cita.ID);
            if (cit == null)
            {
                return "El ID de la cita no es válida";
            }
            dbVeterinaria.Citas.AddOrUpdate(cita);
            dbVeterinaria.SaveChanges(); //
            return "Se actualizó la cita correctamente ";

        }

        public Cita Consultar(int ID)
        {
            Cita cit = dbVeterinaria.Citas.FirstOrDefault(c => c.ID == ID);
            return cit;

        }
        public List<Cita> ConsultarTodos()
        {
            return dbVeterinaria.Citas
                .OrderBy(c => c.Fecha)
                .ToList();
        }

        public List<Cita> ConsultarPorFecha(DateTime fecha)
        {
            return dbVeterinaria.Citas
                .Where(c => c.Fecha == fecha)
                .OrderBy(c => c.Fecha)
                .ToList();
        }

        public List<Cita> ConsultarPorMascota(int mascotaID)
        {
            return dbVeterinaria.Citas
                .Where(c => c.ID_Mascota == mascotaID)
                .ToList();
        }
        public string EliminarXID(int ID)
        {
            try
            {

                Cita cit = Consultar(ID);
                if (cit == null)
                {
                    return "El ID de la cita no existe";
                }
                dbVeterinaria.Citas.Remove(cit);
                dbVeterinaria.SaveChanges();
                return "Se eliminó la cita correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}