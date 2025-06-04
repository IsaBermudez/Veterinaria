using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsSede
    {
        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public Sede sede { get; set; }

        public clsSede()
        {
            dbVeterinaria = new dbVeterinariaEntities();
            dbVeterinaria.Configuration.LazyLoadingEnabled = false;
        }

        public string Insertar()
        {
            try
            {
                dbVeterinaria.Sedes.Add(sede);
                dbVeterinaria.SaveChanges();
                return "Sede agregada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar una nueva sede: " + ex.Message;
            }


        }

        public string Actualizar()
        {
            Sede sed = Consultar(sede.ID);
            if (sed == null)
            {
                return "El nit de la sede no es válida";
            }
            dbVeterinaria.Sedes.AddOrUpdate(sede);
            dbVeterinaria.SaveChanges(); //
            return "Se actualizó la sede correctamente";

        }

        public Sede Consultar(int id)
        {
            Sede sed = dbVeterinaria.Sedes.FirstOrDefault(p => p.ID == id);
            return sed;

        }
        public List<Sede> ConsultarTodos()
        {
            return dbVeterinaria.Sedes
                .OrderBy(p => p.Nombre)
                .ToList();
        }

        public IQueryable LlenarCombo()
        {
            return from T in dbVeterinaria.Set<Sede>()
                   orderby T.Nombre
                   select new
                   {
                       Codigo = T.ID,
                       Nombre = T.Nombre
                   };
        }
        public string EliminarXDocumento(int id)
        {
            try
            {

                Sede Sed = Consultar(id);
                if (Sed == null)
                {
                    return "El nit de la sede no existe";
                }
                dbVeterinaria.Sedes.Remove(Sed);
                dbVeterinaria.SaveChanges();
                return "Se eliminó la sede correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}