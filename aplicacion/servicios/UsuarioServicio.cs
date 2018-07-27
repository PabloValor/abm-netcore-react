using System;
using System.Collections.Generic;
using System.Linq;
using dominio;
using dominio.abstracciones.aplicacion;
using dominio.abstracciones.infraestructura;
using dominio.entidades;

namespace aplicacion.servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServicio(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public RespuestaApi<List<Usuario>> Obtener()
        {
            try
            {
                return new RespuestaApi<List<Usuario>>
                {
                    Valor = _usuarioRepositorio.Obtener(),
                    Exito = true
                };
            }
            catch(Exception)
            {
                return new RespuestaApi<List<Usuario>>
                {
                    Exito = false,
                    Mensaje = "Ocurrió un error al intentar obtener los usuarios"
                };
            }
        }

        public RespuestaApi<Usuario> Obtener(int idUsuario)
        {
            try
            {
                return new RespuestaApi<Usuario>
                {
                    Valor = _usuarioRepositorio.Obtener(idUsuario),
                    Exito = true
                };
            }
            catch(Exception)
            {
                return new RespuestaApi<Usuario>
                {
                    Exito = false,
                    Mensaje = "Ocurrió un error al intentar obtener el usuario"
                };
            }
        }

        public RespuestaApi<Usuario> Guardar(Usuario usuario)
        {
            try
            {
                _usuarioRepositorio.Guardar(usuario);

                return new RespuestaApi<Usuario>
                { 
                    Exito = true, 
                    Mensaje = "Usuario guardado"
                };
            }
            catch(Exception)
            {
                return new RespuestaApi<Usuario>
                { 
                    Exito = false, 
                    Mensaje = "Error: no se pudo guardar el usuario" 
                };
            }
        }

        public RespuestaApi<Usuario> Actualizar(Usuario usuario)
        {
            try
            {
                return new RespuestaApi<Usuario>
                { 
                    Exito = true, 
                    Mensaje = "Usuario actualizado",
                    Valor = _usuarioRepositorio.Actualizar(usuario)
                };

            }
            catch(Exception)
            {
                return new RespuestaApi<Usuario>
                { 
                    Exito = false,
                    Mensaje = "Error: el usuario no ha podido ser actualizado",
                };
            }
        }

        public RespuestaApi<Usuario> Eliminar(int idUsuario)
        {
            try
            {
                return new RespuestaApi<Usuario>
                {
                    Exito = true,
                    Mensaje = "Usuario eliminado",
                    Valor = _usuarioRepositorio.EliminarPorId(idUsuario)
                };

            }
            catch(Exception e)
            {
                return new RespuestaApi<Usuario>
                {
                    Exito = false,
                    Mensaje = e.Message
                };
            }
        }
        public RespuestaApi<List<Puesto>> ObtenerPuestos()
        {
            try
            {
                return new RespuestaApi<List<Puesto>>
                {
                    Exito = true,
                    Valor = _usuarioRepositorio.ObtenerPuestos()
                };
            }
            catch(Exception)
            {
                return new RespuestaApi<List<Puesto>>
                {
                    Exito = false,
                    Mensaje = "Error. No se pudo obtener los puestos"
                };
            }
        }
    }
}