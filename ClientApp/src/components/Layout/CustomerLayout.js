import React, { Component } from 'react'
import { Container } from 'reactstrap'
import { NavMenu } from '../NavMenu/NavMenu'
import { Outlet } from 'react-router-dom'
import '../../styles/main.scss'

export class CustomerLayout extends Component {
    static displayName = CustomerLayout.name

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
