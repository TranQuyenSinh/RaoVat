import React, { useEffect, useState } from 'react'
import Slider from 'react-slick'
import 'slick-carousel/slick/slick.css'
import 'slick-carousel/slick/slick-theme.css'
import './GenreGrid.scss'
import { genreCarouselConfigs } from '../../../components/carousel/carouselConfig'
import { getRootGenres, getGenreBySlug } from '../../../services'

export const GenreGrid = ({ genreSlug }) => {
    const [genres, setGenres] = useState([])

    useEffect(() => {
        const fetchGenre = async () => {
            if (genreSlug) {
                let {
                    data: { childGenres },
                } = await getGenreBySlug(genreSlug)
                setGenres(childGenres)
            } else {
                let { data } = await getRootGenres()
                setGenres(data)
            }
        }
        fetchGenre()
    }, [genreSlug])

    return (
        <Slider {...genreCarouselConfigs} className='genres-container'>
            {genres &&
                genres.length > 0 &&
                genres.map((item, index) => (
                    <div key={item.id} className='genre-item'>
                        <img src={'https://localhost:8080' + item.image} alt='' />
                        <div className='genre-title'>{item.title}</div>
                    </div>
                ))}
        </Slider>
    )
}
