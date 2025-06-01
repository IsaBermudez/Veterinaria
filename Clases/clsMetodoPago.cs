using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsMetodoPago
    {
        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public MetodoPago metPago { get; set; }

        public clsMetodoPago()
        {
            dbVeterinaria = new dbVeterinariaEntities();
            dbVeterinaria.Configuration.LazyLoadingEnabled = false;
        }

        public string Insertar()
        {
            try
            {
                dbVeterinaria.MetodoPagoes.Add(metPago);
                dbVeterinaria.SaveChanges();
                return "El metodo de pago se agrego correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el metodo de pago: " + ex.Message;
            }


        }

        public string Actualizar()
        {
            MetodoPago mp = Consultar(metPago.IdMetodoPago);
            if (mp == null)
            {
                return "El id del metodo de pago no es válido";
            }
            dbVeterinaria.MetodoPagoes.AddOrUpdate(metPago);
            dbVeterinaria.SaveChanges();
            return "Se actualizó el metodo de pago correctamente";

        }

        public MetodoPago Consultar(int Id)
        {
            MetodoPago mp = dbVeterinaria.MetodoPagoes.FirstOrDefault(m => m.IdMetodoPago == Id);
            return mp;

        }
        public List<MetodoPago> ConsultarTodos()
        {
            return dbVeterinaria.MetodoPagoes
                .OrderBy(c => c.NombreMetodo)
                .ToList();
        }
        public string EliminarXId(int Id)
        {
            try
            {

                MetodoPago mp = Consultar(Id);
                if (mp == null)
                {
                    return "El id del metodo de pago no es válido";
                }
                dbVeterinaria.MetodoPagoes.Remove(mp);
                dbVeterinaria.SaveChanges();
                return "Se eliminó el metodo de pago correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }




    }
}