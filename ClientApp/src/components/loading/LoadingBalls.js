import React from 'react'
import { BouncingBalls } from 'react-cssfx-loading'
import './LoadingBalls.scss'
const LoadingBalls = () => {
    return (
        <div className='loading-wrapper'>
            <BouncingBalls color='#FF8800' />
            <span>Đang tải...</span>
        </div>
    )
}

export default LoadingBalls
