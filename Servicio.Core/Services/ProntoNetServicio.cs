using Microsoft.IdentityModel.Tokens;
using Servicio.Core.Helpers;
using Servicio.Core.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.Services
{
    public class ProntoNetServicio
    {
        private readonly ProntoServiciosDBContext _prontoContext;
        public ProntoNetServicio(ProntoServiciosDBContext contex)
        {
            _prontoContext = contex;
        }
        public TblUsuarios IniciarSesion(string email,string contrasena)
        {
            var user = _prontoContext.TblUsuarios.SingleOrDefault(u => u.Usuario == email && u.Contrasena == contrasena);

            // return null if user not found
            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("this-is-my-secret-password");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Id_Usuario)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user.WithoutPassword();
        }

    }
}
