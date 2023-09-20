import React, { Component } from 'react'

export class FetchData extends Component {
    static displayName = FetchData.name

    constructor(props) {
        super(props)
        this.state = { forecasts: [], loading: true }
    }

    componentDidMount() {
        this.populateWeatherData()
    }

    render() {
        return (
            <div>
                <h1 id='tableLabel'>Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
            </div>
        )
    }

    async populateWeatherData() {
        const response = await fetch('https://localhost:8080/test/checkdb')
        const data = await response.json()
        console.log(data)
        this.setState({ forecasts: data, loading: false })
    }
}
