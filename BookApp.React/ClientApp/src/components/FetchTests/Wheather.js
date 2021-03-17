import React, { Component } from 'react';

export class Wheather extends Component {
    static displayName = Wheather.name;

    constructor(props) {
        super(props);
        this.state = {
            wheather: null,
            loading: true,
        };

        this.renderWheatherTable = this.renderWheatherTable.bind(this);
    }

    async componentDidMount() {
        const lat = 37.557121;
        const lng = 126.977379; // Seoul
        const params = 'windSpeed';

        //this.populateSeoulData();
        this.populateCurrentSeoulWheatherData();
    }

    async populateCurrentSeoulWheatherData() {

        const key = "0422e44ad5b5b4b447047ca5d69ddb15";
        //const url = "https://api.randomuser.me/";  //const url = "https://www.metaweather.com/api/location/2487956/";
        const url = `http://api.weatherstack.com/current?access_key=${key}&query=Seoul`;
        const response = await fetch(url);
        const data = await response.json();
        this.setState({
            wheather: data,
            loading: false,
        });

    }


    renderWheatherTable(wheather) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp.</th>
                        <th>Humidity</th>
                        <th>Summary</th>
                        <th>Summary</th>
                    </tr>
                </thead>
                <tbody>
                    <tr key={wheather.location.localtime}>
                        <td>{wheather.location.localtime}</td>
                        <td>{wheather.current.temperature}</td>
                        <td>{wheather.current.humidity}</td>
                        <td>{wheather.current.weather_descriptions}</td>
                        <img src={wheather.current.weather_icons} />
                    </tr>
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderWheatherTable(this.state.wheather)
        //let contents = this.state.loading
        //    ? <p><em>Loading...</em></p>
        //    : this.renderForecastsTable(this.state.forecasts);


        return (
            <div>
                <h1 id="tabelLabel" >Current weather of Seoul (only HTTP)</h1>
                <p>This component fetch data (current wheather of Seoul city) from the API.</p>
                <p>http://api.weatherstack.com/current?access_key=0422e44ad5b5b4b447047ca5d69ddb15&query=Seoul</p>
                <p></p>
                {contents}
            </div>
        );
    }
    
}
