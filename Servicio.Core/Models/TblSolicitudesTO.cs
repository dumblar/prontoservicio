using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicio.Core.Models
{
    public class TblSolicitudesTO
    {

        public TblSolicitudes Solicitud { get; set; }
        //public List<SolicitudesHorasTO> Tiempos { get; set; }
        //public List<TblSolicitudesNotas> Notas { get; set; }
        public TblTerceros Paciente { get; set; }
        //public List<TblTiposEventos> Eventos { get; set; }

        public string DescripcionAutoriza { get; set; }
        public string DescripcionAutorizaRemision { get; set; }

        public string DescripcionUsuarioRegistra { get; set; }
        public string DescripcionUsuarioRecibe { get; set; }


        public string DescripcionProcedencia { get; set; }
        public string DescripcionDestino { get; set; }
        public string DescripcionConductor { get; set; }
        public string DescripcionMovil { get; set; }
        public string DescripcionMovilEntrega { get; set; }

        public string DescripcionTipoAmbulancia { get; set; }
        public string DescripcionTipoServicio { get; set; }
        public string DescripcionTipoPaciente { get; set; }

        public string DescripcionEstado { get; set; }
        public string DescripcionNotas { get; set; }
        public string DescripcionEPSRegistra { get; set; }
        public int Id_Company { get; set; }

        //public class Mapeo
        //{
        //    public Mapeo(EntityTypeBuilder<TblSolicitudesTO> mapeo)
        //    {
        //        mapeo.HasKey(d => d.Solicitud.Id_Solicitud);
        //        mapeo.Property(d => d.Solicitud.Id_Solicitud).HasColumnName("Id_Solicitud");
        //        //mapeoUsuario.Property(d=> d.Descripcion).HasColumnName
        //        //mapeoUsuario.Property(d => d.Descripcion);
        //        //mapeoUsuario.Property(d => d.Rol);
        //        //mapeoUsuario.Property(d => d.Usuario);
        //        //mapeoUsuario.Property(d => d.Contrasena);
        //        //mapeoUsuario.Property(d => d.Activo);
        //        //mapeoUsuario.Property(d => d.Grupo);
        //        //mapeoUsuario.Property(d => d.Sexo);
        //        //mapeoUsuario.Property(d => d.Id_Company);
        //        //mapeoUsuario.table()
                
        //    }
        //}
        //public int DiaCita { get; set; }
        //public int MesCita { get; set; }
        //public int AnoCita { get; set; }
        //public int HoraRecoger { get; set; }
        //public int MinRecoger { get; set; }


    }
}
