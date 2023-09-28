import { all, call } from 'redux-saga/effects'
import { testSagas } from './test/test.sagas'
import { appSagas } from './app/app.sagas'

export function* rootSaga() {
    yield all([call(testSagas, appSagas)])
}
