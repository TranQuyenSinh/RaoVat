import React, { Component } from 'react'
import { Link } from 'react-router-dom'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faBars, faChevronDown } from '@fortawesome/free-solid-svg-icons'
import logo from '../../../assets/images/logo.png'
import SearchBar from '../SearchBar/SearchBar'
import './Header.scss'
import NavMenu from '../NavMenu/NavMenu'

export class Header extends Component {
    static displayName = Header.name

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
                <div className='header fixed-top navbar navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3'>
                    {/* Logo */}
                    <Link className='header__brand' to='/'>
                        <img src={logo} alt='RaoVat.net' />
                    </Link>

                    {/* Danh mục */}
                    <div className='header__category'>
                        <div className='header__category--btn'>
                            <FontAwesomeIcon icon={faBars} />
                            <span className='mx-2'>Danh mục</span>
                            <FontAwesomeIcon icon={faChevronDown} />
                        </div>

                        <ul className='header__category--dropdown custom-menu'>
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

                    {/* Navmenu */}
                    <NavMenu />
                </div>
            </header>
        )
    }
}
