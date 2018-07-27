import React, { Component } from 'react';
import { LinkContainer } from 'react-router-bootstrap';

export class UsuarioDetalle extends Component {

  constructor(props) {
    super(props)
    this.state = { usuario: {}, cargando: true, puestosCargados: false, puestos: [] }

    this.submit = this.submit.bind(this)
    this.eliminarUsuario = this.eliminarUsuario.bind(this)
    this.handleChange = this.handleChange.bind(this)

    fetch(`api/usuarios/obtener/${this.props.match.params.idUsuario}`)
      .then(respuesta => respuesta.json())
      .then(data => {
        this.setState({ usuario: data.valor, cargando: false })
      })

    fetch('api/usuarios/obtener/puestos')
      .then(respuesta => respuesta.json())
      .then(data => {
        this.setState({ puestos: data.valor, puestosCargados: true })
      })
  }

  handleChange(e) {
    let tempUsuario = this.state.usuario
    tempUsuario[e.target.name] = e.target.value

    this.setState({usuario: tempUsuario})
  }

  submit(e) {
    e.preventDefault()

    fetch('api/usuarios/actualizar', {
      method: 'put',
      body: JSON.stringify(this.state.usuario),
      headers:{
        'Content-Type': 'application/json'
      }
    })
    .then(respuesta => respuesta.json())
    .then(respuesta => {
      if(respuesta.exito) {
        window.location.href = "/usuarios"
      } else {
        alert(respuesta.mensaje)
      }
    })
  }

  eliminarUsuario(e) {
    e.preventDefault()
    fetch(`api/usuarios/eliminar/${this.state.usuario.idUsuario}`, {
      method: 'delete'
    })
    .then(respuesta => respuesta.json())
    .then(respuesta => {
      if(respuesta.exito) {
        window.location.href = "/usuarios"
      } else {
        alert(respuesta.mensaje)
      }
    })
  }

  static renderPuestos(puestos) {
    return (
      puestos.map(puesto => <option key={puesto.idPuesto} value={puesto.idPuesto}>{puesto.descripcion}</option> )
    )
  }

  render() {
    return (
      <div>
        <h1>{this.state.usuario.nombre} {this.state.usuario.apellido}</h1>

        <form onSubmit={ this.submit }>
          <div className="row">
            <div className="col-sm-12 col-md-3">
              <label htmlFor="idUsuario">Id Usuario {this.state.usuario.idUsuario}</label>
              <input id="idUsuario" type="text" onChange={() => {}} value={this.state.usuario.idUsuario} disabled/>
            </div>
            <div className="col-sm-12 col-md-3">
              <label htmlFor="nombre">Nombre</label>
              <input id="nombre" type="text" name="nombre" onChange={this.handleChange} value={this.state.usuario.nombre}/>
            </div>
            <div className="col-sm-12 col-md-3">
              <label htmlFor="apellido">Apellido</label>
              <input id="apellido" type="text" name="apellido" onChange={this.handleChange} value={this.state.usuario.apellido}/>
            </div>
            <div className="col-sm-12 col-md-6">
              <p><img src={this.state.usuario.foto}/></p>
              <label htmlFor="foto">Url Foto</label>
              <input id="foto" type="text" name="foto" onChange={this.handleChange} value={this.state.usuario.foto}/>
            </div>
            <div className="col-sm-12 col-md-6">
              <p>
                <select value={this.state.usuario.idPuesto} name="idPuesto" onChange={this.handleChange}>
                  {this.state.puestosCargados ? UsuarioDetalle.renderPuestos(this.state.puestos) :  <option>Cargando...</option>}
                </select>
              </p>
            </div>
          </div>
          <div className="row">
            <div className="col-sm-12">
              <button className="btn btn-warning" type="submit">Modificar Usuario</button>
            </div>
          </div>
        </form>

        <div className="row">
          <div className="col-sm-12 col-md-6">
            <LinkContainer to={'/usuarios'}>
              <a className="btn btn-primary">Volver</a>
            </LinkContainer>
          </div>
          <div className="col-sm-12 col-md-6">
              <button className="btn btn-danger" onClick={this.eliminarUsuario}>Eliminar</button>
            </div>
        </div>
      </div>
    );
  }
}
