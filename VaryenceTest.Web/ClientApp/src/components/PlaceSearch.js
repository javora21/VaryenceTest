import React, { Component } from 'react';

export class PlaceSearch extends Component {

    constructor(props) {
        super(props);
        this.state = { place: "", city: "", placeVal: true };

        this.onSubmit = this.onSubmit.bind(this);
        this.onPlaceChange = this.onPlaceChange.bind(this);
        this.onCityChange = this.onCityChange.bind(this);
    }
    onSubmit(e) {
        e.preventDefault();
        var Place = this.state.place;
        var City = this.state.city;
        if (this.state.place.length>1) {

            this.props.PlaceData({ place: Place, city: City });
            this.setState({ place: "" });
            this.setState({ city: "" });
            this.setState({ placeVal: true });
        }
        else
            this.setState({ placeVal: false })
    }
    onPlaceChange(e) {
        this.setState({ place: e.target.value });
    }
    onCityChange(e) {
        this.setState({ city: e.target.value });
    }
    render() {
        var bordCol = this.state.placeVal === true ? "grey" : "red";
        return (
            <div className="col-5 py-2 border rounded align-self-center bg-light">
                <form onSubmit={this.onSubmit}>
                    <div className="form-row">
                        <div className="form-group col-md-8">
                            <label className="col-form-label">Place:</label>
                            <input type="text" className="form-control" style={{ borderColor: bordCol }} id="search-place" value={this.state.place} onChange={this.onPlaceChange} />
                        </div>
                        <div className="form-group col-md-4">
                            <label className="col-form-label">City (optional):</label>
                            <input type="text" className="form-control" id="search-place" value={this.state.city} onChange={this.onCityChange} />
                        </div>
                    </div>
                    <button type="submit" className="btn btn-primary">Search</button>
                </form>
            </div>
            );
    }
}
