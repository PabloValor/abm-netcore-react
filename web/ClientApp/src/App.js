import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Usuarios } from './components/Usuarios';
import { UsuarioDetalle } from './components/UsuarioDetalle';
import { NuevoUsuario } from './components/NuevoUsuario';


export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/usuarios' component={Usuarios} />
        <Route path='/usuario/editar/:idUsuario' component={UsuarioDetalle} />
        <Route path='/usuario/nuevo' component={NuevoUsuario} />
      </Layout>
    );
  }
}
