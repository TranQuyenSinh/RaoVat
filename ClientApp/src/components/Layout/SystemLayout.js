import React, { Component, useState } from 'react'
import { Container } from 'reactstrap'
import { Header } from '../customer/Header/Header'
import { Outlet } from 'react-router-dom'
import '@styles/main.scss'
import './SystemLayout.scss'
import Sidebar from '@components/admin/Sidebar/Sidebar'
import Navbar from '@components/admin/Navbar/Navbar'
import Footer from '@components/admin/Footer/Footer'
import { signal } from '@preact/signals-react'

export const isShowSidebar = signal(true)

export const SystemLayout = () => {
    return (
        <>
            <div className='container-fluid position-relative d-flex p-0'>
                <Sidebar isShow={isShowSidebar.value} />

                <div style={!isShowSidebar.value ? { marginLeft: 0 } : null} className='admin-content'>
                    <Navbar toggleSidebar={() => (isShowSidebar.value = !isShowSidebar.value)} />

                    <div style={{ flex: 1 }}>
                        <Outlet />
                    </div>

                    <Footer />
                </div>
            </div>
        </>
    )
}
