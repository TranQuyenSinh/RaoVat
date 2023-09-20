import React, { useEffect, useState } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faSearch, faClock } from '@fortawesome/free-solid-svg-icons'
import './SearchBar.scss'
import { Link } from 'react-router-dom'
import axios from '../../axios'

const SearchBar = () => {
    const [isShowRecentSearch, setIsShowRecentSearch] = useState(false)
    const [searchInput, setSearchInput] = useState('')
    const [searchResult, setSearchResult] = useState([])

    useEffect(() => {
        const controller = new AbortController()
        axios.get('/test/checkdb', { signal: controller.signal }).then(res => setSearchResult(res.data))

        return () => {
            controller.abort()
        }
    }, [searchInput])

    return (
        <div className='searchbar-container'>
            <div
                onFocus={() => setIsShowRecentSearch(true)}
                onBlur={() => setTimeout(() => setIsShowRecentSearch(false), 100)}
                className='searchbar'>
                <input
                    value={searchInput}
                    onChange={e => setSearchInput(e.target.value)}
                    autoComplete='off'
                    type='search'
                    placeholder='Tìm kiếm sản phẩm'
                />
                <div className='searchbar--btn'>
                    <FontAwesomeIcon icon={faSearch} />
                </div>
                {isShowRecentSearch && (
                    <div className='recent-search'>
                        {searchInput ? (
                            <>
                                <Link to='/' className='recent-search__item'>
                                    Tìm kiếm từ khóa "{searchInput}"
                                </Link>

                                {searchResult &&
                                    searchResult.length > 0 &&
                                    searchResult.map((item, index) => (
                                        <Link key={item.id} to='/' className='recent-search__item'>
                                            {item.typeName}
                                        </Link>
                                    ))}
                            </>
                        ) : (
                            <>
                                <div className='recent-search__header'>
                                    <FontAwesomeIcon className='me-2' icon={faClock} />
                                    <strong>Tìm kiếm gần đây</strong>
                                </div>
                                <Link to='/' className='recent-search__item'>
                                    Sách
                                </Link>
                            </>
                        )}
                    </div>
                )}
            </div>
        </div>
    )
}

export default SearchBar
