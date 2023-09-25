import React from 'react'
import Slider from 'react-slick'

import 'slick-carousel/slick/slick.css'
import 'slick-carousel/slick/slick-theme.css'
import './GenreGrid.scss'
import testImage from '../../../assets/images/test.png'
import { genreCarouselConfigs } from '../../../configs/carouselConfig'

export const GenreGrid = () => {
    return (
        <Slider {...genreCarouselConfigs} className='genres-container'>
            {[...Array(30)].map((item, index) => (
                <div className='genre-item'>
                    <img src={testImage} alt='' />
                    <div className='genre-title'>Xe cộ</div>
                </div>
            ))}
        </Slider>
    )
}
