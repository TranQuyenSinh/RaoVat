import { combineReducers } from 'redux'
import persistReducer from 'redux-persist/es/persistReducer'
import storage from 'redux-persist/lib/storage'

import test from './test'

const persistConfig = {
    key: 'root',
    storage,
    // whitelist: ['data'],
}

const rootReducer = combineReducers({
    test,
})

export default persistReducer(persistConfig, rootReducer)
