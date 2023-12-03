import { authAxios, axios } from '../axios'
import { genreApi } from '../api'

export const getRootGenres = () => {
    return axios.get(genreApi.getRootGenres)
}

export const getGenreBySlug = slug => {
    return axios.get(genreApi.getGenreBySlug, {
        params: { slug },
    })
}

export const getAllGenres = () => {
    return axios.get(genreApi.getAllGenres)
}

export const createGenre = data => {
    let formData = new FormData()
    Object.keys(data).forEach(key => {
        if (Array.isArray(data[key])) {
            data[key].forEach(item => formData.append([key], item))
        } else {
            formData.append([key], data[key])
        }
    })
    return authAxios.post(genreApi.createGenre, formData, {
        headers: {
            'Content-Type': 'multipart/form-data',
        },
    })
}
