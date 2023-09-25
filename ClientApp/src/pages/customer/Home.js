import React, { useEffect } from 'react'
import Section from '../../components/customer/Section/Section'
import Carousel from '../../components/customer/Carousel/Carousel'
import { useRetrieveData } from '../../hooks/useRetrieveData'
import { GenreGrid } from '../../components/customer/GenreGrid/GenreGrid'
import LocationSelect from '../../components/customer/LocationSelect/LocationSelect'
import Slider from 'react-slick'

import 'slick-carousel/slick/slick.css'
import 'slick-carousel/slick/slick-theme.css'

export const Home = () => {
    const carouselData = [
        {
            image: 'https://www.simplilearn.com/ice9/free_resources_article_thumb/what_is_image_Processing.jpg',
            link: '/counter',
        },
        {
            image: 'https://images.unsplash.com/photo-1575936123452-b67c3203c357?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8aW1hZ2V8ZW58MHx8MHx8fDA%3D&w=1000&q=80',
            link: '/fetch-data',
        },
        { image: 'https://imgv3.fotor.com/images/blog-cover-image/part-blurry-image.jpg', link: '/' },
    ]

    return (
        <>
            <Section className='p-0'>
                <div className='section-content'>
                    <LocationSelect />
                </div>
            </Section>
            <Section>
                <div className='section-content'>
                    <Carousel id='top-carousel' data={carouselData} />
                </div>
            </Section>
            <Section>
                <div className='section-title'>Danh mục nổi bật</div>
                <div className='section-content '>
                    <GenreGrid />
                </div>
            </Section>
        </>
    )
}
