import { testActionTypes } from './test.types'

const initialState = {
    data: null,
    error: null,
    isLoading: false,
}

const testReducer = (state = initialState, { type, payload }) => {
    switch (type) {
        case testActionTypes.FETCH_GENRES_START:
            return {
                ...state,
                isLoading: true,
                // data: null,
            }
        case testActionTypes.FETCH_GENRES_SUCCESS:
            return {
                ...state,
                data: payload,
                isLoading: false,
                error: null,
            }
        case testActionTypes.FETCH_GENRES_START:
            return {
                ...state,
                isLoading: false,
                error: payload,
            }
        default:
            return state
    }
}

export default testReducer
