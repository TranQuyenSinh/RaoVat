import React, { Component } from 'react'
import { Route, Routes } from 'react-router-dom'
import { CustomerLayout } from './components/Layout/CustomerLayout'
import { SystemLayout } from './components/Layout/SystemLayout'
import { CustomerRoutes, SystemRoutes } from './routes'
import './styles/custom.scss'

export default class App extends Component {
    render() {
        return (
            <Routes>
                <Route path='/' element={<CustomerLayout />}>
                    {CustomerRoutes.map((route, index) => {
                        const { element, ...rest } = route
                        return <Route key={index} {...rest} element={element} />
                    })}
                </Route>
                <Route path='system' element={<SystemLayout />}>
                    {SystemRoutes.map((route, index) => {
                        const { element, ...rest } = route
                        return <Route key={index} {...rest} element={element} />
                    })}
                </Route>
            </Routes>
        )
    }
}
