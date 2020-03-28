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
    [Route("api/[controller]")]
    [ApiController]
    public class ProntoServicioController : ControllerBase
    {
        private readonly ProntoServicio _prontoService;
        public ProntoServicioController(ProntoServicio serv)
        {
            _prontoService = serv;
        }

        [HttpGet]
        [Route("iniciarsesion/{usuario}/{contrasena}")]
        public ActionResult IniciarSesion(string usuario, string contrasena)
        {
            TblUsuarios usu = _prontoService.IniciarSesion(usuario, contrasena);
            return Ok(usu);
        }
    }
}