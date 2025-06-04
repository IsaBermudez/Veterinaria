using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsMascota
    {
        private dbVeterinariaEntities veterinaria = new dbVeterinariaEntities();
        public Mascota Mascota { get; set; }
        public clsMascota()
        {
            veterinaria = new dbVeterinariaEntities();
            veterinaria.Configuration.LazyLoadingEnabled = false;
        }

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
        public IQueryable LlenarCombo()
        {
            return from T in veterinaria.Set<Mascota>()
                   orderby T.Nombre
                   select new
                   {
                       ID = T.ID,
                       Nombre = T.Nombre
                   };
        }

        public List<MascotaDTO> ConsultarPorPropietario(int CedulaPropietario)
        {
            var consulta = from m in veterinaria.Mascotas
                           join r in veterinaria.Razas on m.ID_Raza equals r.ID
                           join e in veterinaria.Especies on r.ID_Especie equals e.ID
                           where m.ID_Propietario == CedulaPropietario
                           select new MascotaDTO
                           {
                               Nombre = m.Nombre,
                               FechaNacimiento = (DateTime)m.FechaNacimiento,
                               NombreEspecie = e.Nombre,
                               NombreRaza = r.Nombre ,
                               Sexo = m.Sexo,
                           };

            return consulta.ToList();
        }
    }
}