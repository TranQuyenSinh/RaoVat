import React, { useEffect, useReducer, useState } from 'react'
import './DisplayAds.scss'
import { formatNumber, moment } from '../../../utils'
import { Link } from 'react-router-dom'
import ConfirmHideModal from './ConfirmHideModal'
import { authAxios } from '../../../axios'
import { getDisplayAds } from '../../../services'
import NotHaveAd from '../../../components/notfound/AdNotFound/NotHaveAd'
import { BouncingBalls } from 'react-cssfx-loading'
import LoadingBalls from '../../../components/loading/LoadingBalls'
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

const DisplayAds = () => {
    const [state, dispatch] = useReducer(reducer, initialState)

    const [isOpenModal, setIsOpenModal] = useState(false)
    const [selectedAd, setSelectedAd] = useState()

    const toggleModal = () => {
        setIsOpenModal(!isOpenModal)
    }
    const handleHideAd = () => {
        console.log(selectedAd?.title)
    }
    const handleShowModal = item => {
        toggleModal()
        setSelectedAd(item)
    }

    useEffect(() => {
        dispatch({ type: 'GET_AD_START' })
        ;(async () => {
            let { data } = await getDisplayAds()
            dispatch({ type: 'GET_AD_SUCCESS', payload: data })
        })()
    }, [])

    return (
        <div className='display-ads-container'>
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
                                        <button
                                            onClick={() => handleShowModal(item)}
                                            className='btn btn-outline-secondary btn-sm fw-bold'>
                                            <i className='fa-solid fa-eye-slash me-2'></i>
                                            Ẩn tin
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
            <ConfirmHideModal isOpen={isOpenModal} toggle={toggleModal} handleSubmit={handleHideAd} />
        </div>
    )
}

export default DisplayAds
