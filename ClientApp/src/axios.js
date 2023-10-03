import baseAxios from 'axios'
import { store } from './redux/store'
import { logoutUser, refreshAccessToken } from './redux/user/user.actions'
import { authApi } from './api'
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
        let { status } = error.response
        if (status == 401) {
            // xin token
            authAxios
                .post(authApi.refreshToken, {}, { params: { accessToken }, withCredentials: true })
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
export { axios, authAxios }
