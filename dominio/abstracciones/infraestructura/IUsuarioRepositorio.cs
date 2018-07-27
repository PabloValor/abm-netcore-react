using System.Collections.Generic;
using dominio.entidades;

namespace dominio.abstracciones.infraestructura
{
    public interface IUsuarioRepositorio
    {
        List<Usuario> Obtener();
        Usuario Obtener(int idUsuario);
        Usuario EliminarPorId(int idUsuario);
        Usuario Actualizar(Usuario usuario);
        void Guardar(Usuario usuario);
        List<Puesto> ObtenerPuestos();
    }
}