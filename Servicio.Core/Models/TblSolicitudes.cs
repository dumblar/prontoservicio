using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicio.Core.Models
{
    public class TblSolicitudes
    {
        public int Id_Solicitud { get; set; }
        public string CodigoServicio { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public System.DateTime FechaCita { get; set; }
        public System.DateTime FechaRecoger { get; set; }
        public DateTime? FechaDespacho { get; set; }
        public int TipoServicio { get; set; }
        public int? TipoAmbulancia { get; set; }
        public int? TipoPaciente { get; set; }
        public int? Id_Carac_Procedencia { get; set; }
        public int? Id_Carac_Destino { get; set; }
        public int? Id_Carac_Conductor { get; set; }
        public int? Id_Carac_Remision { get; set; }
        public int? Id_Carac_Autoriza { get; set; }
        public string Doctor { get; set; }
        public string Habitacion { get; set; }
        public int? Id_Movil_Recoge { get; set; }
        public int? Id_Movil_Entrega { get; set; }
        public string Id_Usuario { get; set; }
        public string Id_Usuario_Recibe { get; set; }
        public string Diagnostico { get; set; }
        public string Soporte { get; set; }
        public string Id_Tercero { get; set; }
        public string APH { get; set; }
        public string Procedimiento { get; set; }
        public string CodigoAutorizacion { get; set; }
        public string Observaciones { get; set; }
        public int? Prioridad { get; set; }
        public string DescripcionRazonPrioridad { get; set; }
        public int? Estado { get; set; }
        public int? Editando { get; set; }
        public System.DateTime? Last_Update { get; set; }
        public int? Id_Company { get; set; }
        public TimeSpan? HoraEfectiva { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public DateTime? FechaLlego { get; set; }
        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<TblSolicitudes> mapeo)
            {
                mapeo.HasKey(d => d.Id_Solicitud);

            }

        }

    }
}
