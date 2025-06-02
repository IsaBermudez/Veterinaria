using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsUsuario
    {
        private dbVeterinariaEntities dbVeterinariaEntities = new dbVeterinariaEntities();
        public User usuarioo { get; set; }
      

        public string Insertar()
        {
            try
            {
                dbVeterinariaEntities.Users.Add(usuarioo);
                dbVeterinariaEntities.SaveChanges();
                return "Usuario creado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al crear el usuario: " + ex.Message;
            }


        }
    }
}