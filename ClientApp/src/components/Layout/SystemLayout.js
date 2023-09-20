import React, { Component } from 'react'
import { Container } from 'reactstrap'
import { NavMenu } from '../NavMenu/NavMenu'
import { Outlet } from 'react-router-dom'
import '../../styles/main.scss'

export class SystemLayout extends Component {
    render() {
        return (
            <>
                <NavMenu />
                <Container className='main-content'>
                    <Outlet />
                </Container>
            </>
        )
    }
}
