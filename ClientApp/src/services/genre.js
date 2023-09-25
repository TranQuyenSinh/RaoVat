import axios from '../axios'
import { genreApi } from '../api'

export const getRootGenres = () => {
    return axios.get(genreApi.getRootGenres)
}

export const getGenreBySlug = slug => {
    return axios.get(genreApi.getGenreBySlug, {
        params: { slug: slug },
    })
}
