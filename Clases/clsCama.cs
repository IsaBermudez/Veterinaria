using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsCama
    {

        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public Cama cama { get; set; }


        public string Insertar()
        {
            try
            {
                dbVeterinaria.Camas.Add(cama);
                dbVeterinaria.SaveChanges();
                return "Cama agregada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la hospitalizacioó:  " + ex.Message;
            }


        }

        public string ActualizarEstado(int id, string nuevoEstado)
        {
            Cama cam = Consultar(id);
            if (cam == null)
            {
                return "El ID de la cama no es válido";
            }

            cam.Estado = nuevoEstado; // Solo se actualiza el estado
            dbVeterinaria.SaveChanges();

            return $"Se actualizó el estado de la cama a '{nuevoEstado}' correctamente.";
        }


        public Cama Consultar(int ID)
        {
            Cama cam = dbVeterinaria.Camas.FirstOrDefault(h => h.ID == ID);
            return cam;
        }

        public List<Cama> ConsultarPorEstado(string estado)
        {
            return dbVeterinaria.Camas.Where(c => c.Estado == estado).ToList();
        }



        public string Eliminar(int ID)
        {
            try
            {

                Cama cam = Consultar(ID);
                if (cam == null)
                {
                    return "El ID de la cama no existe";
                }
                dbVeterinaria.Camas.Remove(cam);
                dbVeterinaria.SaveChanges();
                return "Se eliminó la cama correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
    }
}