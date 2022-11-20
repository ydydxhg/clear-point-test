import { createStore, applyMiddleware } from 'redux'
import { homeReducer } from './homeReducer'
import homeSaga from './homeSaga'
import createSagaMiddleware from 'redux-saga'

// create the saga middleware
const sagaMiddleware = createSagaMiddleware()
// mount it on the Store
export const homeStore = createStore(homeReducer, applyMiddleware(sagaMiddleware))

// then run the saga
sagaMiddleware.run(homeSaga)
