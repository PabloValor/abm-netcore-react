using System;
using System.Collections.Generic;
using System.Linq;
using dominio.abstracciones.infraestructura;
using dominio.entidades;
using infraestructura.mappers.abstracciones;
using Microsoft.EntityFrameworkCore;

namespace infraestructura.repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly Contexto _contexto;
        private readonly IUsuariosMapper _usuariosMapper;

        public UsuarioRepositorio (Contexto contexto, IUsuariosMapper usuariosMapper)
        {
            _contexto = contexto;
            _usuariosMapper = usuariosMapper;
        }
        public Usuario Actualizar(Usuario usuario)
        {
            var entidad = _contexto.Usuario
            .FirstOrDefault(x => x.IdUsuario == usuario.IdUsuario);

            if(entidad == null)
            {
                throw new Exception("Error: no se pudo actualizar el usuario porque no existe en el sistema");
            }

            _contexto.Entry(entidad).CurrentValues.SetValues(usuario);
            _contexto.SaveChanges();
            return usuario;
        }

        public Usuario EliminarPorId(int idUsuario)
        {
            var usuario = _contexto.Usuario
                .Include(x => x.Puesto)
                .FirstOrDefault(u => u.IdUsuario == idUsuario);

            if(usuario == null )
            {
                throw new Exception("Error: no se pudo eliminar el usuario porque no existe en el sistema");
            }
            
            _contexto.Usuario.Remove(usuario);
            _contexto.SaveChanges();

            return _usuariosMapper.MappearUsuario(usuario);
        }

        public void Guardar(Usuario usuario)
        {
            var usuarioGuardado =  _contexto.Usuario.Add(_usuariosMapper.MappearUsuario(usuario));
            _contexto.SaveChanges();
        }

        public List<Usuario> Obtener()
        {
            return _contexto.Usuario
                    .Include(x => x.Puesto)
                    .Select(_usuariosMapper.MappearUsuario).ToList();
        }

        public Usuario Obtener(int idUsuario)
        {
            var usuario = _contexto.Usuario
                                .Include(x => x.Puesto)
                                .First(x => x.IdUsuario == idUsuario);

             return _usuariosMapper.MappearUsuario(usuario);
        }

        public List<Puesto> ObtenerPuestos()
        {
            return _contexto.Puesto
                    .Select(_usuariosMapper.MapearPuesto)
                    .ToList();
        }
    }
}