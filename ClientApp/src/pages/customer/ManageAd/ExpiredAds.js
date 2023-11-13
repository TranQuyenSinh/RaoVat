import React, { useState, useEffect, useReducer } from 'react'

import { Link } from 'react-router-dom'

import ConfirmHideModal from './ConfirmHideModal'
import { moment, formatNumber } from '../../../utils'
import LoadingBalls from '../../../components/loading/LoadingBalls'
import { hideAd, getExpiredAds } from '../../../services'
import NotHaveAd from '../../../components/notfound/AdNotFound/NotHaveAd'

const initialState = {
    ads: [],
    isLoading: false,
}

const reducer = (state, action) => {
    switch (action.type) {
        case 'GET_AD_START':
            return {
                ...state,
                isLoading: true,
            }
        case 'GET_AD_SUCCESS':
            return {
                ...state,
                ads: action.payload,
                isLoading: false,
            }
        default:
            return state
    }
}

const ExpiredAds = ({ resetCount }) => {
    const [state, dispatch] = useReducer(reducer, initialState)

    const handleResetAd = async adId => {
        try {
            await hideAd(adId, false)
            await fetchExpiredAds()
            resetCount()
        } catch (e) {}
    }

    const fetchExpiredAds = async () => {
        dispatch({ type: 'GET_AD_START' })
        let { data } = await getExpiredAds()
        dispatch({ type: 'GET_AD_SUCCESS', payload: data })
    }

    useEffect(() => {
        fetchExpiredAds()
    }, [])

    return (
        <div className='ad-container'>
            <div className='ad-list'>
                {state.isLoading && <LoadingBalls />}
                {!state.isLoading && (
                    <>
                        {state.ads?.length > 0 ? (
                            state.ads.map((item, index) => (
                                <div key={item.id} className='ad-item'>
                                    <div className='d-flex gap-3'>
                                        <img className='ad-item__image' src={item.thumbnail} alt='' />
                                        <div className='ad-item-info'>
                                            <Link to={`/tin-dang/${item.id}`} className='ad-item__title'>
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
                                                Hết hạn lúc:
                                                <span className='ad-item__expireAt--black'>
                                                    {moment(item.expireAt).fromNow()}
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <div className='text-end'>
                                        <button
                                            onClick={() => handleResetAd(item.id)}
                                            className='btn btn-success bg-green border-0 fw-bold me-2'>
                                            <i className='fa-solid fa-rotate me-2'></i>
                                            Đăng lại
                                        </button>
                                        <button
                                            onClick={() => handleResetAd(item.id)}
                                            className='btn btn-outline-danger border-0 fw-bold'>
                                            <i className='fa-solid fa-trash me-2'></i>
                                            Xóa tin này
                                        </button>
                                    </div>
                                </div>
                            ))
                        ) : (
                            <NotHaveAd />
                        )}
                    </>
                )}
            </div>
        </div>
    )
}

export default ExpiredAds
