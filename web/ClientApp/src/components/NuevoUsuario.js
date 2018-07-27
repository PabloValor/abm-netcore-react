import React, { Component } from 'react';
import { LinkContainer } from 'react-router-bootstrap';

export class NuevoUsuario extends Component {

  constructor(props) {
    super(props)
    this.state = { usuario: {
        idPuesto: 1,
        foto: '',
        nombre: '',
        apellido: ''
      }
    }

    this.submit = this.submit.bind(this)
    this.handleChange = this.handleChange.bind(this)

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

    fetch('api/usuarios/guardar', {
      method: 'post',
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

  static renderPuestos(puestos) {
    return (
      puestos.map(puesto => <option key={puesto.idPuesto} value={puesto.idPuesto}>{puesto.descripcion}</option> )
    )
  }

  render() {
    return (
      <div>
        <h1>Nuevo usuario</h1>

        <form onSubmit={ this.submit }>
          <div className="row">
            <div className="col-sm-12 col-md-3">
              <label htmlFor="nombre">Nombre</label>
              <input id="nombre" type="text" name="nombre" onChange={this.handleChange}/>
            </div>
            <div className="col-sm-12 col-md-3">
              <label htmlFor="apellido">Apellido</label>
              <input id="apellido" type="text" name="apellido" onChange={this.handleChange}/>
            </div>
            <div className="col-sm-12 col-md-6">
              <label htmlFor="foto">Url Foto</label>
              <input id="foto" type="text" name="foto" onChange={this.handleChange}/>
            </div>
            <div className="col-sm-12 col-md-6">
              <p>
                <select name="idPuesto" onChange={this.handleChange}>
                  {this.state.puestosCargados ? NuevoUsuario.renderPuestos(this.state.puestos) :  <option>Cargando...</option>}
                </select>
              </p>
            </div>
          </div>
          <div className="row">
            <div className="col-sm-12">
              <button className="btn btn-warning" type="submit">Nuevo Usuario</button>
            </div>
          </div>
        </form>

        <div className="row">
          <div className="col-sm-12 col-md-6">
            <LinkContainer to={'/usuarios'}>
              <a className="btn btn-primary">Volver</a>
            </LinkContainer>
          </div>
        </div>
      </div>
    );
  }
}
