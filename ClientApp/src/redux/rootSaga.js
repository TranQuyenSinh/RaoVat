import { all, call } from 'redux-saga/effects'
import { testSagas } from './test/test.sagas'

export function* rootSaga() {
    yield all([call(testSagas)])
}
