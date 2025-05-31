using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsEspecie
    {
        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public Especie especie { get; set; }
        public clsEspecie()
        {
            dbVeterinaria = new dbVeterinariaEntities();
            dbVeterinaria.Configuration.LazyLoadingEnabled = false;
        }

        public string Insertar()
        {
            try
            {
                dbVeterinaria.Especies.Add(especie);
                dbVeterinaria.SaveChanges();
                return "Especie agregada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la especie:  " + ex.Message;
            }


        }

        public string Actualizar()
        {
            Especie esp = Consultar(especie.ID);
            if (esp == null)
            {
                return "El ID de la especie no es válida";
            }
            dbVeterinaria.Especies.AddOrUpdate(especie);
            dbVeterinaria.SaveChanges(); //
            return "Se actualizó la especie correctamente";

        }

        public Especie Consultar(int ID)
        {
            Especie esp = dbVeterinaria.Especies.FirstOrDefault(e => e.ID == ID);
            return esp;

        }
        public List<Especie> ConsultarTodos()
        {
            return dbVeterinaria.Especies
                .OrderBy(e => e.Nombre)
                .ToList();
        }
        public string EliminarXID(int ID)
        {
            try
            {

                Especie esp = Consultar(ID);
                if (esp == null)
                {
                    return "El ID de la expecie no existe";
                }
                dbVeterinaria.Especies.Remove(esp);
                dbVeterinaria.SaveChanges();
                return "Se eliminó la especie correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}