import React from 'react'
import './GridAd.scss'
import AdCard from './AdCard'
import AdNotFound from '../../notfound/AdNotFound/AdNotFound'

const GridAd = ({ data }) => {
    return (
        <>
            <div className='gridAd'>
                {data && data.length > 0 ? (
                    data.map((item, index) => {
                        return <AdCard key={item.id} ad={item} />
                    })
                ) : (
                    <AdNotFound />
                )}
            </div>
        </>
    )
}

export default GridAd
