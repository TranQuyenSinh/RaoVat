import React, { useEffect, useState } from 'react'
import Section from '../../components/customer/Section/Section'
import Carousel from '../../components/customer/Carousel/Carousel'
import { GenreGrid } from '../../components/customer/GenreGrid/GenreGrid'
import LocationSelect from '../../components/customer/LocationSelect/LocationSelect'

import { useSelector } from 'react-redux'

import 'slick-carousel/slick/slick.css'
import 'slick-carousel/slick/slick-theme.css'
import GridAd from '../../components/customer/AdCard/GridAd'
import { getLatestCardAds } from '../../services'

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

    const [latestAds, setLatestAds] = useState([])
    const [index, setIndex] = useState(0)

    const { currentLocation } = useSelector(state => state.app)

    useEffect(() => {
        document.title = 'Rao vặt - Website mua bán, đăng tin rao'
    })

    const fetchMoreAds = async () => {
        if (index !== -1) {
            let { data } = await getLatestCardAds(index, currentLocation)
            if (data && data.length > 0) {
                index === 0 ? setLatestAds(data) : setLatestAds([...latestAds, ...data])
            } else {
                setIndex(-1)
                index === 0 && setLatestAds([])
            }
        }
    }

    useEffect(() => {
        fetchMoreAds()
    }, [index])

    useEffect(() => {
        if (index === 0) fetchMoreAds()
        else setIndex(0)
    }, [currentLocation])

    const loadMoreAd = () => {
        setIndex(index + 1)
    }

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
            <GenreGrid />
            <Section>
                <div className='section-title'>Tin đăng mới</div>
                <div className='section-content '>
                    <GridAd data={latestAds} />
                </div>
                {index !== -1 && (
                    <div onClick={loadMoreAd} className='section-link'>
                        Xem thêm
                    </div>
                )}
            </Section>
        </>
    )
}
