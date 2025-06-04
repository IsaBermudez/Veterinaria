using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsCombos
    {
        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public IQueryable LlenarComboCirugia()
        {
            return from T in dbVeterinaria.Set<Cirugia>()
                   join M in dbVeterinaria.Set<Mascota>() on T.ID_Mascota equals M.ID
                   join P in dbVeterinaria.Set<Propietario>() on M.ID_Propietario equals P.Cedula
                   select new
                   {
                       ID = T.ID,
                       Nombre = T.Fecha + " " + M.Nombre,
                   };
        }

        public IQueryable LlenarComboCita()
        {
            return from T in dbVeterinaria.Set<Cita>()
                   join M in dbVeterinaria.Set<Mascota>() on T.ID_Mascota equals M.ID
                   join P in dbVeterinaria.Set<Propietario>() on M.ID_Propietario equals P.Cedula
                   select new
                   {
                       ID = T.ID,
                       Nombre = T.FechaHora + " " + M.Nombre,
                   };
        }

        public IQueryable LlenarComboHospitalizacion()
        {
            return from T in dbVeterinaria.Set<Hospitalizacion>()
                   join M in dbVeterinaria.Set<Mascota>() on T.ID_Mascota equals M.ID
                   join P in dbVeterinaria.Set<Propietario>() on M.ID_Propietario equals P.Cedula
                   select new
                   {
                       ID = T.ID,
                       Nombre = T.FechaIngreso + " " + M.Nombre,
                   };
        }
    }
}