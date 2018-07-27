using System.Collections.Generic;
using dominio.entidades;

namespace dominio.abstracciones.aplicacion
{
    public interface IUsuarioServicio
    {
        RespuestaApi<List<Usuario>> Obtener();
        RespuestaApi<Usuario> Obtener(int idUsuario);
        RespuestaApi<Usuario> Guardar(Usuario usuario);
        RespuestaApi<Usuario> Actualizar(Usuario usuario);
        RespuestaApi<Usuario> Eliminar(int idUsuario);
        RespuestaApi<List<Puesto>> ObtenerPuestos();
    }
}