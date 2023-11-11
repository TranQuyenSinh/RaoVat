import baseAxios from 'axios'
import { store } from './redux/store'
import { logoutUser, refreshAccessToken } from './redux/user/user.actions'
import { authApi } from './api'
import { getCookie } from './utils'
const axios = baseAxios.create({
    baseURL: process.env.ASPNET_SERVER_URL || 'https://localhost:8080',
    timeout: 10000,
})

const authAxios = baseAxios.create({
    baseURL: process.env.ASPNET_SERVER_URL || 'https://localhost:8080',
    timeout: 10000,
    withCredentials: true,
})

authAxios.interceptors.request.use(config => {
    let accessToken = store.getState().user.currentUser?.accessToken
    config.headers['Authorization'] = 'Bearer ' + accessToken
    return config
})

authAxios.interceptors.response.use(
    response => {
        return response
    },
    error => {
        const originalRequest = error.config
        let accessToken = store.getState().user.currentUser?.accessToken
        let refreshToken = getCookie('refreshToken') || ''
        let { status } = error.response
        if (status == 401) {
            // xin token
            authAxios
                .post(authApi.refreshToken, { accessToken, refreshToken })
                .then(tokenRefreshResponse => {
                    let newToken = tokenRefreshResponse.data.accessToken
                    store.dispatch(refreshAccessToken(newToken))
                    // gọi lại api failed
                    authAxios
                        .request(originalRequest)
                        .then(response => {
                            Promise.resolve(response)
                        })
                        .catch(err => {
                            Promise.reject(err)
                        })

                    return Promise.resolve()
                })
                .catch(err => {
                    // refresh token expired
                    store.dispatch(logoutUser())
                })
        }
        return Promise.reject(error)
    }
)

// Handle errors from ASP.NET server
axios.interceptors.response.use(
    response => response,
    error => {
        let data = error.response?.data
        if (!data) return Promise.reject(error)

        if (typeof data === 'string') {
            return Promise.reject(data)
        }
        if (typeof data === 'object') {
            let { errors, status } = data
            if (errors && Object.keys(errors).length > 0 && status === 400) {
                let errorMessage = Object.keys(errors)
                    .map(key => errors[key].join('\r\n'))
                    .join(`\r\n`)
                return Promise.reject(errorMessage)
            }
        }

        return Promise.reject(error)
    }
)
export { axios, authAxios }
