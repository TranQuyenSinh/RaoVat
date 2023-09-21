import React, { useState } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import {
    faNewspaper,
    faUserCircle,
    faChevronDown,
    faEdit,
    faHeart,
    faShoppingCart,
    faCog,
    faComment,
    faSignOut,
} from '@fortawesome/free-solid-svg-icons'
import { Link } from 'react-router-dom'
import './NavMenu.scss'

const NavMenu = () => {
    return (
        <div className='navmenu'>
            <div className='navmenu__item'>
                <FontAwesomeIcon icon={faNewspaper} />
                <span>Tin của bạn</span>
            </div>
            <div className='navmenu__item user_info dropdown'>
                <div data-bs-toggle='dropdown' className=''>
                    <FontAwesomeIcon icon={faUserCircle} />
                    <span>Tài khoản</span>
                    <FontAwesomeIcon icon={faChevronDown} size='xs' />
                </div>

                <ul className='user_info--dropdown dropdown-menu custom-menu'>
                    <li className='menu-title'>Tiện ích</li>
                    <li>
                        <Link to='/counter'>
                            <FontAwesomeIcon className='menu-icon bg-red' icon={faHeart} />
                            Tin đã lưu
                        </Link>
                        <Link to='/counter'>
                            <FontAwesomeIcon className='menu-icon bg-blue' icon={faShoppingCart} />
                            Giỏ hàng của bạn
                        </Link>
                    </li>
                    <li className='menu-title'>Cài đặt</li>
                    <li>
                        <Link to='/'>
                            <FontAwesomeIcon className='menu-icon bg-gray' icon={faCog} />
                            Cài đặt tài khoản
                        </Link>
                    </li>
                    <li>
                        <Link to='/'>
                            <FontAwesomeIcon className='menu-icon bg-gray' icon={faComment} />
                            Đóng góp ý kiến
                        </Link>
                    </li>
                    <li>
                        <Link to='/'>
                            <FontAwesomeIcon className='menu-icon bg-gray' icon={faSignOut} />
                            Đăng xuất
                        </Link>
                    </li>
                </ul>
            </div>
            <button className='navmenu__btn'>
                <FontAwesomeIcon className='me-2' icon={faEdit} />
                Đăng tin
            </button>
        </div>
    )
}

export default NavMenu
