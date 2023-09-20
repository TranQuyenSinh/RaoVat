import React, { Component } from 'react'
import { Container } from 'reactstrap'
import { NavMenu } from './NavMenu/NavMenu'
import '../styles/main.scss'
export class Layout extends Component {
    static displayName = Layout.name

    render() {
        return (
            <div>
                <NavMenu />
                <Container className='main-content'>{this.props.children}</Container>
            </div>
        )
    }
}
