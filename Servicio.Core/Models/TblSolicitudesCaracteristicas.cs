using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicio.Core.Models
{
    public class TblSolicitudesCaracteristicas
    {

        public int Id_Caracteristica { get; set; }
        public string Descripcion { get; set; }
        public int Tipo { get; set; }
        public System.DateTime? Last_Update { get; set; }
        public int Id_Company { get; set; }
        public int? Activa { get; set; }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<TblSolicitudesCaracteristicas> mapeo)
            {
                mapeo.HasKey(d => d.Id_Caracteristica);

            }

        }
    }
}
