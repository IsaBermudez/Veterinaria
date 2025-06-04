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
        public IQueryable PrescripcionConMascota()
        {
            return from p in dbVeterinaria.Set<Prescripcion>()
                   join m in dbVeterinaria.Set<Mascota>() on p.Id_Paciente equals m.ID into mascotas
                   from m in mascotas.DefaultIfEmpty()

                   join r in dbVeterinaria.Set<Raza>() on m.ID_Raza equals r.ID into razas
                   from r in razas.DefaultIfEmpty()

                   join e in dbVeterinaria.Set<Especie>() on r.ID_Especie equals e.ID into especies
                   from e in especies.DefaultIfEmpty()

                   join me in dbVeterinaria.Set<Empleado>() on p.Id_Medico equals me.ID into medicos
                   from me in medicos.DefaultIfEmpty()

                   join med in dbVeterinaria.Set<Productos_Farmacia>() on p.Id_Medicamento equals med.ID into medicamentos
                   from med in medicamentos.DefaultIfEmpty()

                   select new
                   {
                       NombreMascota = m != null ? m.Nombre : null,
                       Raza = r != null ? r.Nombre : null,
                       Especie = e != null ? e.Nombre : null,
                       Sexo = m != null ? m.Sexo : null,
                       Medico = me != null ? me.Nombre : null,
                       Medicamento = med != null ? med.Nombre : null
                   };
        }
            
    }
}