import React, { Component } from 'react'
import { Outlet } from 'react-router-dom'
import { Header } from '../customer/Header/Header'
import '../../styles/main.scss'

export class CustomerLayout extends Component {
    static displayName = CustomerLayout.name

    render() {
        return (
            <>
                <Header />
                <div className='main-content container-fluid'>
                    <Outlet />
                </div>
            </>
        )
    }
}
