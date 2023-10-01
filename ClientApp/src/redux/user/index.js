import { userTypes } from './user.types'

const initialState = {
    isLoggedIn: false,
    isLoading: false,
    errorMessage: null,
    currentUser: {},
}

const userReducer = (state = initialState, { type, payload }) => {
    switch (type) {
        case userTypes.LOGIN_START:
            return {
                ...state,
                isLoading: true,
                errorMessage: null,
            }
        case userTypes.LOGIN_SUCCESS:
            return {
                ...state,
                isLoggedIn: true,
                isLoading: false,
                currentUser: payload,
                errorMessage: null,
            }
        case userTypes.LOGIN_FAILURE:
            return {
                ...state,
                isLoading: false,
                errorMessage: payload.response.data,
            }
        case userTypes.LOGOUT:
            return {
                ...state,
                currentUser: {},
                isLoggedIn: false,
            }

        case userTypes.REFRESH_ACCESS_TOKEN:
            let cpyState = { ...state }
            cpyState.currentUser.accessToken = payload
            return {
                ...cpyState,
            }

        default:
            return state
    }
}

export default userReducer
