using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using dominio;
using dominio.abstracciones.aplicacion;
using aplicacion.servicios;
using dominio.abstracciones.infraestructura;
using infraestructura.repositorios;
using infraestructura.mappers.abstracciones;
using infraestructura.mappers;

namespace ioc
{
    public class Bindings
    {
        private IServiceCollection _services;
        public Bindings(IServiceCollection services)
        {
            _services = services;
        }

        public void Crear()
        {
            _services.AddTransient<IUsuarioServicio, UsuarioServicio>();
            _services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();

            #region Mappers

            _services.AddTransient<IUsuariosMapper, UsuariosMapper>();
            
            #endregion 
        }
    }
}