using Servicio.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicio.Core.Services
{
    public class ProntoServicio
    {
        private readonly ProntoServiciosDBContext _prontoContext;
        public ProntoServicio(ProntoServiciosDBContext contex)
        {
            _prontoContext = contex;
        }

        public TblUsuarios IniciarSesion(string usuario, string contrasena)
        {
            TblUsuarios objSesion = new TblUsuarios();
            try
            {

                objSesion = _prontoContext.TblUsuarios.Where(u => u.Usuario == usuario && u.Contrasena == contrasena).SingleOrDefault();
                if (objSesion == null)
                    throw new Exception("Usuario o contraseña incorrectos");
                return objSesion;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
