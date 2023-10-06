import React, { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom'
import { getDetailAd, getRootGenres } from '../../../services'
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
const DetailAd = () => {
    const [isFollow, setIsFollow] = useState(false)
    const [isFavorite, setIsFavorite] = useState(false)

    // const { adId } = useParams()
    // useEffect(() => {
    //     const fetchAds = async () => {
    //         let { data } = await getDetailAd(adId)
    //         console.log(data)
    //     }

    //     fetchAds()
    // }, [adId])

    const [isOpenLightBox, setIsOpenLightBox] = useState(false)
    const [photoIndex, setPhotoIndex] = useState(0)

    const toggleLightBox = () => {
        setIsOpenLightBox(!isOpenLightBox)
    }

    const handleShowLightBox = index => {
        setPhotoIndex(index)
        toggleLightBox()
    }

    const imgSrc = [
        'https://cdn.chotot.com/gNzL7WNyH6dIg3XTw9n2I179oKdc9-gvAkIgJuPuDCw/preset:view/plain/0446074009812d496ee72caf7c320e34-2773165303899255442.jpg',
        'https://cdn.chotot.com/T6ggT-pbYtqGOdZg60e1lXr4WDgH0cW66DPTBWm5YXQ/preset:view/plain/1c8287318cb1d392af6b76833d575808-2845231864137181388.jpg',
    ]

    return (
        <div className='ad-detail-container'>
            {/* Detail Ad */}
            <Section className='ad-detail-section'>
                {/* Infor */}
                <div className='ad-infor'>
                    <Slider className='ad-img-slider' {...adImagesCarouselConfigs}>
                        {imgSrc.map((item, index) => (
                            <div onClick={() => handleShowLightBox(index)} className='slider-item' key={index}>
                                <img src={item} alt='' />
                            </div>
                        ))}
                    </Slider>
                    <div className='ad-title'>Iphone 11 tím 64gb mới dùng 7 tháng như mới</div>
                    <div className='ad-price'>
                        <span>{formatNumber(5000000)} đ</span>
                        {isFavorite ? (
                            <div onClick={() => setIsFavorite(!isFavorite)} className='save-ad-btn btn-outline'>
                                <span>Đã lưu</span>
                                <i className='fa-solid fa-heart'></i>
                            </div>
                        ) : (
                            <div onClick={() => setIsFavorite(!isFavorite)} className='save-ad-btn btn-outline'>
                                <span>Lưu tin</span>
                                <i className='fa-regular fa-heart'></i>
                            </div>
                        )}
                    </div>
                    <p className='ad-description'>
                        {`Kẹt tiền cần bán lại cây 11 màu tím đang dùng cực tốt.
                        Bán rẻ cho ai có nhu cầu trải nghiệm.
                        Phiên bản quốc tế chính hãng Appe (bản quốc tế nên xài được 2 sim). Mới dùng gần năm, còn tốt nên hoàn toàn yên tâm nha. Máy xài kỹ đã dán cường lực 2 mặt xài ốp lưng nên còn rất rất đẹp gần như mới. Pin mình xài 2 ngày, phụ kiện zin theo máy còn đầy đủ không thiếu gì sạc cáp tai nghe hộp giấy tờ... không tiếp cửa hàng ép giá, chỉ bán cho người dùng thiện chí. mình bao sài 2 tuần cho yên. ai cần liên hệ mình tới nhà mình xem máy nha.`}
                    </p>
                    <div className='ad-param-container'>
                        <div className='ad-param-item'>
                            <i className='fa-solid fa-clipboard-list'></i> Tình trạng: Mới
                        </div>
                        <div className='ad-param-item'>
                            <i className='fa-solid fa-palette'></i> Màu sắc: Tím nhạt
                        </div>
                        <div className='ad-param-item'>
                            <i className='fa-solid fa-globe'></i> Xuất xứ: USA
                        </div>
                    </div>
                    <div className='ad-location'>
                        <div className='location-title'>Khu vực</div>
                        <div className='location-content'>
                            <i className='fa-solid fa-location-dot me-2'></i>
                            <span>Phường 1, Quận Gò Vấp, Tp Hồ Chí Minh</span>
                        </div>
                    </div>
                </div>

                {/* Side */}
                <div className='shop-sidebar'>
                    <div className='shop-info'>
                        <div className='shop-avatar'>
                            <img src='https://localhost:8080/contents/customer/avatar/customerAvatar.jpg' alt='' />
                        </div>
                        <div style={{ flex: 1 }}>
                            <div className='shop-title'>Ngọc Linh</div>
                            <div className='shop-publish-at'>
                                <i className='fa-regular fa-clock me-2'></i>
                                Đăng 3 phút trước
                            </div>
                        </div>
                    </div>
                    <div className='mt-3'>
                        {isFollow ? (
                            <div onClick={() => setIsFollow(!isFollow)} className='btn-outline outline-red'>
                                <i className='fa-solid fa-xmark'></i>
                                Bỏ theo dõi
                            </div>
                        ) : (
                            <div onClick={() => setIsFollow(!isFollow)} className='btn-outline outline-main '>
                                <i className='fa-solid fa-check'></i>
                                Theo dõi shop
                            </div>
                        )}
                    </div>
                    <div className='ad-favorite-count'>
                        <i className='fa-solid fa-user-group'></i>
                        <span>233 người theo dõi</span>
                    </div>
                    <div className='shop-contact'>
                        <i className='fa-solid fa-phone'></i>
                        <span>0815845288</span>
                    </div>
                    <div className='shop-all-ad'>
                        <i className='fa-solid fa-store'></i>
                        <span>Xem sản phẩm khác của Shop</span>
                    </div>
                </div>
            </Section>

            {/* Tin cùng shop */}
            <OtherAds shopId={3} />

            {/* Tin tương tự */}
            <SimilarAds shopId={3} />

            {/* Light box */}
            <CustomLightBox
                images={imgSrc}
                photoIndex={photoIndex}
                setPhotoIndex={setPhotoIndex}
                isOpen={isOpenLightBox}
                toggle={toggleLightBox}
            />
        </div>
    )
}

export default DetailAd
