using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicio.Core.Models
{
    public class TblMoviles
    {
        public int Id_Movil { get; set; }
        public string Descripcion { get; set; }
        public int Id_Company { get; set; }

        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<TblMoviles> mapeo)
            {
                mapeo.HasKey(d => d.Id_Movil);
            }

        }
    }
}
