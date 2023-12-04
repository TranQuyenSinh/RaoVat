import React, { useEffect, useRef, useState } from 'react'
import './Sidebar.scss'
import { Link, useLocation } from 'react-router-dom'
import logo from '@assets/images/logo_2.png'
import { motion } from 'framer-motion'

const Sidebar = ({ isShow }) => {
    const location = useLocation()
    console.log(location.pathname)
    const tabs = useRef([
        { id: 1, title: 'Dashboard', url: '/admin/dashboard', icon: <i className='fa-solid fa-gauge me-2'></i> },
        { id: 2, title: 'Duyệt tin', url: '/admin/review', icon: <i className='fa-solid fa-check me-2'></i> },
        {
            id: 3,
            title: 'Quản lý danh mục',
            url: '/admin/genres',
            icon: <i className='fa-solid fa-table-list me-2'></i>,
        },
    ]).current

    return (
        <motion.div className='sidebar' style={!isShow ? { translateX: '-100%', transition: 0.5 } : null}>
            <nav className='navbar p-0  navbar-dark'>
                <img src={logo} width={'100%'} />
                <div className='mt-4'>
                    {tabs.map((item, index) => (
                        <div key={item.id} className='navbar-nav w-100'>
                            <Link
                                to={item.url}
                                className={`nav-item nav-link 
                            ${location?.pathname.includes(item.url) ? 'active' : ''}`}>
                                {item.icon}
                                {item.title}
                            </Link>
                        </div>
                    ))}
                </div>
            </nav>
        </motion.div>
    )
}

export default Sidebar
