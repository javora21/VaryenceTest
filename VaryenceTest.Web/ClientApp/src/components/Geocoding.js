import React, { Component } from 'react';
import { PlaceSearch } from './PlaceSearch';
import { GetCoord } from './GetCoord';

export class Geocoding extends Component {

    constructor(props) {
        super(props);
        this.state = { coords: [] };

        this.getCoordData = this.getCoordData.bind(this);
    }

    getCoordData(placeData) {
        var data = JSON.stringify({ "Place": placeData.place, "City": placeData.city });
        var xhr = new XMLHttpRequest();
        xhr.open("post", this.props.apiUrl, true);
        xhr.setRequestHeader("Content-type", "application/json");
        xhr.onload = function () {
            if (xhr.status == 200) {
                var data = JSON.parse(xhr.responseText);
                this.setState({ coords: data });
            }
        }.bind(this);
        xhr.send(data);
        
    }
    render() {
        return (
            <div className="container">
                <div className="row my-3  justify-content-around">
                    <PlaceSearch PlaceData={this.getCoordData} />
                    <GetCoord coords={this.state.coords} />
                </div>
            </div>
            );
    }
}
