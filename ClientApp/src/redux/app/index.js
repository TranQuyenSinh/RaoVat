import { appTypes } from './app.types'

const initialState = {
    currentLocation: 'Toàn quốc',
}

const appReducer = (state = initialState, { type, payload }) => {
    switch (type) {
        case appTypes.CHANGE_CUSTOMER_LOCATION:
            console.log(payload)
            return {
                ...state,
                currentLocation: payload,
            }

        default:
            return state
    }
}

export default appReducer
