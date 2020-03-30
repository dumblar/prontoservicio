using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicio.Core.Models
{
    public class TblTerceros
    {
        public string Id_Tercero { get; set; }
        public string Descripcion { get; set; }
        public string Apellidos { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public int TipoTercero { get; set; }
        public string EPS { get; set; }
        public string Edad { get; set; }
        public string Id_Usuario_Titular { get; set; }
        public System.DateTime? Last_Update { get; set; }
        public int? Id_Company { get; set; }
        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<TblTerceros> mapeo)
            {
                mapeo.HasKey(d => d.Id_Tercero);

            }

        }
    }
}
