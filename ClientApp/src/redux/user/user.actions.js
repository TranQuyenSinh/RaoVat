import { userTypes } from './user.types'
import { axios } from '../../axios'
import { authApi } from '../../api'
export const loginUser = (email, password) => {
    return async dispatch => {
        dispatch(loginUserStart())
        try {
            const { data } = await axios.post(
                authApi.login,
                {
                    email,
                    password,
                },
                { withCredentials: true }
            )
            dispatch(loginUserSuccess(data))
        } catch (e) {
            dispatch(loginUserFailure(e))
        }
    }
}

export const loginUserStart = () => ({
    type: userTypes.LOGIN_START,
})

export const loginUserSuccess = user => ({
    type: userTypes.LOGIN_SUCCESS,
    payload: user,
})

export const loginUserFailure = err => ({
    type: userTypes.LOGIN_FAILURE,
    payload: err,
})

export const logoutUser = () => {
    return dispatch => {
        dispatch({
            type: userTypes.LOGOUT,
        })
    }
}

export const refreshAccessToken = newToken => ({
    type: userTypes.REFRESH_ACCESS_TOKEN,
    payload: newToken,
})
