import { axios } from '../axios'
import { authApi, userApi } from '../api'

export const getDetailShop = (shopId, userId = null) => {
    return axios.get(userApi.getDetailShop, { params: { shopId, userId } })
}

export const postAd = data => {
    let formData = new FormData()
    Object.keys(data).forEach(key => {
        if (Array.isArray(data[key])) {
            data[key].forEach(item => formData.append([key], item))
        } else {
            formData.append([key], data[key])
        }
    })
    console.log(data.images)
    return axios.post(userApi.postAd, formData, {
        headers: {
            'Content-Type': 'multipart/form-data',
        },
    })
}