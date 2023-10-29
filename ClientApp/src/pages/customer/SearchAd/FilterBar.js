import React, { useEffect, useState } from 'react'
import { useSearchParams } from 'react-router-dom'
import './FilterBar.scss'
import LocationSelectModal from '../../../components/customer/LocationSelect/LocationSelectModal'
import { useSelector } from 'react-redux'
import GenreSelectModal from '../PostAd/GenreSelectModal'
import SelectPriceModal from './SelectPriceModal'
import { formatNumber } from '../../../utils'

const FilterBar = ({ onSubmit }) => {
    const [filter, setFilter] = useState({})

    const [isOpenLocationModal, setIsOpenLocationModal] = useState(false)
    const [isOpenGenreModal, setIsOpenGenreModal] = useState(false)
    const [isOpenPriceModal, setIsOpenPriceModal] = useState(false)

    const { currentLocation } = useSelector(state => state.app)

    useEffect(() => {
        setFilter({ ...filter, location: currentLocation })
    }, [currentLocation])

    const toggleLocationModal = () => {
        setIsOpenLocationModal(!isOpenLocationModal)
    }
    const toggleGenreModal = () => {
        setIsOpenGenreModal(!isOpenGenreModal)
    }
    const togglePriceModal = () => {
        setIsOpenPriceModal(!isOpenPriceModal)
    }

    const handleRemoveFilter = (e, type) => {
        e.stopPropagation()
        delete filter[type]
        setFilter({
            ...filter,
        })
    }

    const handleSubmit = () => {
        onSubmit(filter)
    }
    return (
        <>
            <div className='filter-container'>
                <div className='btn btn-filter'>
                    <i className='fa-solid fa-filter'></i>
                    <span>Lọc</span>
                </div>
                <div onClick={toggleLocationModal} className='btn btn-filter'>
                    <i className='fa-solid fa-location-dot'></i>
                    <span>{currentLocation}</span>
                    <i className='fa-solid fa-caret-down'></i>
                </div>
                <div onClick={toggleGenreModal} className='btn btn-filter'>
                    {filter?.genres ? (
                        <>
                            <span>{filter.genres.map(item => item.title).join(', ')}</span>
                            <i onClick={e => handleRemoveFilter(e, 'genres')} className='fa-solid fa-xmark'></i>
                        </>
                    ) : (
                        <>
                            <span>Tất cả danh mục</span>
                            <i className='fa-solid fa-caret-down'></i>
                        </>
                    )}
                </div>
                <div onClick={togglePriceModal} className='btn btn-filter'>
                    {filter?.prices ? (
                        <>
                            <span>
                                {formatNumber(filter.prices[0])} - {formatNumber(filter?.prices[1])} đ
                            </span>
                            <i onClick={e => handleRemoveFilter(e, 'prices')} className='fa-solid fa-xmark'></i>
                        </>
                    ) : (
                        <>
                            <span>Giá</span>
                            <i className='fa-solid fa-caret-down'></i>
                        </>
                    )}
                </div>
                <div onClick={handleSubmit} className='btn btn-main btn-filter border-0'>
                    <span>Lọc kết quả</span>
                </div>
            </div>

            <LocationSelectModal isOpen={isOpenLocationModal} toggle={toggleLocationModal} />
            <GenreSelectModal
                isOpen={isOpenGenreModal}
                toggle={toggleGenreModal}
                onSubmit={genres => setFilter({ ...filter, genres })}
            />
            <SelectPriceModal
                isOpen={isOpenPriceModal}
                toggle={togglePriceModal}
                onSubmit={prices => setFilter({ ...filter, prices })}
            />
        </>
    )
}

export default FilterBar
