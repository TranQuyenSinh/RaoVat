import React, { Component } from 'react'
import { Route, Routes } from 'react-router-dom'
import { CustomerLayout } from './components/layout/CustomerLayout'
import { SystemLayout } from './components/layout/SystemLayout'
import { CustomerRoutes, SystemRoutes } from './routes'
import './styles/custom.scss'
import CustomerPageNotFound from './pages/404/CustomerPageNotFound'
import SystemPageNotFound from './pages/404/SystemPageNotFound'

export default class App extends Component {
    render() {
        return (
            <Routes>
                <Route path='/' element={<CustomerLayout />}>
                    {CustomerRoutes.map((route, index) => {
                        const { element, ...rest } = route
                        return <Route key={index} {...rest} element={element} />
                    })}
                    <Route path='*' element={<CustomerPageNotFound />} />
                </Route>
                <Route path='system' element={<SystemLayout />}>
                    {SystemRoutes.map((route, index) => {
                        const { element, ...rest } = route
                        return <Route key={index} {...rest} element={element} />
                    })}
                    <Route path='*' element={<SystemPageNotFound />} />
                </Route>
            </Routes>
        )
    }
}
