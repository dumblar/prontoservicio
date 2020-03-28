using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicio.Core.Models
{
    public  class TblUsuarios
    {
        public string Id_Usuario { get; set; }
        public string Descripcion { get; set; }
        public int Rol { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public int Activo { get; set; }
        public string Grupo { get; set; }
        public int Sexo { get; set; }
        public int Id_Company { get; set; }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder <TblUsuarios> mapeoUsuario)
            {
                mapeoUsuario.HasKey(d => d.Id_Usuario);
                //mapeoUsuario.Property(d=> d.Descripcion).HasColumnName
                //mapeoUsuario.Property(d => d.Descripcion);
                //mapeoUsuario.Property(d => d.Rol);
                //mapeoUsuario.Property(d => d.Usuario);
                //mapeoUsuario.Property(d => d.Contrasena);
                //mapeoUsuario.Property(d => d.Activo);
                //mapeoUsuario.Property(d => d.Grupo);
                //mapeoUsuario.Property(d => d.Sexo);
                //mapeoUsuario.Property(d => d.Id_Company);
                //mapeoUsuario.table()
            }
        }
    }
}
