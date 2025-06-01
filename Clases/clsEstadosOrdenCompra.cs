using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsEstadosOrdenCompra
    {
        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public EstadosOrdenCompra EstadoCompra { get; set; }
        public clsEstadosOrdenCompra()
        {
            dbVeterinaria = new dbVeterinariaEntities();
            dbVeterinaria.Configuration.LazyLoadingEnabled = false;
        }

        public string Insertar()
        {
            try
            {
                dbVeterinaria.EstadosOrdenCompras.Add(EstadoCompra);
                dbVeterinaria.SaveChanges();
                return "El estado de la compra se agrego correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el estado de la compra " + ex.Message;
            }
        }

        public string Actualizar()
        {
            EstadosOrdenCompra asa = Consultar(EstadoCompra.IdEstado);
            if (asa == null)
            {
                return "El id del estado de la compra no es valido";
            }
            dbVeterinaria.EstadosOrdenCompras.AddOrUpdate(EstadoCompra);
            dbVeterinaria.SaveChanges();
            return "Se actualizó el estado de la compra correctamente";

        }

        public EstadosOrdenCompra Consultar(int Id)
        {
            EstadosOrdenCompra asa = dbVeterinaria.EstadosOrdenCompras.FirstOrDefault(m => m.IdEstado == Id);
            return asa;

        }
        public List<EstadosOrdenCompra> ConsultarTodos()
        {
            return dbVeterinaria.EstadosOrdenCompras
                .OrderBy(p => p.IdEstado)
                .ToList();
        }
        public string EliminarXId(int Id)
        {
            try
            {
                EstadosOrdenCompra asa = Consultar(Id);
                if (asa == null)
                {
                    return "El id del estado de la compra no es valido";
                }
                dbVeterinaria.EstadosOrdenCompras.Remove(asa);
                dbVeterinaria.SaveChanges();
                return "Se eliminó el estado de la compra correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}