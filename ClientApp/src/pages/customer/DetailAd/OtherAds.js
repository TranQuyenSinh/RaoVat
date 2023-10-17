import React, { useEffect, useState } from 'react'
import Section from '../../../components/customer/Section/Section'
import { getRelatedCardAds } from '../../../services'
import { gridAdCarouselConfigs } from '../../../components/carousel/carouselConfig'
import './OtherAds.scss'
import Slider from 'react-slick'
import AdCard from '../../../components/customer/AdCard/AdCard'
import { Link, useParams } from 'react-router-dom'

const OtherAds = ({ shopId, shopName }) => {
    const [adCards, setAdCards] = useState([])
    const { adId } = useParams()

    useEffect(() => {
        const fetchRelatedAds = async () => {
            let { data } = await getRelatedCardAds(shopId)
            data = data?.filter(x => x.id !== +adId)
            setAdCards(data)
        }
        fetchRelatedAds()
    }, [shopId, adId])

    return (
        <Section className='mt-4'>
            <div className='section-title'>Tin rao khác của {shopName}</div>
            <Slider {...gridAdCarouselConfigs}>
                {adCards &&
                    adCards.length > 0 &&
                    adCards.map((item, index) => (
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

export default OtherAds
