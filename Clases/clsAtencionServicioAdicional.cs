using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsAtencionServicioAdicional
    {
        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public AtencionServicioAdicional AtencionAS { get; set; }
        public clsAtencionServicioAdicional()
        {
            dbVeterinaria = new dbVeterinariaEntities();
            dbVeterinaria.Configuration.LazyLoadingEnabled = false;
        }

        public string Insertar()
        {
            try
            {
                dbVeterinaria.AtencionServicioAdicionals.Add(AtencionAS);
                dbVeterinaria.SaveChanges();
                return "La atencion del servicio adicional se agrego correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la atencion del servicio adicional " + ex.Message;
            }


        }

        public string Actualizar()
        {
            AtencionServicioAdicional asa = Consultar(AtencionAS.IdAtencion);
            if (asa == null)
            {
                return "El id de la atencion del servicio adicional no es valido";
            }
            dbVeterinaria.AtencionServicioAdicionals.AddOrUpdate(AtencionAS);
            dbVeterinaria.SaveChanges();
            return "Se actualizó la atencion del servicio adicional correctamente";

        }

        public AtencionServicioAdicional Consultar(int Id)
        {
            AtencionServicioAdicional asa = dbVeterinaria.AtencionServicioAdicionals.FirstOrDefault(m => m.IdAtencion == Id);
            return asa;

        }
        public List<AtencionServicioAdicional> ConsultarTodos()
        {
            return dbVeterinaria.AtencionServicioAdicionals
                .OrderBy(p => p.IdAtencion)
                .ToList();
        }
        public string EliminarXId(int Id)
        {
            try
            {

                AtencionServicioAdicional asa = Consultar(Id);
                if (asa == null)
                {
                    return "El id de la atencion del servicio adicional no es valido";
                }
                dbVeterinaria.AtencionServicioAdicionals.Remove(asa);
                dbVeterinaria.SaveChanges();
                return "Se eliminó la atencion del servicio adicional correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}