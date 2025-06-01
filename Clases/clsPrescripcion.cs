using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsPrescripcion
    {
        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public Prescripcion Prescripcion { get; set; }
        public clsPrescripcion()
        {
            dbVeterinaria = new dbVeterinariaEntities();
            dbVeterinaria.Configuration.LazyLoadingEnabled = false;
        }

        public string Insertar()
        {
            try
            {
                dbVeterinaria.Prescripcions.Add(Prescripcion);
                dbVeterinaria.SaveChanges();
                return "La prescripcion se agrego correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la prescripcion " + ex.Message;
            }


        }

        public string Actualizar()
        {
            Prescripcion pre = Consultar(Prescripcion.Id_Prescripcion);
            if (pre == null)
            {
                return "El id de la prescripción no es valido";
            }
            dbVeterinaria.Prescripcions.AddOrUpdate(Prescripcion);
            dbVeterinaria.SaveChanges();
            return "Se actualizó la prescripción correctamente";

        }

        public Prescripcion Consultar(int Id)
        {
            Prescripcion pre = dbVeterinaria.Prescripcions.FirstOrDefault(m => m.Id_Prescripcion == Id);
            return pre;

        }
        public List<Prescripcion> ConsultarTodos()
        {
            return dbVeterinaria.Prescripcions
                .OrderBy(p => p.Id_Paciente)
                .ToList();
        }
        public string EliminarXId(int Id)
        {
            try
            {

                Prescripcion pre = Consultar(Id);
                if (pre == null)
                {
                    return "El id de la prescripción no es valido";
                }
                dbVeterinaria.Prescripcions.Remove(pre);
                dbVeterinaria.SaveChanges();
                return "Se eliminó la prescripción correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}