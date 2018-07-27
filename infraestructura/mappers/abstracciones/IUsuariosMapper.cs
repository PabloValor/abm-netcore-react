using System.Linq;

namespace infraestructura.mappers.abstracciones
{
    public interface IUsuariosMapper
    {
        dominio.entidades.Usuario MappearUsuario(infraestructura.entidades.Usuario usuario);
        infraestructura.entidades.Usuario MappearUsuario(dominio.entidades.Usuario usuario);
        dominio.entidades.Puesto MapearPuesto(infraestructura.entidades.Puesto puesto);
    }
}