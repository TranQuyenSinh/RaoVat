import { userTypes } from './user.types'
import { history } from '../../routes/CustomBrowserRouter'

const initialState = {
    isLoggedIn: false,
    isLoading: false,
    loginErrorMessage: null,
    registerErrorMessage: null,
    currentUser: {},
}

const userReducer = (state = initialState, { type, payload }) => {
    switch (type) {
        case userTypes.LOGIN_START:
            return {
                ...state,
                isLoading: true,
                loginErrorMessage: null,
            }
        case userTypes.LOGIN_SUCCESS:
            return {
                ...state,
                isLoggedIn: true,
                isLoading: false,
                currentUser: payload,
                loginErrorMessage: null,
            }

        // Register
        case userTypes.REGISTER_GUEST_START:
            return {
                ...state,
                isLoading: true,
                registerErrorMessage: null,
            }
        case userTypes.REGISTER_GUEST_SUCCESS:
            history.push('/login')
            return {
                ...state,
                isLoading: false,
                registerErrorMessage: null,
            }

        // failure cases
        case userTypes.LOGIN_FAILURE:
            return {
                ...state,
                isLoading: false,
                loginErrorMessage: payload,
            }
        case userTypes.REGISTER_GUEST_FAILURE:
            return {
                ...state,
                isLoading: false,
                registerErrorMessage: payload,
            }

        // logout
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
