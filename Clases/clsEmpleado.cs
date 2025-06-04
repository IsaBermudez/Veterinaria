using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using System.Web;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsEmpleado
    {
        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public Empleado empleado { get; set; }

        public clsEmpleado()
        {
            dbVeterinaria = new dbVeterinariaEntities();
            dbVeterinaria.Configuration.LazyLoadingEnabled = false;
        }

        public string Insertar()
        {
            try
            {
                dbVeterinaria.Empleadoes.Add(empleado);
                dbVeterinaria.SaveChanges();
                return "El empleado se agrego correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el empleado " + ex.Message;
            }


        }

        public string Actualizar()
        {
            Empleado pf = Consultar(empleado.ID);
            if (pf == null)
            {
                return "El id del empleado no es válido";
            }
            dbVeterinaria.Empleadoes.AddOrUpdate(empleado);
            dbVeterinaria.SaveChanges();
            return "Se actualizó el empleado correctamente";

        }

        public Empleado Consultar(int Id)
        {
            Empleado pf = dbVeterinaria.Empleadoes.FirstOrDefault(m => m.ID == Id);
            return pf;

        }
        public List<Empleado> ConsultarTodos()
        {
            return dbVeterinaria.Empleadoes
                .OrderBy(p => p.Nombre)
                .ToList();
        }
        public string EliminarXId(int Id)
        {
            try
            {

                Empleado pf = Consultar(Id);
                if (pf == null)
                {
                    return "El id del empleado no es válido";
                }
                dbVeterinaria.Empleadoes.Remove(pf);
                dbVeterinaria.SaveChanges();
                return "Se eliminó el empleado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IQueryable LlenarCombo()
        {
            return from T in dbVeterinaria.Set<Empleado>()
                   orderby T.Nombre
                   select new
                   {
                       Codigo = T.ID,
                       Nombre = T.Nombre
                   };
        }
    }
}