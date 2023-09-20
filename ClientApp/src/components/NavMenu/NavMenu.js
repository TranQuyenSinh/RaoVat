import React, { Component } from 'react'
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap'
import { Link } from 'react-router-dom'
import logo from '../../assets/images/logo.png'
import './NavMenu.scss'

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faBars, faChevronDown } from '@fortawesome/free-solid-svg-icons'
import SearchBar from '../SearchBar/SearchBar'

export class NavMenu extends Component {
    static displayName = NavMenu.name

    constructor(props) {
        super(props)
        this.state = {
            collapsed: true,
        }
    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.state.collapsed,
        })
    }

    render() {
        return (
            <header>
                <div className='fixed-top navbar navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3'>
                    {/* Logo */}
                    <Link className='navbar__brand' to='/'>
                        <img src={logo} alt='RaoVat.net' />
                    </Link>

                    {/* Danh mục */}
                    <div className='navbar__category'>
                        <div className='navbar__category--btn'>
                            <FontAwesomeIcon icon={faBars} />
                            <span className='mx-2'>Danh mục</span>
                            <FontAwesomeIcon icon={faChevronDown} />
                        </div>

                        <ul className='navbar__category--dropdown'>
                            <li>
                                <Link to='/counter'>Xe cộ</Link>
                            </li>
                            <li>
                                <Link to='/'>Đồ điện tử</Link>
                            </li>
                            <li>
                                <Link to='/'>Thiết bị di động</Link>
                            </li>
                        </ul>
                    </div>

                    {/* Search bar */}
                    <SearchBar />
                </div>
            </header>
        )
    }
}
