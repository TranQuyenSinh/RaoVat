import { combineReducers } from 'redux'
import persistReducer from 'redux-persist/es/persistReducer'
import storage from 'redux-persist/lib/storage'

import test from './test'
import app from './app'

const persistConfig = {
    key: 'root',
    storage,
}

const appPersistConfig = {
    ...persistConfig,
    key: 'app',
    whitelist: ['currentLocation'],
}

export default combineReducers({
    test,
    app: persistReducer(appPersistConfig, app),
})
