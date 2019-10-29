import React, { Component } from 'react';

export class GetCoord extends Component {
    constructor(props) {
        super(props);
    }

    
    render() {
        return (
            <div className="col-5 py-2 border rounded bg-light">
                <p>Coordinates for: {this.props.coords.location}</p>
                <div className="form-group">
                    <label className="col-form-label">Latitude</label>
                    <div className="input-group mb-3">
                        <input type="text" value={this.props.coords.latitude} id="LatData"  className="form-control lat-data" readOnly />
                    </div>
                </div>
                    <div className="form-group">
                    <label className="col-form-label">Longitude</label>
                    <div className="input-group mb-3">
                        <input type="text" value={this.props.coords.longitude} id = "LonData" className="form-control lon-data" readOnly />
                        </div>
                    </div>
            </div>

            );
    }
}