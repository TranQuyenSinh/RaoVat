import React from 'react'
import { useSearchParams } from 'react-router-dom'
import './SearchAd.scss'

const SearchAd = () => {
    const [searchParams, setSearchParams] = useSearchParams()
    const keyword = searchParams.get('q') || ''
    return (
        <>
            <div>Search key: {keyword}</div>
        </>
    )
}

export default SearchAd
