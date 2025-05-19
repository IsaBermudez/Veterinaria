using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsMascota
    {
        private dbVeterinariaEntities veterinaria = new dbVeterinariaEntities();
        public Mascota Mascota { get; set; }

        public List<Mascota> ConsultarTodos()
        {
            return veterinaria.Mascotas.ToList();
        }

        public String Insertar()
        {
            try
            {
                veterinaria.Mascotas.Add(Mascota);
                veterinaria.SaveChanges();
                return "Se ha ingresado con exito la mascota";
            }
            catch (Exception ex)
            {
                return "No se ha podido ingresar la mascota" + ex.Message;
            }
        }

        public String Eliminar(int IdMascota)
        {
            try
            {
                Mascota mascota = veterinaria.Mascotas.FirstOrDefault(m => m.ID == IdMascota);

                if (mascota == null)
                {
                    return "No se encontro la mascota seleccionada";
                }

                veterinaria.Mascotas.Remove(mascota);
                veterinaria.SaveChanges();

                return "¡Mascota eliminada exitosamente!";
            }
            catch (Exception ex)
            {
                return "Error al eliminar la mascota: " + ex.Message;
            }
        }

        public String Actualizar()
        {
            try
            {
                Mascota mascota = Consultar(Mascota.ID);
                if (mascota == null)
                {
                    return "No existe una mascota registrada con este ID ";
                }
                veterinaria.Mascotas.AddOrUpdate(mascota);
                veterinaria.SaveChanges();
                return "Datos de la mascota actualizados con éxito ";
            }
            catch (Exception ex)
            {
                return "No se pudo actualizar los datos de la mascota " + ex.Message;

            }
        }

        public Mascota Consultar(int IdMascota)
        {
            return veterinaria.Mascotas.FirstOrDefault(m => m.ID == IdMascota);
        }
    }
}