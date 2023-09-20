import React, { Component } from 'react'
import { Container } from 'reactstrap'
import { Header } from '../customer/Header/Header'
import { Outlet } from 'react-router-dom'
import '../../styles/main.scss'

export class SystemLayout extends Component {
    render() {
        return (
            <>
                <Header />
                <Container className='main-content'>
                    <Outlet />
                </Container>
            </>
        )
    }
}
