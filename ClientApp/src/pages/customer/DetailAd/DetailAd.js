import React, { useState, useEffect } from 'react'

import Slider from 'react-slick'
import { toast } from 'react-toastify'
import { useSelector } from 'react-redux'
import { BouncingBalls } from 'react-cssfx-loading'
import { useParams, useNavigate } from 'react-router-dom'

import OtherAds from './OtherAds'
import SimilarAds from './SimilarAds'
import { moment } from '../../../utils'
import ShopSideBar from './ShopSideBar'
import { formatNumber } from '../../../utils'
import Section from '../../../components/customer/Section/Section'
import { followShop, getDetailAd, saveAdToFavorite } from '../../../services'
import { adImagesCarouselConfigs } from '../../../components/carousel/carouselConfig'
import CustomLightBox from '../../../components/customer/CustomLightBox/CustomLightBox'

import 'slick-carousel/slick/slick.css'
import 'slick-carousel/slick/slick-theme.css'

import './DetailAd.scss'

const DetailAd = () => {
    const { adId } = useParams()
    const navigate = useNavigate()
    const { isLoggedIn, currentUser } = useSelector(state => state.user)

    const [detailAd, setDetailAd] = useState()
    const [isLoadingDetail, setIsLoadingDetail] = useState(false)

    const [isFavorite, setIsFavorite] = useState(false)

    const [isOpenLightBox, setIsOpenLightBox] = useState(false)
    const [photoIndex, setPhotoIndex] = useState(0)

    useEffect(() => {
        ;(async () => {
            window.scrollTo(0, 0)
            setIsLoadingDetail(true)
            let { data } = await getDetailAd(adId, currentUser?.id)
            if (data) {
                setDetailAd(data)
                setIsFavorite(data.isFavorite)
                setIsLoadingDetail(false)
                document.title = data.title
                console.log(data)
            } else {
            }
        })()
    }, [adId])

    const toggleLightBox = () => {
        setIsOpenLightBox(!isOpenLightBox)
    }
    const handleShowLightBox = index => {
        setPhotoIndex(index)
        toggleLightBox()
    }

    const handleSaveAd = async isFavorite => {
        if (!isLoggedIn) {
            navigate('/login')
            return
        }
        try {
            await saveAdToFavorite(currentUser.id, detailAd.id)
            setIsFavorite(isFavorite)
            toast.success(isFavorite ? 'Đã lưu tin' : 'Đã bỏ lưu tin')
        } catch (e) {
            toast.error('Có lỗi xảy ra, vui lòng thử lại')
        }
    }

    return (
        <div className='ad-detail-container'>
            {/* Detail Ad */}

            {detailAd && !isLoadingDetail ? (
                <>
                    <Section className='ad-detail-section'>
                        {/* Infor */}
                        <div className='ad-infor'>
                            <Slider className='ad-img-slider' {...adImagesCarouselConfigs}>
                                {detailAd.images.map((item, index) => (
                                    <div className='slider-item' key={index}>
                                        <img onClick={() => handleShowLightBox(index)} src={item} alt='' />
                                    </div>
                                ))}
                            </Slider>
                            <div className='ad-title'>{detailAd.title}</div>
                            <div className='ad-price'>
                                <span>{formatNumber(detailAd.price)} đ</span>

                                <div onClick={() => handleSaveAd(!isFavorite)} className='save-ad-btn btn-outline'>
                                    {isFavorite ? (
                                        <>
                                            <span>Đã lưu</span>
                                            <i className='fa-solid fa-heart'></i>
                                        </>
                                    ) : (
                                        <>
                                            <span>Lưu tin</span>
                                            <i className='fa-regular fa-heart'></i>
                                        </>
                                    )}
                                </div>
                            </div>
                            <p className='ad-description'>{detailAd.description}</p>
                            <div className='ad-param-container'>
                                <div className='ad-param-item'>
                                    <i className='fa-solid fa-clipboard-list'></i> Tình trạng: {detailAd.status}
                                </div>
                                <div className='ad-param-item'>
                                    <i className='fa-solid fa-palette'></i> Màu sắc: {detailAd.color}
                                </div>
                                <div className='ad-param-item'>
                                    <i className='fa-solid fa-globe'></i> Xuất xứ: {detailAd.origin}
                                </div>
                            </div>
                            <div className='ad-createdAt'>Tin được đăng {moment(detailAd.createdAt).fromNow()}</div>
                        </div>

                        <ShopSideBar shopId={detailAd.shopId} />
                    </Section>
                    <CustomLightBox
                        images={detailAd.images}
                        photoIndex={photoIndex}
                        setPhotoIndex={setPhotoIndex}
                        isOpen={isOpenLightBox}
                        toggle={toggleLightBox}
                    />
                    {/* Tin cùng shop */}
                    {detailAd.shopId && <OtherAds shopId={detailAd.shopId} />}

                    {/* Tin tương tự */}
                    {adId && <SimilarAds adId={adId} />}
                </>
            ) : (
                <>
                    <div className='loading-wrapper'>
                        <BouncingBalls color='#FF8800' />
                        <span>Đang tải...</span>
                    </div>
                </>
            )}
        </div>
    )
}

export default DetailAd
