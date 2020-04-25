using Servicio.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicio.Core.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<TblUsuarios> WithoutPasswords(this IEnumerable<TblUsuarios> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static TblUsuarios WithoutPassword(this TblUsuarios user)
        {
            user.Contrasena = null;
            return user;
        }
    }
}
