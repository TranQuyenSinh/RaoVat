import { userTypes } from './user.types'
import { axios } from '../../axios'
import { authApi } from '../../api'

// Login
export const loginUser = (email, password) => {
    return async dispatch => {
        dispatch(loginUserStart())
        try {
            const { data } = await axios.post(authApi.login, {
                email,
                password,
            })
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

// Register
export const registerGuest = (fullname, email, password) => {
    return async dispatch => {
        dispatch(registerGuestStart())
        try {
            await axios.post(authApi.registerGuest, {
                fullname,
                email,
                password,
            })
            dispatch(registerGuestSuccess())
        } catch (e) {
            dispatch(registerGuestFailure(e))
        }
    }
}

export const registerGuestInit = () => ({
    type: userTypes.REGISTER_GUEST_INIT,
})

export const registerGuestStart = () => ({
    type: userTypes.REGISTER_GUEST_START,
})

export const registerGuestSuccess = () => ({
    type: userTypes.REGISTER_GUEST_SUCCESS,
})

export const registerGuestFailure = err => ({
    type: userTypes.REGISTER_GUEST_FAILURE,
    payload: err,
})

// Logout
export const logoutUser = () => {
    return dispatch => {
        dispatch({
            type: userTypes.LOGOUT,
        })
    }
}

// Refresh token
export const refreshAccessToken = newToken => ({
    type: userTypes.REFRESH_ACCESS_TOKEN,
    payload: newToken,
})
