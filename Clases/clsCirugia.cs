using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsCirugia
    {

        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public Cirugia cirugia { get; set; }


        public string Insertar()
        {
            try
            {
                dbVeterinaria.Cirugias.Add(cirugia);
                dbVeterinaria.SaveChanges();
                return "Cirugia agregada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la cirugia:  " + ex.Message;
            }


        }

        public string Actualizar()
        {
            Cirugia ciru = Consultar(cirugia.ID);
            if (ciru == null)
            {
                return "El ID de la cirugia no es válida";
            }
            dbVeterinaria.Cirugias.AddOrUpdate(ciru);
            dbVeterinaria.SaveChanges(); //
            return "Se actualizó la cirugia correctamente ";

        }

        public Cirugia Consultar(int ID)
        {
            Cirugia ciru = dbVeterinaria.Cirugias.FirstOrDefault(c => c.ID == ID);
            return ciru;

        }
        public List<Cirugia> ConsultarTodos()
        {
            return dbVeterinaria.Cirugias
                .OrderBy(c => c.ID)
                .ToList();
        }

        public List<Cirugia> ConsultarPorFecha(DateTime fecha)
        {
            return dbVeterinaria.Cirugias
                .Where(c => c.Fecha == fecha)
                .OrderBy(c => c.Fecha)
                .ToList();
        }

        public List<Cirugia> ConsultarPorMascota(int mascotaID)
        {
            return dbVeterinaria.Cirugias
                .Where(c => c.ID_Mascota == mascotaID)
                .ToList();
        }

        public List<Cirugia> ConsultarTodosPorCosto(double Costo)
        {
            return dbVeterinaria.Cirugias
                .Where(c => c.Costo == (decimal)Costo)
                .OrderBy(c => c.Fecha)
                .ToList();
        }



        public List<Cirugia> ConsultarPorNombreEmpleado(string nombreEmpleado)
        {
            return dbVeterinaria.Cirugias
                   .Include(c => c.Empleado)
                   .Where(c => c.Empleado.Nombre.Contains(nombreEmpleado))
                   .OrderBy(c => c.Fecha)
                   .ToList();
        }
        public string EliminarXID(int ID)
        {
            try
            {
                Cirugia ciru = Consultar(ID);
                if (ciru == null)
                {
                    return "El ID de la cirugia no existe";
                }
                dbVeterinaria.Cirugias.Remove(ciru);
                dbVeterinaria.SaveChanges();
                return "Se eliminó la cirugia correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}