import React, { Component } from "react";

export class FetchRandomUser extends Component {

    constructor(props) {
        super(props);
        this.state = { person: null, loading: true };
    }

    async componentDidMount() {
        const url = "https://api.randomuser.me/";  //const url = "https://www.metaweather.com/api/location/2487956/";
        const response = await fetch(url);
        const data = await response.json();
        this.setState({
            person: data.results[0],
            loading: false,
        });
        //console.log(data);

    }

    render() {
        return (
            <>
                <h2>Fetch Random User From Web API</h2>
                <p>https://api.randomuser.me</p>
                <div>
                    {this.state.loading ? (<div>loading...</div>
                    ) : (
                        <>
                            <div>{this.state.person.name.first}</div>
                            <div>{this.state.person.name.last}</div>
                            <div>{this.state.person.registered.age}</div>
                            <img src={this.state.person.picture.large} />
                        </>
                    )}
                </div>
            </>
        );
    }
}
