import React from 'react'
import './DisplayAds.scss'
import { formatNumber, moment } from '../../../utils'
import { Link } from 'react-router-dom'
const DisplayAds = () => {
    const ads = [
        {
            id: 1,
            title: 'Bàn phim Royal Kludge R87',
            price: 800000,
            district: 'Thành phố Long Xuyên',
            province: 'Tỉnh An Giang',
            createdAt: new Date(2023, 11, 11).toString(),
            expireAt: new Date(2024, 1, 10).toString(),
            thumbnail:
                'https://bizweb.dktcdn.net/100/466/510/products/vn-11134207-7qukw-lijxom5n1cloc3-1688354502566.jpg?v=1694596280433',
        },
        {
            id: 2,
            title: 'Điện thoại Galaxy A22 - 5G',
            price: 10000000,
            district: 'Thành phố Long Xuyên',
            province: 'Tỉnh An Giang',
            createdAt: new Date(2023, 11, 11).toString(),
            expireAt: new Date(2024, 1, 10).toString(),
            thumbnail: 'https://m.media-amazon.com/images/I/616xaAL-sHL._AC_UF894,1000_QL80_.jpg',
        },
    ]
    return (
        <div className='display-ads-container'>
            <div className='ad-list'>
                {ads?.length > 0 &&
                    ads.map((item, index) => (
                        <div key={item.id} className='ad-item'>
                            <div className='d-flex gap-3'>
                                <img className='ad-item__image' src={item.thumbnail} alt='' />
                                <div className='ad-item-info'>
                                    <Link to={'/tin-dang/130'} className='ad-item__title'>
                                        {item.title}
                                    </Link>
                                    <div className='ad-item__price'>{formatNumber(item.price)}</div>
                                    <div className='ad-item__location'>
                                        {item.district}, {item.province}
                                    </div>
                                    <div className='ad-item__createdAt'>
                                        Ngày đăng tin:
                                        <span className='ad-item__createdAt--black'>
                                            {moment(item.createdAt).format('DD/MM/YYYY')}
                                        </span>
                                    </div>
                                    <div className='ad-item__expireAt'>
                                        Ngày hết hạn:
                                        <span className='ad-item__expireAt--black'>
                                            {moment(item.expireAt).format('HH:mm DD/MM/YYYY')}
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div className='text-end'>
                                <button className='btn btn-outline-secondary btn-sm fw-bold me-2'>
                                    <i className='fa-regular fa-pen-to-square me-2'></i>Sửa tin
                                </button>
                                <button className='btn btn-outline-secondary btn-sm fw-bold'>
                                    <i className='fa-solid fa-eye-slash me-2'></i>
                                    Ẩn tin
                                </button>
                            </div>
                        </div>
                    ))}
            </div>
        </div>
    )
}

export default DisplayAds
