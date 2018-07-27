using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dominio.abstracciones.infraestructura;
using dominio.entidades;
using dominio.abstracciones.aplicacion;

namespace web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IUsuarioServicio _usuarioServicio;

        public UsuariosController(IUsuarioRepositorio usuarioRepositorio, IUsuarioServicio usuarioServicio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _usuarioServicio = usuarioServicio;
        }

        [Route("obtener")]
        [HttpGet]
        public JsonResult Obtener()
        {
            return Json(_usuarioServicio.Obtener());
        }

        [Route("obtener/{idUsuario:int}")]
        [HttpGet]
        public JsonResult Obtener(int idUsuario)
        {
            return Json(_usuarioServicio.Obtener(idUsuario));
        }

        [Route("guardar")]
        [HttpPost]
        public JsonResult Guardar([FromBody] Usuario usuario)
        {
            return Json(_usuarioServicio.Guardar(usuario));
        }

        [Route("actualizar")]
        [HttpPut]
        public JsonResult Actualizar([FromBody] Usuario usuario)
        {
            return Json(_usuarioServicio.Actualizar(usuario));
        }

        [Route("eliminar/{idUsuario:int}")]
        [HttpDelete]
        public JsonResult Eliminar(int idUsuario)
        {
            return Json(_usuarioServicio.Eliminar(idUsuario));
        }

        [Route("obtener/puestos")]
        public JsonResult ObtenerPuestos()
        {
            return Json(_usuarioServicio.ObtenerPuestos());
        }
    }
}
