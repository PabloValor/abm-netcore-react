import React, { Component } from 'react';
import { LinkContainer } from 'react-router-bootstrap';

export class Usuarios extends Component {

  constructor(props) {
    super(props);
    this.state = { usuarios: [], cargando: true }

    fetch('api/usuarios/obtener')
      .then(respuesta => respuesta.json())
      .then(data => {
        this.setState({ usuarios: data.valor, cargando: false })
      })
  }
  

  static cargarTabla(usuarios) {
    return (
      <table className='table'>
        <thead>
          <tr>
            <th>Id Usuario</th>
            <th>Nombre</th>
            <th>Apellido</th>
            <th>Puesto</th>
            <th>Foto</th>
            <th>Acción</th>
          </tr>
        </thead>
        <tbody>
          {usuarios.map(u =>
            <tr key={u.idUsuario}>
                <td>{u.idUsuario}</td>
                <td>{u.nombre}</td>
                <td>{u.apellido}</td>
                <td>{u.puesto.descripcion}</td>
                <td><img src={u.foto}/></td>
                <td>
                    <LinkContainer to={`/usuario/editar/${u.idUsuario}`}>
                      <a>Editar</a>
                    </LinkContainer>
                </td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.cargando
      ? <p><em>Loading...</em></p>
      : Usuarios.cargarTabla(this.state.usuarios);

    return (
      <div>
        <h1>Listado de Usuarios</h1>
        {contents}
        <LinkContainer to={'/usuario/nuevo'}>
          <a className="btn btn-success">Nuevo</a>
        </LinkContainer>
      </div>
    );
  }
}
