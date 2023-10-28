import React, { useEffect, useState } from 'react'
import Slider from 'react-slick'
import 'slick-carousel/slick/slick.css'
import 'slick-carousel/slick/slick-theme.css'
import './GenreGrid.scss'
import { genreCarouselConfigs } from '../../../components/carousel/carouselConfig'
import { getRootGenres, getGenreBySlug } from '../../../services'
import { useNavigate } from 'react-router-dom'

export const GenreGrid = ({ genreSlug }) => {
    const navigate = useNavigate()
    const [genres, setGenres] = useState([])

    useEffect(() => {
        const fetchGenre = async () => {
            if (genreSlug) {
                console.log(genreSlug)
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

                    <div onClick={() => navigate('/' + item.slug)} key={item.id} className='genre-item'>

                        <img src={item.image} alt='' />
                        <div className='genre-title'>{item.title}</div>
                    </div>
                ))}
        </Slider>
    )
}
