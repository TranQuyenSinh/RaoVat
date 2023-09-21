import { testActionTypes } from './test.types'

export const fetchGenresStart = () => ({
    type: testActionTypes.FETCH_GENRES_START,
})

export const fetchGenresSuccess = genres => ({
    type: testActionTypes.FETCH_GENRES_SUCCESS,
    payload: genres,
})

export const fetchGenresFailure = error => ({
    type: testActionTypes.FETCH_GENRES_FAILURE,
    payload: error,
})
