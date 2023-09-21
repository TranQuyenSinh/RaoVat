import React, { Component } from 'react'
import Section from '../../components/customer/Section/Section'
import { Link } from 'react-router-dom'

export class Home extends Component {
    render() {
        return (
            <Section>
                <div className='section-title'>Xe đã qua sử dụng</div>
                <div className='section-content'>Hello bà già</div>
                <Link className='section-link' to={'/'}>
                    Xem thêm
                </Link>
            </Section>
        )
    }
}
