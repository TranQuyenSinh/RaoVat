import AdminLogin from '@pages/admin/Auth/AdminLogin'
import React, { useEffect, useState } from 'react'
import { useSelector } from 'react-redux'
import { Navigate, Outlet } from 'react-router-dom'
const AdminRoute = () => {
    const { isLoggedIn, currentUser } = useSelector(state => state.user)
    return isLoggedIn ? (
        currentUser?.role != 'Administrator' ? (
            <Outlet />
        ) : (
            <Navigate to={'/not-allow'} replace />
        )
    ) : (
        <Navigate to={'/admin/login'} replace />
    )
    // return isLoggedIn ? <Outlet /> : <Navigate to={'/login'} replace />
}

export default AdminRoute
