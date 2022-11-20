import { call, put, takeLatest } from 'redux-saga/effects'

import {
  GET_ITEMS_FAILED,
  GET_ITEMS_SUCCEEDED,
  GET_ITEMS_REQUESTED,
  ADD_ITEM_SUCCEEDED,
  ADD_ITEM_REQUESTED,
  ADD_ITEM_FAILED,
  COMPLETE_ITEM_REQUESTED,
  COMPLETE_ITEM_SUCCEEDED,
  COMPLETE_ITEM_FAILED,
} from './homeReducer'
import axios from 'axios'

function* loadItems(action) {
  var url = process.env.REACT_APP_BASEAPI + 'todoitems'
  try {
    var items = yield call(() => {
      return new Promise((resolve, reject) => {
        axios
          .get(url)
          .then(function (response) {
            // handle success
            console.log('return', response.data)
            resolve(response.data)
          })
          .catch(function (error) {
            // handle error
            console.log(error.response)
            reject(error)
          })
          .then(function () {
            // always executed
          })
      })
    })
    yield put({ type: GET_ITEMS_SUCCEEDED, payload: items })
  } catch (e) {
    yield put({ type: ADD_ITEM_FAILED, payload: e })
  }
}

function* addItem(action) {
  var url = process.env.REACT_APP_BASEAPI + 'todoitems'
  try {
    var addedItem = yield call(() => {
      return new Promise((resolve, reject) => {
        axios
          .put(url, action.payload)
          .then(function (response) {
            // handle success
            console.log(response.data)
            resolve(response.data)
          })
          .catch(function (error) {
            // handle error
            console.log(error.response)
            reject(error)
          })
          .then(function () {
            // always executed
          })
      })
    })
    yield put({ type: ADD_ITEM_SUCCEEDED, payload: addedItem })
  } catch (e) {
    yield put({ type: ADD_ITEM_FAILED, payload: e })
  }
}
function* completeItem(action) {
  var url = process.env.REACT_APP_BASEAPI + 'completeItem'
  try {
    var result = yield call(() => {
      return new Promise((resolve, reject) => {
        axios
          .post(url, action.payload)
          .then(function (response) {
            // handle success
            resolve(response.data)
          })
          .catch(function (error) {
            // handle error
            console.log(error.response)
            reject(error)
          })
          .then(function () {
            // always executed
          })
      })
    })
    if (result) {
      yield call(loadItems, null)
    } else {
      yield put({
        type: COMPLETE_ITEM_FAILED,
        payload: 'Failed to mark ' + action.payload.description + ' as complete',
      })
    }
  } catch (e) {
    yield put({ type: COMPLETE_ITEM_FAILED, payload: e })
  }
}

function* authSaga() {
  yield takeLatest(GET_ITEMS_REQUESTED, loadItems)
  yield takeLatest(ADD_ITEM_REQUESTED, addItem)
  yield takeLatest(COMPLETE_ITEM_REQUESTED, completeItem)
}

export default authSaga
