using VeterinariaServ.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
    
namespace VeterinariaServ.Clases
{
    public class clsPropietario
    {
        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public Propietario propietario { get; set; }

        public clsPropietario()
        { 
            dbVeterinaria = new dbVeterinariaEntities();
            dbVeterinaria.Configuration.LazyLoadingEnabled = false;
        }
        public string Insertar()
        {
            try
            {
                dbVeterinaria.Propietarios.Add(propietario);
                dbVeterinaria.SaveChanges();
                return "Propietario agregado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el propietario: " + ex.Message;
            }
    
        
        }

        public string Actualizar()
        {
            Propietario prop = Consultar(propietario.Cedula);
            if (prop == null)
            {
                return "La cedula del propietario no es válida";
            }
            dbVeterinaria.Propietarios.AddOrUpdate(propietario); 
            dbVeterinaria.SaveChanges(); 
            return "Se actualizó el propietario correctamente"; 

        }

        public Propietario Consultar(int Cedula)
        {
            Propietario prop = dbVeterinaria.Propietarios.FirstOrDefault(p => p.Cedula == Cedula);
            return prop;

        }
        public List<Propietario> ConsultarTodos()
        {
            return dbVeterinaria.Propietarios
                .OrderBy(p => p.Nombre) 
                .ToList(); 
        }
        public string EliminarXDocumento(int Cedula)
        {
            try
            {

                Propietario prop = Consultar(Cedula); 
                if (prop == null)
                {
                    return "La cedula del propietario no existe";
                }
                dbVeterinaria.Propietarios.Remove(prop); 
                dbVeterinaria.SaveChanges(); 
                return "Se eliminó el propietario correctamente"; 
            }
            catch (Exception ex)
            {
                return ex.Message; 
            }
        }

    }
    
}