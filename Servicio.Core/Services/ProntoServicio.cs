using Servicio.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Servicio.Core.Services
{
    public class ProntoServicio
    {
        private readonly ProntoServiciosDBContext _prontoContext;
        private static  ProntoServicio _prontoSerContext = new ProntoServicio();
        public ProntoServicio(ProntoServiciosDBContext contex)
        {
            _prontoContext = contex;
        }
        public ProntoServicio()
        {

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

        public int SetCaracteristica(string descripcionAutoriza, int tipo, int id_Company)
        {
            TblSolicitudesCaracteristicas car = _prontoContext.TblSolicitudesCaracteristicas
                .Where(d => d.Descripcion == descripcionAutoriza && d.Tipo== tipo).FirstOrDefault();
            if (car == null)
            {
                car = new TblSolicitudesCaracteristicas();
                car.Descripcion = descripcionAutoriza;
                car.Tipo = tipo;
                car.Id_Company = id_Company;
                _prontoContext.TblSolicitudesCaracteristicas.Add(car);
                _prontoContext.SaveChanges();

            }
            return car.Id_Caracteristica;
        }

        public List<TblSolicitudesCaracteristicas> GetCaracteristicas(int id_Company)
        {
            return _prontoContext.TblSolicitudesCaracteristicas.Where(d => d.Id_Company == id_Company).ToList();
        }

        public  List<TblTerceros> GetTerceros(TipoTercero tipoTercero, int id_company)
        {
                return _prontoContext.TblTerceros.Where(t => t.TipoTercero == (int)tipoTercero && t.Id_Company == id_company).ToList();
        }
        public List<TblMoviles> GetMoviles(int v)
        {
                return _prontoContext.TblMoviles.Where(m=> m.Id_Company== v).ToList();
        }
        //public List<d> GetTiposEventos()
        //{
        //    throw new NotImplementedException();
        //}
        public List<TblSolicitudesTO> GetSolicitudes(string usuario, DateTime fechaInicio, DateTime fechaFin, bool editando, int id_company)
        {
            List<SpSolicitudesConsultar> consulta = new List<SpSolicitudesConsultar>();
            List<TblSolicitudesTO> resultado = new List<TblSolicitudesTO>();

            TimeSpan ts = new TimeSpan(00, 00, 0);
            TimeSpan ts2 = new TimeSpan(23, 59, 59);
            fechaInicio = fechaInicio.Date + ts;
            fechaFin = fechaFin.Date + ts2;
            string strFechaInicio = "STR_TO_DATE('" + fechaInicio.ToString("dd/MM/yyyyHH:mm:ss").Replace(" ", "").Replace(".", "") + "', '%d/%m/%Y%h:%i:%s%p') ";
            string strFechaFin = "STR_TO_DATE('" + fechaFin.ToString("dd/MM/yyyyHH:mm:ss").Replace(" ", "").Replace(".", "") + "', '%d/%m/%Y%h:%i:%s%p') ";
            string sql = $"call innovaci_ProntoAmbulancias.SpSolicitudesConsultar('{usuario}', {strFechaInicio}, {strFechaFin}, {editando}, {id_company});";
            Console.WriteLine(sql);
            consulta = _prontoContext.SpSolicitudesConsultar.FromSql(sql).ToList();

            foreach (SpSolicitudesConsultar sol in consulta)
            {
                //List<TblSolicitudesNotas> consutlanotas = _prontoSerContext.get NotasConsultar(sol.Id_Solicitud);
                sol.FechaCita = sol.FechaCita;
                sol.FechaRegistro = sol.FechaRegistro;
                sol.FechaRecoger = sol.FechaRecoger;
                if (sol.FechaDespacho != null)
                    sol.FechaDespacho = sol.FechaDespacho.Value;
                if (sol.FechaLlego != null)
                    sol.FechaLlego = sol.FechaLlego.Value;
                resultado.Add(new TblSolicitudesTO()
                {
                    Solicitud = EntityTransport<TblSolicitudes>.Copy(sol, new TblSolicitudes()),
                    Paciente = new TblTerceros()
                    {
                        Id_Tercero = sol.Id_Tercero,
                        Apellidos = sol.ApellidosPaciente,
                        Descripcion = sol.DescripcionPaciente,
                        Edad = sol.Edad,
                        EPS = sol.EPS,
                        TipoTercero = 3
                    },
                    //Tiempos = AdminSolicitudes.TiemposConsultar(sol.Id_Solicitud),
                    //Eventos = AdminSolicitudes.EventosConsultar(sol.Id_Solicitud),
                    //Notas = consutlanotas,
                    DescripcionAutoriza = sol.DescripcionAutoriza,
                    DescripcionUsuarioRecibe = sol.DescripcionUsuarioRecibe,
                    DescripcionUsuarioRegistra = sol.DescripcionUsuarioRegistra,
                    DescripcionConductor = sol.DescripcionConductor,
                    DescripcionAutorizaRemision = sol.DescripcionRemision,
                    DescripcionDestino = sol.DescripcionDestino,
                    DescripcionProcedencia = sol.DescripcionProcedencia,
                    DescripcionMovil = sol.DescripcionMovil,
                    DescripcionMovilEntrega = sol.DescripcionMovilEntrega,
                    DescripcionTipoAmbulancia = sol.TipoAmbulancia == 1 ? "BAJA" : sol.TipoAmbulancia == 2 ? "ALTA" : "",
                    DescripcionTipoServicio = sol.TipoServicio == 1 ? "PRIMARIO" : sol.TipoServicio == 2 ? "SECUNDARIO" : "",
                    DescripcionTipoPaciente = sol.TipoPaciente == 1 ? "ADULTO" : sol.TipoPaciente == 2 ? "PEDIATRICO" : "",
                    DescripcionEstado = sol.Estado == 1 ? "Pendiente" : sol.Estado == 2 ? "Aporobado" : sol.Estado == 3 ? "Completado" : sol.Estado == 4 ? "Rechazado" : "",
                    //DescripcionNotas = AdminSolicitudes.DescripcionNotasConsultar(consutlanotas),
                    DescripcionEPSRegistra = sol.Grupo
                });
            }
            return resultado.OrderBy(r => r.Solicitud.FechaCita).ToList();

        }

      

        private void SetTercero(string id_Tercero, string descripcion, string apellidos, int paciente, string edad, string ePS, int id_Company)
        {
            TblTerceros ter = _prontoContext.TblTerceros.Find(id_Tercero);
            if (ter == null)
            {
                ter = new TblTerceros();
                ter.Descripcion = descripcion;
                ter.Apellidos = apellidos;
                ter.Edad = edad;
                ter.EPS = ePS;
                ter.TipoTercero = paciente;
                ter.Id_Company = id_Company;
                _prontoContext.TblTerceros.Add(ter);
                _prontoContext.SaveChanges();

            }
            else
            {
                ter.Descripcion = descripcion;
                ter.Apellidos = apellidos;
                ter.Edad = edad;
                ter.EPS = ePS;
                _prontoContext.SaveChanges();
            }
        }


        public void SetSolicitudes(TblSolicitudesTO objSolicitudExterna)
        {

            /*AUTORIZA*/
            if (objSolicitudExterna.DescripcionAutoriza != null)
            {
                int codigo_autoriza = _prontoSerContext.SetCaracteristica(objSolicitudExterna.DescripcionAutoriza, (int)TipoCaracteristicaSolicitud.Autoriza, objSolicitudExterna.Id_Company);
                objSolicitudExterna.Solicitud.Id_Carac_Autoriza = int.Parse(codigo_autoriza.ToString());
            }

            /*AUTORIZA REMISION*/
            if (objSolicitudExterna.DescripcionAutorizaRemision != null)
            {
                int codigo_autoriza = _prontoSerContext.SetCaracteristica(objSolicitudExterna.DescripcionAutorizaRemision, (int)TipoCaracteristicaSolicitud.AutorizaRemision, objSolicitudExterna.Id_Company);
                objSolicitudExterna.Solicitud.Id_Carac_Remision = int.Parse(codigo_autoriza.ToString());
            }
            /*PROCEDENCIA*/
            if (objSolicitudExterna.DescripcionProcedencia != null)
            {
                int codigo_autoriza = _prontoSerContext.SetCaracteristica(objSolicitudExterna.DescripcionProcedencia, (int)TipoCaracteristicaSolicitud.Lugares, objSolicitudExterna.Id_Company);
                objSolicitudExterna.Solicitud.Id_Carac_Procedencia = int.Parse(codigo_autoriza.ToString());
            }
            /*DESTINO*/
            if (objSolicitudExterna.DescripcionDestino != null)
            {
                int codigo_autoriza = _prontoSerContext.SetCaracteristica(objSolicitudExterna.DescripcionDestino, (int)TipoCaracteristicaSolicitud.Lugares, objSolicitudExterna.Id_Company);
                objSolicitudExterna.Solicitud.Id_Carac_Destino = int.Parse(codigo_autoriza.ToString());
            }
            /*CONDUCTOR*/
            if (objSolicitudExterna.DescripcionConductor != null)
            {
                int codigo_autoriza = _prontoSerContext.SetCaracteristica(objSolicitudExterna.DescripcionConductor, (int)TipoCaracteristicaSolicitud.Conductor, objSolicitudExterna.Id_Company);
                objSolicitudExterna.Solicitud.Id_Carac_Conductor = int.Parse(codigo_autoriza.ToString());
            }
            /*PACIENTE*/
            if (objSolicitudExterna.Paciente.Id_Tercero != null)
                _prontoSerContext.SetTercero(objSolicitudExterna.Paciente.Id_Tercero, objSolicitudExterna.Paciente.Descripcion,
                    objSolicitudExterna.Paciente.Apellidos, (int)TipoTercero.Paciente, objSolicitudExterna.Paciente.Edad,
                    objSolicitudExterna.Paciente.EPS, objSolicitudExterna.Id_Company);



            objSolicitudExterna.Solicitud.Id_Tercero = objSolicitudExterna.Paciente.Id_Tercero;

            //_prontoContext.SaveChanges();

            TblSolicitudes objDel = _prontoContext.TblSolicitudes.Find( objSolicitudExterna.Solicitud.Id_Solicitud);

            if (objSolicitudExterna.Solicitud.Id_Solicitud > 0)
            {
                //if (p.DescripcionReferencia.Substring(p.DescripcionReferencia.Length - 1, 1) == "*")
                //    context.TblDetalleInternos.Remove(objDel);
                //else


                //CONSERVAR LAS FECHAS QUE NO SE PUEDEN MODIFICAR
                DateTime fechaRegistroGuardar = objDel.FechaRegistro;
                DateTime fechaCitaGuardar = objDel.FechaCita;
                DateTime fechaRecogerGuardar = objDel.FechaRecoger;

                if (objDel.FechaDespacho == null && objSolicitudExterna.Solicitud.Id_Movil_Recoge != null)//ASIGNAR MOVIL A SOLICITUD
                {
                    objSolicitudExterna.Solicitud.Estado = (int)EstadoSolicitud.Aporobado;
                    objSolicitudExterna.Solicitud.FechaDespacho = DateTime.UtcNow.AddHours(-5);
                }

                if (objDel.FechaLlego == null && objSolicitudExterna.Solicitud.Estado == (int)EstadoSolicitud.Finalizado)
                {
                    if (objSolicitudExterna.Solicitud.TipoServicio == 1)//SI ES SIMPLE LA MOVIL QUE ENTREGA ES LA MISMA QUE RECOGE
                        objSolicitudExterna.Solicitud.Id_Movil_Entrega = objSolicitudExterna.Solicitud.Id_Movil_Recoge;

                    objSolicitudExterna.Solicitud.Estado = (int)EstadoSolicitud.Finalizado;
                    objSolicitudExterna.Solicitud.HoraEfectiva = objDel.HoraEfectiva;//ALGUN DIA ARREGLAR ESTA VAIA
                    objSolicitudExterna.Solicitud.FechaLlego = DateTime.UtcNow.AddHours(-5);
                }

                if (objSolicitudExterna.Solicitud.Id_Movil_Recoge == 555)//PARA REVERTIR CAMBIOS EN LAS FECHAS
                {
                    objSolicitudExterna.Solicitud.FechaDespacho = null;
                    objSolicitudExterna.Solicitud.Id_Movil_Recoge = null;
                    objSolicitudExterna.Solicitud.Estado = 1;
                }

                if (objDel.Estado == (int)EstadoSolicitud.Pendiente && objSolicitudExterna.Solicitud.Estado == (int)EstadoSolicitud.Rechazado)
                {
                    objSolicitudExterna.Solicitud.Editando = 0;

                }

                if (objDel.HoraEfectiva == null && objSolicitudExterna.Solicitud.Estado == (int)EstadoSolicitud.Contacto)
                {
                    objSolicitudExterna.Solicitud.HoraEfectiva = DateTime.UtcNow.AddHours(-5).TimeOfDay;
                }
                else
                    objSolicitudExterna.Solicitud.HoraEfectiva = objDel.HoraEfectiva;

                if (objDel.HoraSalida == null && objSolicitudExterna.Solicitud.Estado == (int)EstadoSolicitud.Salio)
                {
                    objSolicitudExterna.Solicitud.HoraSalida = DateTime.UtcNow.AddHours(-5).TimeOfDay;
                }
                else
                    objSolicitudExterna.Solicitud.HoraSalida = objDel.HoraSalida;//DE QUE ME TOQUE GUARDAR LAS FECHAS POR SI VIENEN NULL


                objDel = EntityTransport<TblSolicitudes>.Copy(objSolicitudExterna.Solicitud, objDel);
                objDel.Last_Update = DateTime.Now;
                objDel.FechaRegistro = fechaRegistroGuardar;
            }
            else
            {

                objSolicitudExterna.Solicitud.FechaRegistro = DateTime.UtcNow.AddHours(-5);
                objSolicitudExterna.Solicitud.FechaRecoger = objSolicitudExterna.Solicitud.FechaCita.AddHours(-1);
                objSolicitudExterna.Solicitud.Last_Update = DateTime.Now;
                objSolicitudExterna.Solicitud.Estado = 1;
                _prontoContext.TblSolicitudes.Add(objSolicitudExterna.Solicitud);
            }

            _prontoContext.SaveChanges();




        }

        
    }
    public static class EntityTransport<T>
    {
        public static T Copy(object source, T destination)
        {
            PropertyInfo[] propsDestin = destination.GetType().GetProperties();

            foreach (PropertyInfo prop in propsDestin)
            {
                PropertyInfo p = source.GetType().GetProperty(prop.Name);
                if (p == null)
                    continue;
                object value = p.GetValue(source, null);
                prop.SetValue(destination, value, null);
            }

            return destination;
        }


    }
}
