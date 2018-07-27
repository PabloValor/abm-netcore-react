using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using System.Linq;
using dominio;
using dominio.entidades;
using dominio.abstracciones.aplicacion;
using aplicacion.servicios;
using dominio.abstracciones.infraestructura;
using infraestructura;

namespace tests.servicios
{
    public class UsuariosServiciosTests
    {

        [Fact]
        public void DebeObtenerUnListadoDeUsuarios()
        {
            // Arrange
            var _usuariosRepositorio = new Mock<IUsuarioRepositorio>();
            IUsuarioServicio _usuarioServicio = new UsuarioServicio(_usuariosRepositorio.Object);
            _usuariosRepositorio.Setup(x => x.Obtener()).Returns(ListaUsuariosMocks());
            

            // Act
            var respuesta = _usuarioServicio.Obtener();

            // Assert
            _usuariosRepositorio.Verify(x => x.Obtener(), Times.Once);
            Assert.True(respuesta.Valor.Count() == 2);
            Assert.True(respuesta.Exito);
        }

        [Fact]
        public void DebeMostarMensajeDeErrorCuandoSeLanzaUnaExcepcion()
        {
            // Arrange
            var _usuariosRepositorio = new Mock<IUsuarioRepositorio>();
            IUsuarioServicio _usuarioServicio = new UsuarioServicio(_usuariosRepositorio.Object);
            _usuariosRepositorio.Setup(x => x.Obtener()).Throws(new Exception());
            const string mensajeErrorEsperado = "Ocurrió un error al intentar obtener los usuarios";

            // Act
            var respuesta = _usuarioServicio.Obtener();

            // Assert
            _usuariosRepositorio.Verify(x => x.Obtener(), Times.Once);
            Assert.Equal(mensajeErrorEsperado, respuesta.Mensaje);
            Assert.False(respuesta.Exito);
        }

        [Fact]
        public void DebePoderObtenerTodosLosPuestos()
        {
            // Arrange
            var _usuariosRepositorio = new Mock<IUsuarioRepositorio>();
            IUsuarioServicio _usuarioServicio = new UsuarioServicio(_usuariosRepositorio.Object);
            _usuariosRepositorio.Setup(x => x.ObtenerPuestos()).Returns(PuestosMock());

            // Act
            var respuesta = _usuarioServicio.ObtenerPuestos();

            Assert.True(respuesta.Valor.Count() == 2);
            _usuariosRepositorio.Verify(x => x.ObtenerPuestos(), Times.Once);
        }

        private List<Usuario> ListaUsuariosMocks()
        {
            return new List<Usuario>
                {
                    new Usuario
                    {
                        IdUsuario = 1,
                        Nombre = "Juan",
                        Apellido = "Test",
                        Puesto = new Puesto {
                            IdPuesto = 1,
                            Descripcion = "Progrador"
                        }
                    },
                    new Usuario
                    {
                        IdUsuario = 2,
                        Nombre = "Pepe",
                        Apellido = "Jerez",
                        Puesto = new Puesto {
                            IdPuesto = 2,
                            Descripcion = "Médico"
                        }
                    }
                };
        }

        private List<Puesto> PuestosMock()
        {
            return new List<Puesto>
            {
                new Puesto 
                {
                    IdPuesto = 1,
                    Descripcion = "programador"
                },
                new Puesto 
                {
                    IdPuesto = 2,
                    Descripcion = "técnico"
                }
            };
        }
    }
}