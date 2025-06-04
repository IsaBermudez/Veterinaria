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

        public clsCita()
        {
            dbVeterinaria = new dbVeterinariaEntities();
            dbVeterinaria.Configuration.LazyLoadingEnabled = false;
        }


        public string Insertar()
        {
            try
            {
                // Verificar si ya existe una cita con la misma fecha y hora,
                // mismo tipo de cita, mismo empleado y estado = 1 (ocupado)
                bool yaExiste = dbVeterinaria.Citas.Any(c =>
                    c.FechaHora == cita.FechaHora &&
                    c.TipoCita == cita.TipoCita &&
                    c.ID_Empleado == cita.ID_Empleado &&
                    c.Estado == true
                );

                if (yaExiste)
                {
                    return "Ya existe una cita para ese empleado, fecha, hora y tipo. No se puede duplicar.";
                }

                dbVeterinaria.Citas.Add(cita);
                dbVeterinaria.SaveChanges();
                return "Cita agregada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la cita: " + ex.Message;
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
                .OrderBy(c => c.FechaHora)
                .ToList();
        }

        public List<Cita> ConsultarPorFecha(DateTime fecha)
        {
            return dbVeterinaria.Citas
                .Where(c => c.FechaHora == fecha)
                .OrderBy(c => c.FechaHora)
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

        public bool EstaDisponible(DateTime fechaHora, String tipoDeCita)
        {
            // Verifica si ya hay una cita con el mismo DateTime y:
            // - Estado = 1 (no disponible)
            // - o mismo TipoDeCita
            var existe = dbVeterinaria.Citas.Any(c =>
                c.FechaHora == fechaHora &&
                (c.Estado == true && c.TipoCita == tipoDeCita)
            );

            // Si no existe tal cita, entonces está disponible
            return !existe;
        }

        public List<DateTime> ConsultarFechasDisponibles(DateTime desde, DateTime hasta, String tipoDeCita)
        {
            List<DateTime> fechasDisponibles = new List<DateTime>();

            for (DateTime fecha = desde.Date; fecha <= hasta.Date; fecha = fecha.AddDays(1))
            {
                // Aquí puedes definir los horarios por día, por ejemplo:
                for (int hora = 8; hora <= 17; hora++) // 8 AM a 5 PM
                {
                    DateTime fechaHora = new DateTime(fecha.Year, fecha.Month, fecha.Day, hora, 0, 0);

                    if (EstaDisponible(fechaHora, tipoDeCita))
                    {
                        fechasDisponibles.Add(fechaHora);
                    }
                }
            }

            return fechasDisponibles;
        }


        public IQueryable ObtenerCitaDetallada()
        {
            return from c in dbVeterinaria.Set<Cita>()
                   join m in dbVeterinaria.Set<Mascota>() on c.ID_Mascota equals m.ID
                   join emp in dbVeterinaria.Set<Empleado>() on c.ID_Empleado equals emp.ID
                   join s in dbVeterinaria.Set<Sede>() on c.ID_Sede equals s.ID
                   select new
                   {
                       ID_Cita = c.ID,
                       NombreMascota = m.Nombre,
                       NombreEmpleado = emp.Nombre,
                       NombreSede = s.Nombre,
                       FechaHora = c.FechaHora,
                       Estado = c.Estado,
                       TipoCita = c.TipoCita
                   };
        }


    }
}