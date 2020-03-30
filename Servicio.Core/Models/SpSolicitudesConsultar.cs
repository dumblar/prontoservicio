using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicio.Core.Models
{
    public class SpSolicitudesConsultar
    {
        public int Id_Solicitud { get; set; }
        public string CodigoServicio { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaCita { get; set; }
        public DateTime FechaRecoger { get; set; }
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
        public string DescripcionUsuarioRegistra { get; set; }
        public string DescripcionPaciente { get; set; }
        public string ApellidosPaciente { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public int? TipoTercero { get; set; }
        public string EPS { get; set; }
        public string Edad { get; set; }
        public string DescripcionMovilEntrega { get; set; }
        public string DescripcionMovil { get; set; }
        public string DescripcionAutoriza { get; set; }
        public string DescripcionRemision { get; set; }
        public string DescripcionConductor { get; set; }
        public string DescripcionDestino { get; set; }
        public string DescripcionProcedencia { get; set; }
        public string DescripcionTipoAmbulancia { get; set; }
        public string DescripcionTipoServicio { get; set; }
        public string DescripcionTipoPaciente { get; set; }
        public DateTime? FechaLlego { get; set; }
        public string DescripcionUsuarioRecibe { get; set; }
        public string Grupo { get; set; }
        public TimeSpan? HoraEfectiva { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public int Id_Company { get; set; }
        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<SpSolicitudesConsultar> mapeo)
            {
                mapeo.HasKey(d => d.Id_Solicitud);
            }

        }
    }
}
