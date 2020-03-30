using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicio.Core
{
    public enum TipoCaracteristicaSolicitud
    {
        Todas = 0,
        //Servicio = 1,
        //Tipo = 2,
        // Lugares=3,
        //Autoriza=4,
        //AutorizaRemision=5,
        //Conductor=6
        Lugares = 1,
        Autoriza = 2,
        AutorizaRemision = 3,
        Conductor = 4
        //EPS=6,
        //Movil=7,
        //Insumo=8
    }
    public enum TipoTercero
    {
        Cliente = 0,
        Proveedor = 1,
        Usuario = 2,
        Paciente = 3,
        Contacto = 4
    }
    public enum RolesUsuario
    {
        Administrador = 1,
        Usuario = 2
    }
    public enum EstadoSolicitud
    {
        Pendiente = 1,//RECIEN REGISTRADO POR LA PAGINA
        Aporobado = 2,//APROBADO POR EL USUARIO
        Completado = 3,//EL USUARIO TERMINO DE REGISTRARLE LOS DATOS
        Contacto = 8,//LA MOVIL TUVO CONTACTO CON EL PACIENTE (REGISTRADO DELSDE EL CEL)
        Salio = 9,//LA MOVIL ESTA SALIENDO CON EL PACIENTE (DESDE EL CEL)
        Rechazado = 4,
        Cancelado = 5,
        Fallido = 6,
        Finalizado = 7
        // = 4,
        //Despachado = 5,
        //EnProcedencia = 6,
        //SaliendoProcedencia = 7,
        //EnTranscurso = 8,
        //Realizado = 10,
        //Fallido = 11,
        //Cancelado = 12
    }
}
