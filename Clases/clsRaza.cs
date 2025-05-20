using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsRaza
    {
        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public Raza raza { get; set; }


        public string Insertar()
        {
            try
            {
                dbVeterinaria.Razas.Add(raza);
                dbVeterinaria.SaveChanges();
                return "Raza agregada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar una nueva raza: " + ex.Message;
            }


        }

        public string Actualizar()
        {
            Raza raz = Consultar(raza.ID);
            if (raz == null)
            {
                return "El nit de la raza no es válida";
            }
            dbVeterinaria.Razas.AddOrUpdate(raza);
            dbVeterinaria.SaveChanges(); //
            return "Se actualizó la raza correctamente";

        }

        public Raza Consultar(int id)
        {
            Raza raz = dbVeterinaria.Razas.FirstOrDefault(p => p.ID == id);
            return raz;

        }
        public List<Raza> ConsultarTodos()
        {
            return dbVeterinaria.Razas
                .OrderBy(p => p.Nombre)
                .ToList();
        }
        public string EliminarXDocumento(int id)
        {
            try
            {

                Raza raz = Consultar(id);
                if (raz == null)
                {
                    return "El nit de la raza no existe";
                }
                dbVeterinaria.Razas.Remove(raz);
                dbVeterinaria.SaveChanges();
                return "Se eliminó la raza correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}