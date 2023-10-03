import React, { Component } from 'react'
import { Route, Routes } from 'react-router-dom'
import { CustomerLayout } from './components/layout/CustomerLayout'
import { CustomerPrivateRoutes, CustomerPublicRoutes } from './routes'
import LoggedInRoute from './components/customRoute/LoggedInRoute'
import { Login } from './pages/customer/auth/Login'
import CustomerPageNotFound from './pages/404/CustomerPageNotFound'
import { Register } from './pages/customer/auth/Register'
import CustomToastContainer from './components/toast/CustomToastContainer'
import './styles/custom.scss'

export default class App extends Component {
    render() {
        return (
            <>
                <Routes>
                    <Route path='/login' element={<Login />} />
                    <Route path='/register' element={<Register />} />

                    <Route path='/' element={<CustomerLayout />}>
                        {/* Public customer routes */}
                        {CustomerPublicRoutes.map((route, index) => {
                            const { element, ...rest } = route
                            return <Route key={index} {...rest} element={element} />
                        })}
                        {/* Private customer routes */}
                        <Route element={<LoggedInRoute />}>
                            {CustomerPrivateRoutes.map((route, index) => {
                                const { element, ...rest } = route
                                return <Route key={index} {...rest} element={element} />
                            })}
                        </Route>
                        <Route path='*' element={<CustomerPageNotFound />} />
                    </Route>
                </Routes>
                <CustomToastContainer />
            </>
        )
    }
}
