import React, { useEffect, useState } from 'react'
import { useNavigate, useSearchParams } from 'react-router-dom'
import './SearchAd.scss'
import FilterBar from './FilterBar'
import Section from '../../../components/customer/Section/Section'
import { formatNumber, moment } from '../../../utils'
import { searchAd } from '../../../services'
import { useSelector } from 'react-redux'
import Pagination from '../../../components/pagination/Pagination'
import { saveAdToFavorite } from '../../../services'
import { toast } from 'react-toastify'

const SearchAd = () => {
    const [searchParams, setSearchParams] = useSearchParams()
    const keyword = searchParams.get('q') || ''
    const [filter, setFilter] = useState()
    const { currentLocation } = useSelector(state => state.app)
    const { isLoggedIn, currentUser } = useSelector(state => state.user)
    const [currentPage, setCurrentPage] = useState(1)
    const [totalCount, setTotalCount] = useState(0)
    const navigate = useNavigate()

    const [ads, setAds] = useState([])

    const searchProduct = async () => {
        let search
        if (filter) {
            let { genres, prices, order } = filter
            search = { keyword, prices, location: currentLocation, order, genres }
        } else {
            search = { keyword, location: currentLocation }
        }
        let {
            data: { data, totalCount },
        } = await searchAd(search, currentPage - 1, currentUser?.id)
        setTotalCount(totalCount)
        setAds(data)
    }

    const handleFilter = filter => {
        setFilter(filter)
    }

    const handleSaveAd = async (e, item, isFavorite) => {
        e.stopPropagation()
        if (!isLoggedIn) {
            navigate('/login')
            return
        }
        try {
            await saveAdToFavorite(currentUser?.id, item.id)
            const index = ads.findIndex(ad => ad.id === item.id)
            const cpyAds = [...ads]
            cpyAds[index].isFavorite = isFavorite
            setAds(cpyAds)
            toast.success(isFavorite ? 'Đã lưu tin' : 'Đã bỏ lưu tin')
        } catch (e) {
            toast.error('Có lỗi xảy ra, vui lòng thử lại')
        }
    }

    useEffect(() => {
        setCurrentPage(1)
    }, [filter])

    useEffect(() => {
        searchProduct()
    }, [filter, currentLocation, currentPage, keyword])
    return (
        <>
            <FilterBar onSubmit={handleFilter} />
            <Pagination
                className='pagination'
                currentPage={currentPage}
                totalCount={totalCount}
                pageSize={10}
                siblingCount={2}
                onPageChange={page => setCurrentPage(page)}
            />
            <div className='search-container'>
                <div className='mt-2 mb-3 fw-bold'>Tìm kiếm với từ khóa: {keyword}</div>
                <Section className='search-list-container'>
                    {ads?.length > 0 &&
                        ads.map(item => (
                            <div
                                key={item.id}
                                className='product-item'
                                onClick={() => navigate('/tin-dang/' + item.id)}>
                                <div className='product-image-wrapper'>
                                    <img src={item.thumbnail} />
                                    {item.status ? (
                                        <span className='status badge bg-success'>Mới</span>
                                    ) : (
                                        <span className='status badge bg-warning'>Đã sử dụng</span>
                                    )}
                                </div>
                                <div className='product-info'>
                                    <div className='top'>
                                        <div className='title'>
                                            <span>{item.title}</span>
                                        </div>
                                        <div className='price'>{formatNumber(item.price)} đ</div>
                                    </div>
                                    <div className='bottom'>
                                        <div className='location'>
                                            <i className='fa-regular fa-clock me-2'></i>
                                            {moment(item.createdAt).fromNow()} . {item.district} - {item.province}
                                        </div>
                                        <i
                                            onClick={e => handleSaveAd(e, item, !item.isFavorite)}
                                            className={
                                                item.isFavorite
                                                    ? 'fa-solid fa-heart favorite-icon'
                                                    : 'fa-regular fa-heart favorite-icon'
                                            }></i>
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
