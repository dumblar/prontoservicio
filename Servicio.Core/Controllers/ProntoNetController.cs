using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio.Core.Services;

namespace Servicio.Core.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProntoNetController : ControllerBase
    {
        private readonly ProntoNetServicio _prontoNetService;

        public ProntoNetController(ProntoNetServicio pronto)
        {
            _prontoNetService = pronto;
        }
        
        [AllowAnonymous]
        [HttpPost]
        [Route("iniciarsesion")]
        public ActionResult iniciarSesion([FromBody] LoginVM loginVM)
        {
            var user = _prontoNetService.IniciarSesion(loginVM.Email, loginVM.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }


        public class LoginVM
        {
            [Required]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
        }

      
    }
}