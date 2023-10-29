import React from 'react'
import { useSearchParams } from 'react-router-dom'
import './SearchAd.scss'
import FilterBar from './FilterBar'

const SearchAd = () => {
    const [searchParams, setSearchParams] = useSearchParams()
    const keyword = searchParams.get('q') || ''

    const handleFilter = filter => {
        console.log(filter)
    }
    return (
        <>
            <FilterBar onSubmit={handleFilter} />
            <div>Search key: {keyword}</div>
        </>
    )
}

export default SearchAd
