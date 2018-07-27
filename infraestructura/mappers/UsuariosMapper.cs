using dominio.entidades;
using infraestructura.entidades;
using infraestructura.mappers.abstracciones;

namespace infraestructura.mappers
{
    public class UsuariosMapper : IUsuariosMapper
    {
        public dominio.entidades.Usuario MappearUsuario(infraestructura.entidades.Usuario usuario)
         {
             return new dominio.entidades.Usuario
             {
                 IdUsuario = usuario.IdUsuario,
                 Nombre = usuario.Nombre,
                 Apellido = usuario.Apellido,
                 Foto = usuario.Foto,
                 IdPuesto = usuario.IdPuesto,
                 Puesto = new dominio.entidades.Puesto {
                     IdPuesto = usuario.Puesto.IdPuesto,
                     Descripcion = usuario.Puesto.Descripcion
                 }
                 
             };
         }

        public entidades.Usuario MappearUsuario(dominio.entidades.Usuario usuario)
        {
            return new entidades.Usuario 
            {
                 IdUsuario = usuario.IdUsuario,
                 Nombre = usuario.Nombre,
                 Apellido = usuario.Apellido,
                 Foto = usuario.Foto,
                 IdPuesto = usuario.IdPuesto
            };
        }

        public dominio.entidades.Puesto MapearPuesto(entidades.Puesto puesto)
        {
            return new dominio.entidades.Puesto {
                IdPuesto = puesto.IdPuesto,
                Descripcion = puesto.Descripcion
            };
        }

    }
}