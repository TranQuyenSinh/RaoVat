import React, { useState, useEffect } from 'react'
import { useNavigate } from 'react-router-dom'
import './Carousel.scss'

const Carousel = ({ data, id = 'carousel' }) => {
    const navigate = useNavigate()

    return (
        <>
            {data && data.length > 0 && (
                <div id={id} className='carousel slide custom-carousel' data-bs-ride='carousel'>
                    {/* Indicator */}
                    <div className='carousel-indicators'>
                        {data.map((item, index) => (
                            <button
                                key={index}
                                className={index === 0 ? 'active' : ''}
                                type='button'
                                data-bs-target={`#${id}`}
                                data-bs-slide-to={index}></button>
                        ))}
                    </div>
                    {/* Image */}
                    <div className='carousel-inner'>
                        {data.map((item, index) => (
                            <div
                                key={index}
                                onClick={() => navigate(item.link)}
                                className='carousel-item active'
                                data-bs-interval='3000'>
                                <img src={item.image} className='d-block w-100' />
                            </div>
                        ))}
                    </div>
                    {/* Next, Previous */}
                    <button
                        className='carousel-control-prev'
                        type='button'
                        data-bs-target={`#${id}`}
                        data-bs-slide='prev'>
                        <span className='carousel-control-prev-icon' aria-hidden='true'></span>
                        <span className='visually-hidden'>Previous</span>
                    </button>
                    <button
                        className='carousel-control-next'
                        type='button'
                        data-bs-target={`#${id}`}
                        data-bs-slide='next'>
                        <span className='carousel-control-next-icon' aria-hidden='true'></span>
                        <span className='visually-hidden'>Next</span>
                    </button>
                </div>
            )}
        </>
    )
}

export default Carousel
