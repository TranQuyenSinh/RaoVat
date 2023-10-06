import React, { useEffect, useState } from 'react'
import Section from '../../../components/customer/Section/Section'
import GridAd from '../../../components/customer/AdCard/GridAd'
import { getLatestCardAds } from '../../../services'
import './SimilarAds.scss'
import { gridAdCarouselConfigs } from '../../../components/carousel/carouselConfig'
import Slider from 'react-slick'
import AdCard from '../../../components/customer/AdCard/AdCard'
import { Link } from 'react-router-dom'
const SimilarAds = ({ shopId }) => {
    // Test code
    const [latestAds, setLatestAds] = useState([])
    const fetchMoreLatestAds = async () => {
        let { data } = await getLatestCardAds({ currentIndex: 0, province: 'Tỉnh An Giang' })
        setLatestAds(data)
    }
    useEffect(() => {
        fetchMoreLatestAds()
    }, [])
    // Test code

    return (
        <Section className='mt-4'>
            <div className='section-title'>Tin rao khác của Hồ Minh Nguyên ({shopId})</div>
            <Slider {...gridAdCarouselConfigs}>
                {latestAds &&
                    latestAds.length > 0 &&
                    latestAds.map((item, index) => (
                        <div key={item.id}>
                            <AdCard ad={item} />
                        </div>
                    ))}
            </Slider>
            <Link to={'/'} className='section-link'>
                Xem tất cả
            </Link>
        </Section>
    )
}

export default SimilarAds
