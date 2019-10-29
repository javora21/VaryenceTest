import React, { Component } from 'react';
import { Geocoding } from './components/Geocoding';


export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <Geocoding apiUrl = "/Geocoding/GetCoordinates" />
    );
  }
}
