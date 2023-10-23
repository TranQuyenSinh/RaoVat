import React, { useEffect, useLayoutEffect, useState } from 'react'
import './ShopSideBar.scss'
import { useNavigate } from 'react-router-dom'
import { useSelector } from 'react-redux'
import { followShop, getDetailShop } from '../../../services'
import { toast } from 'react-toastify'
import no_avatar from '../../../assets/images/no_avatar.png'

const ShopSideBar = ({ shopId }) => {
    const navigate = useNavigate()
    const { isLoggedIn, currentUser } = useSelector(state => state.user)

    const [shop, setShop] = useState()
    const [isFollowed, setIsFollowed] = useState(false)

    useLayoutEffect(() => {
        const fetchShop = async () => {
            let { data } = await getDetailShop(shopId, currentUser?.id)
            setShop(data)
            setIsFollowed(data.isFollowed)
        }
        fetchShop()
    }, [shopId])
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
        <>
            {shop && (
                <div className='shop-sidebar'>
                    <div className='shop-info'>
                        <div className='shop-avatar'>
                            <img src={shop.avatar || no_avatar} alt='' />
                        </div>
                        <div style={{ flex: 1 }}>
                            <div className='shop-title'>{shop.name}</div>
                            <div className='shop-location'>
                                <i className='fa-solid fa-location-dot fa-sm me-1'></i>
                                <span>{`${shop.district}, ${shop.province}`}</span>
                            </div>
                        </div>
                    </div>
                    <div className='ad-favorite-count'>
                        <i className='fa-solid fa-user-group'></i>
                        <span>{shop.totalFollowers} người theo dõi</span>
                    </div>
                    {currentUser.id !== shop.id && (
                        <div className='shop-follow-btn-wrapper mt-3'>
                            {isFollowed ? (
                                <div onClick={() => handleFollowShop(!isFollowed)} className='btn-solid solid-blue'>
                                    <i className='fa-solid fa-user-check'></i>
                                    Đang theo dõi
                                </div>
                            ) : (
                                <div
                                    onClick={() => handleFollowShop(!isFollowed)}
                                    className='btn-outline outline-blue '>
                                    <i className='fa-solid fa-check'></i>
                                    Theo dõi shop
                                </div>
                            )}
                        </div>
                    )}
                    <div className='shop-contact'>
                        <i className='fa-solid fa-phone'></i>
                        <span>{shop.phone}</span>
                    </div>
                    <div className='shop-all-ad'>
                        <i className='fa-solid fa-store'></i>
                        <span>Xem sản phẩm khác của Shop</span>
                    </div>
                </div>
            )}
        </>
    )
}

export default ShopSideBar
