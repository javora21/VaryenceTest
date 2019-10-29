import React, { Component } from 'react';

export class GetCoord extends Component {
    constructor(props) {
        super(props);
        this.copyData = this.copyData.bind(this);
    }

    copyData(e) {
        var elem;
        if (e.target.id == "LatCopy") {
            elem = document.getElementById("LatData");
        }
        else {
            elem = document.getElementById("LonData");
        }
        var range = document.createRange();
        range.selectNode(elem);
        window.getSelection().addRange(range);
        document.execCommand('copy');
        window.getSelection().removeRange(range);
    }
    render() {
        return (
            <div className="col-5 py-2 border rounded bg-light">
                <p>Coordinates for: {this.props.coords.location}</p>
                <div className="form-group">
                    <label className="col-form-label">Latitude</label>
                    <div className="input-group mb-3">
                        <input type="text" value={this.props.coords.latitude} id="LatData"  className="form-control lat-data" readOnly />
                            <div class="input-group-append">
                            <button className="btn btn-outline-secondary" id="LatCopy" onClick={this.copyData} type="button">Copy</button>
                            </div>
                    </div>
                </div>
                    <div className="form-group">
                    <label className="col-form-label">Longitude</label>
                    <div className="input-group mb-3">
                        <input type="text" value={this.props.coords.longitude} id = "LonData" className="form-control lon-data" readOnly />
                        <div className="input-group-append">
                            <button className="btn btn-outline-secondary" id = "LonCopy" onClick={this.copyData} type="button">Copy</button>
                                </div>
                        </div>
                    </div>
            </div>

            );
    }
}