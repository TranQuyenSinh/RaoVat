import React from 'react'
import { formatNumber } from '../../../utils'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faLocationDot } from '@fortawesome/free-solid-svg-icons'
import { Link } from 'react-router-dom'
import './AdCard.scss'

const AdCard = () => {
    return (
        <div className='adcard'>
            <Link to={'/'} class='adcard__wrapper'>
                <div
                    className='adcard__image'
                    style={{ backgroundImage: `url(https://localhost:8080/contents/Ad/testAd.jpg)` }}></div>
                <div className='adcard__content'>
                    <div className='adcard__content--title'>Cần pass lại xe máy Honda</div>
                    <div className='adcard__content--price'>{formatNumber(190000000)} đ</div>
                </div>
                <div className='adcard__footer'>
                    <FontAwesomeIcon icon={faLocationDot} size='sm' className='me-1' />
                    <span>Bình Dương</span>
                </div>
            </Link>
        </div>
    )
}

export default AdCard
