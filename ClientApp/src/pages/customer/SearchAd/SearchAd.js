import React, { useState } from 'react'
import { useSearchParams } from 'react-router-dom'
import './SearchAd.scss'
import FilterBar from './FilterBar'
import Section from '../../../components/customer/Section/Section'
import { formatNumber } from '../../../utils'
const SearchAd = () => {
    const [searchParams, setSearchParams] = useSearchParams()
    const keyword = searchParams.get('q') || ''

    const [ads, setAds] = useState([])

    const searchProduct = async () => {}

    const handleFilter = filter => {
        console.log(filter)
    }
    return (
        <>
            <FilterBar onSubmit={handleFilter} />
            <div className='search-container'>
                <div className='mt-2 mb-3 fw-bold'>Tìm kiếm với từ khóa: {keyword}</div>
                <Section className='search-list-container'>
                    {[...Array(10)].map(item => (
                        <div className='product-item'>
                            <div className='product-image-wrapper'>
                                <img src='https://cdn.chotot.com/6MAungRig4jsZVlBjLRqJk5ObXUctpBtJFjoFBQopa4/preset:listing/plain/c201aeca4a8a680733743e68a4c482e2-2850289871203688576.webp' />
                                {/* <span className='status badge bg-warning'>Đã sử dụng</span> */}
                                <span className='status badge bg-success'>Mới</span>
                            </div>
                            <div className='product-info'>
                                <div className='top'>
                                    <div className='title'>
                                        <span>
                                            loa it sd còn mới nguyên thùng, mackie dlm8 cs lớn 3 loa it sd còn mới
                                            nguyên thùng, mackie dlm8 cs lớn
                                        </span>
                                    </div>
                                    <div className='price'>{formatNumber('9500000')} đ</div>
                                </div>
                                <div className='bottom'>
                                    <div className='location'>
                                        <i className='fa-regular fa-clock me-2'></i>6 Giờ Trước . Phường Mỹ Long
                                    </div>
                                    {/* <i className='fa-solid fa-heart favorite-icon'></i> */}
                                    <i className='fa-regular fa-heart favorite-icon'></i>
                                </div>
                            </div>
                        </div>
                    ))}
                </Section>
            </div>
        </>
    )
}

export default SearchAd
