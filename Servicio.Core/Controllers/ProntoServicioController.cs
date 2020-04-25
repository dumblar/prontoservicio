using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio.Core.Models;
using Servicio.Core.Services;

namespace Servicio.Core.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProntoServicioController : ControllerBase
    {
        private readonly ProntoServicio _prontoService;
        public ProntoServicioController(ProntoServicio serv)
        {
            _prontoService = serv;
        }


        [HttpGet]
        [Route("usuarios/iniciarSesion/{usuario}/{contrasena}")]
        public ActionResult IniciarSesion(string usuario, string contrasena)
        {
            TblUsuarios usu = _prontoService.IniciarSesion(usuario, contrasena);
            return Ok(usu);
        }
        [HttpPost]
        [Route("solicitudes/guardar/{diaCita}/{mesCita}/{anoCita}/{horaCita}/{minCita}/{horaRecoger}/{minRecoger}")]
        public bool solicitudGuardar([FromBody] TblSolicitudesTO objSolicitud, string diaCita, string mesCita, string anoCita, string horaCita, string minCita, string horaRecoger, string minRecoger)
        {
            objSolicitud.Solicitud.FechaCita = new DateTime(int.Parse(anoCita), int.Parse(mesCita) + 1, int.Parse(diaCita), int.Parse(horaCita), int.Parse(minCita), 0);

            //DateTime utcTime = DateTime.UtcNow.;
            //TimeZoneInfo serverZone = TimeZoneInfo.FindSystemTimeZoneById();
            //DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, serverZone);

            DateTime fechaYa = DateTime.UtcNow.AddHours(-5);
            objSolicitud.Solicitud.FechaRecoger = new DateTime(fechaYa.Year, fechaYa.Month, fechaYa.Day, int.Parse(horaRecoger), int.Parse(minRecoger), 0);

            _prontoService.SetSolicitudes(objSolicitud);
            return true;
        }

        [HttpGet]
        [Route("solicitudes/caracteristicas/{id_company}")]
        public ActionResult GetCaracteristicas(string id_company)
        {
            return Ok(_prontoService.GetCaracteristicas(int.Parse(id_company)));
        }

        [HttpGet]
        [Route("terceros/consultar/{tipo}/{id_company}")]
        public ActionResult GetTerceros(string tipo, string id_company)
        {
            return Ok(_prontoService.GetTerceros((TipoTercero)int.Parse(tipo), int.Parse(id_company)));
        }

        [HttpGet]
        [Route("solicitudes/consultar/{usuario}/{diaI}/{mesI}/{anoI}/{diaF}/{mesF}/{anoF}/{editando}/{id_company}")]
        public ActionResult GetSolicitudes(string usuario, string diaI, string mesI, string anoI, string diaF, string mesF, string anoF, string editando, string id_company)
        {
            try
            {
                bool editandin = editando == "true" ? true : false;
                DateTime fechaInicio = DateTime.UtcNow.AddHours(-5);
                DateTime fechaFin = DateTime.UtcNow.AddHours(-5);
                if (!editandin)
                {
                    fechaInicio = new DateTime(int.Parse(anoI), int.Parse(mesI) + 1, int.Parse(diaI));
                    fechaFin = new DateTime(int.Parse(anoF), int.Parse(mesF) + 1, int.Parse(diaF));
                }

                return Ok(_prontoService.GetSolicitudes(usuario, fechaInicio, fechaFin, editandin, int.Parse(id_company)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("moviles/consultar/{id_company}")]
        public ActionResult movilesConsutlar(string id_company)
        {
            return Ok(_prontoService.GetMoviles(int.Parse(id_company)));
        }

        //[HttpPost]
        //[Route("solicitudes/ooee")]
        //public bool prueba()
        //{
        //    string trin = HttpContext.Request.ToString();


        //    return true;
        //}
        //[HttpGet]
        //[Route("tiposEventos/consultar")]
        //public ActionResult tiposEventosConsutlar()
        //{
        //    return Ok(_prontoService.GetTiposEventos());
        //}

    }
}