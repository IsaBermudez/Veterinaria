using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class clsLogin
    {
        private dbVeterinariaEntities dbVeterinaria = new dbVeterinariaEntities();
        public Login login { get; set; }
        private LoginRespuesta logRpta;
        private bool ValidarUsuario()
        {
            try
            {
               
                User usuario = dbVeterinaria.Users.FirstOrDefault(u => u.Usuario == login.Usuario);
                if (usuario == null)
                {
                    logRpta = new LoginRespuesta();
                    logRpta.Mensaje = "Usuario no existe";
                    return false;
                }
                login.Clave = usuario.Clave;
                return true;
            }
            catch (Exception ex)
            {
                logRpta = new LoginRespuesta();
                logRpta.Mensaje = ex.Message;
                return false;
            }
        }
        public IQueryable<LoginRespuesta> Ingresar()
        {
            if (ValidarUsuario())
            {
                //string token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                string token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                return from U in dbVeterinaria.Set<User>()
                       where U.Usuario == login.Usuario &&
                             U.Clave == login.Clave
                       select new LoginRespuesta
                       {
                           Usuario = U.Usuario,
                           Autenticado = true,
                           Token = token,
                           Mensaje = "Usuario autenticado",
                       };
            }
            else
            {
                return null;
            }
        }
    }
}