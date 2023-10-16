import React, { useState, useEffect } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import { getDetailAd, saveAdToFavorite, followShop } from '../../../services'
import Section from '../../../components/customer/Section/Section'
import './DetailAd.scss'
import { formatNumber } from '../../../utils'
import Slider from 'react-slick'
import 'slick-carousel/slick/slick.css'
import 'slick-carousel/slick/slick-theme.css'
import { adImagesCarouselConfigs } from '../../../components/carousel/carouselConfig'
import CustomLightBox from '../../../components/customer/CustomLightBox/CustomLightBox'
import OtherAds from './OtherAds'
import SimilarAds from './SimilarAds'
import { toast } from 'react-toastify'
import { useSelector } from 'react-redux'
import { BouncingBalls } from 'react-cssfx-loading'

const DetailAd = () => {
    const { adId } = useParams()
    const navigate = useNavigate()
    const { isLoggedIn, currentUser } = useSelector(state => state.user)

    const [detailAd, setDetailAd] = useState()
    const [shop, setShop] = useState()
    const [isLoadingDetail, setIsLoadingDetail] = useState(false)

    const [isFollowed, setIsFollowed] = useState(false)
    const [isFavorite, setIsFavorite] = useState(false)

    const [isOpenLightBox, setIsOpenLightBox] = useState(false)
    const [photoIndex, setPhotoIndex] = useState(0)

    useEffect(() => {
        const fetchAds = async () => {
            window.scrollTo(0, 0)
            setIsLoadingDetail(true)
            let {
                data: { ad, shop },
            } = await getDetailAd(adId, currentUser?.id)
            setDetailAd(ad)
            setShop(shop)
            setIsFavorite(ad.isFavorite)
            setIsFollowed(shop.isFollowed)
            setIsLoadingDetail(false)
        }
        fetchAds()
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

    const handleFollowShop = async isFollowed => {
        if (!isLoggedIn) {
            navigate('/login')
            return
        }
        try {
            await followShop(currentUser.id, shop.id)
            setIsFollowed(isFollowed)
        } catch (e) {
            toast.error('Có lỗi xảy ra, vui lòng thử lại')
        }
    }

    return (
        <div className='ad-detail-container'>
            {/* Detail Ad */}

            {detailAd && shop && !isLoadingDetail ? (
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
                                            {' '}
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
                            <div className='ad-location'>
                                <div className='location-title'>Khu vực</div>
                                <div className='location-content'>
                                    <i className='fa-solid fa-location-dot me-2'></i>
                                    <span>{`${shop.district}, ${shop.province}`}</span>
                                </div>
                            </div>
                        </div>

                        {/* Side */}
                        <div className='shop-sidebar'>
                            <div className='shop-info'>
                                <div className='shop-avatar'>
                                    <img
                                        src='https://localhost:8080/contents/customer/avatar/customerAvatar.jpg'
                                        alt=''
                                    />
                                </div>
                                <div style={{ flex: 1 }}>
                                    <div className='shop-title'>{shop.name}</div>
                                    <div className='shop-publish-at'>
                                        <i className='fa-regular fa-clock me-2'></i>
                                        Đăng 3 phút trước
                                    </div>
                                </div>
                            </div>
                            <div className='mt-3'>
                                {isFollowed ? (
                                    <div
                                        onClick={() => handleFollowShop(!isFollowed)}
                                        className='btn-outline outline-red'>
                                        <i className='fa-solid fa-xmark'></i>
                                        Bỏ theo dõi
                                    </div>
                                ) : (
                                    <div
                                        onClick={() => handleFollowShop(!isFollowed)}
                                        className='btn-outline outline-main '>
                                        <i className='fa-solid fa-check'></i>
                                        Theo dõi shop
                                    </div>
                                )}
                            </div>
                            <div className='ad-favorite-count'>
                                <i className='fa-solid fa-user-group'></i>
                                <span>{shop.totalFollowers} người theo dõi</span>
                            </div>
                            <div className='shop-contact'>
                                <i className='fa-solid fa-phone'></i>
                                <span>{shop.phone}</span>
                            </div>
                            <div className='shop-all-ad'>
                                <i className='fa-solid fa-store'></i>
                                <span>Xem sản phẩm khác của Shop</span>
                            </div>
                        </div>
                    </Section>
                    <CustomLightBox
                        images={detailAd.images}
                        photoIndex={photoIndex}
                        setPhotoIndex={setPhotoIndex}
                        isOpen={isOpenLightBox}
                        toggle={toggleLightBox}
                    />
                </>
            ) : (
                <>
                    <div className='loading-wrapper'>
                        <BouncingBalls color='#FF8800' />
                        <span>Đang tải...</span>
                    </div>
                </>
            )}

            {/* Tin cùng shop */}
            {shop && <OtherAds shopId={shop.id} shopName={shop.name} />}

            {/* Tin tương tự */}
            <SimilarAds shopId={3} />

            {/* Light box */}
        </div>
    )
}

export default DetailAd
