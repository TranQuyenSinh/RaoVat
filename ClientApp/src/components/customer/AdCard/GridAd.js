import React from 'react'
import './GridAd.scss'
import AdCard from './AdCard'

const GridAd = ({ ads }) => {
    return (
        <div className='gridAd'>
            <AdCard />
            <AdCard />
            <AdCard />
            <AdCard />
            <AdCard />
            <AdCard />
        </div>
    )
}

export default GridAd
