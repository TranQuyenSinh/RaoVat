import { takeLatest, call, all, put } from 'redux-saga/effects'
import { testActionTypes } from './test.types'
import * as testActions from './test.actions'
import * as testServices from '../../services/test'

export function* fetchGenres() {
    try {
        const { data } = yield testServices.fetchGenres()
        yield put(testActions.fetchGenresSuccess(data))
    } catch (e) {
        yield put(testActions.fetchGenresFailure(e.message))
    }
}

// watcher/worker
export function* onFetchGenres() {
    yield takeLatest(testActionTypes.FETCH_GENRES_START, fetchGenres)
}

export function* testSagas() {
    yield all([call(onFetchGenres)])
}
