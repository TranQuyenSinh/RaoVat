import React, { useEffect, useLayoutEffect, useState } from 'react'
import './ShopSideBar.scss'
import { useNavigate } from 'react-router-dom'
import { useSelector } from 'react-redux'
import { followShop, getDetailShop } from '../../../services'
import { toast } from 'react-toastify'

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
                            <img src='https://localhost:8080/contents/customer/avatar/customerAvatar.jpg' alt='' />
                        </div>
                        <div style={{ flex: 1 }}>
                            <div className='shop-title'>{shop.name}</div>
                            {/* <div className='shop-publish-at'>
                    <i className='fa-regular fa-clock me-2'></i>
                    Đăng {moment(detailAd.createdAt).locale('vi').fromNow()}
                </div> */}
                        </div>
                    </div>
                    {currentUser.id !== shop.id && (
                        <div className='mt-3'>
                            {isFollowed ? (
                                <div onClick={() => handleFollowShop(!isFollowed)} className='btn-outline outline-red'>
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
                    )}
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
            )}
        </>
    )
}

export default ShopSideBar
