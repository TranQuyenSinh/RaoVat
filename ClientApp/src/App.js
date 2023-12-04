import React from 'react'
import { Route, Routes } from 'react-router-dom'
import { CustomerLayout } from './components/layout/CustomerLayout'
import { CustomerPrivateRoutes, CustomerPublicRoutes, SystemPrivateRoutes, SystemPublicRoutes } from './routes'
import LoggedInRoute from './components/customRoute/LoggedInRoute'
import { Login } from './pages/customer/auth/Login'
import CustomerPageNotFound from './pages/404/CustomerPageNotFound'
import { Register } from './pages/customer/auth/Register'
import CustomToastContainer from './components/toast/CustomToastContainer'
import './styles/custom.scss'
import { SystemLayout } from './components/layout/SystemLayout'
import SystemPageNotFound from '@pages/404/SystemPageNotFound'

const App = () => {
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

                <Route path='/admin' element={<SystemLayout />}>
                    {/* Public customer routes */}
                    {SystemPublicRoutes.map((route, index) => {
                        // const { element, ...rest } = route
                        return <Route key={index} {...route} />
                    })}
                    {/* Private customer routes */}
                    <Route element={<LoggedInRoute />}>
                        {SystemPrivateRoutes.map((route, index) => {
                            return <Route key={index} {...route} />
                        })}
                    </Route>
                    <Route path='*' element={<SystemPageNotFound />} />
                </Route>
            </Routes>
            <CustomToastContainer />
        </>
    )
}

export default App
