import React from 'react'
import { BouncingBalls } from 'react-cssfx-loading'
import './LoadingBalls.scss'
const LoadingBalls = ({ className }) => {
    return (
        <div className={`loading-wrapper ${className}`}>
            <BouncingBalls color='#FF8800' />
            <span>Đang tải...</span>
        </div>
    )
}

export default LoadingBalls
