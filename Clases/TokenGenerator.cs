using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;
using VeterinariaServ.Models;

namespace VeterinariaServ.Clases
{
    public class TokenGenerator
    {
        public static string GenerateTokenJwt(string username)
        {
            // Configuración
            var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
            var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
            var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
            var expireTime = ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"];

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // 🔽 Obtener el rol único del usuario
            string userRole = GetUserRole(username); // <-- deberías definir esta función

            // Construir claims
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, username),
        new Claim(ClaimTypes.Role, userRole) // solo un rol
    };

            var claimsIdentity = new ClaimsIdentity(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }

        private static string GetUserRole(string username)
        {
            using (var dbVeterinaria = new dbVeterinariaEntities())
            {
                var rol = dbVeterinaria.Users
                           .Where(u => u.Usuario == username)
                           .Select(u => u.Rol)
                           .FirstOrDefault();

                return rol ?? "Empleado"; // Rol por defecto si no se encuentra
            }
        }


    }
}