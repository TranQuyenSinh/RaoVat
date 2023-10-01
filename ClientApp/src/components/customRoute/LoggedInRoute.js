import React from 'react'
import { useSelector } from 'react-redux'
import { Navigate, Outlet } from 'react-router-dom'

const LoggedInRoute = () => {
    const { isLoggedIn } = useSelector(state => state.user)
    console.log('user is logged in? ', isLoggedIn)
    return isLoggedIn ? <Outlet /> : <Navigate to={'/login'} replace />
}

export default LoggedInRoute
