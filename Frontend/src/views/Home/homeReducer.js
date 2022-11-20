export const GET_ITEMS_SUCCEEDED = 'GET_ITEMS_SUCCEEDED'
export const GET_ITEMS_FAILED = 'GET_ITEMS_FAILED'
export const GET_ITEMS_REQUESTED = 'GET_ITEMS_REQUESTED'
export const ADD_ITEM_SUCCEEDED = 'ADD_ITEM_SUCCEEDED'
export const ADD_ITEM_FAILED = 'ADD_ITEM_FAILED'
export const ADD_ITEM_REQUESTED = 'ADD_ITEM_REQUESTED'

export const COMPLETE_ITEM_SUCCEEDED = 'COMPLETE_ITEM_SUCCEEDED'
export const COMPLETE_ITEM_FAILED = 'COMPLETE_ITEM_FAILED'
export const COMPLETE_ITEM_REQUESTED = 'COMPLETE_ITEM_REQUESTED'

const initialState = {
  loading: false,
  items: [],
  currentItem: '',
  error: '',
}
export function homeReducer(state = initialState, action) {
  console.log(action.type, action)
  switch (action.type) {
    case GET_ITEMS_REQUESTED:
      return {
        ...state,
        loading: true,
      }
    case GET_ITEMS_SUCCEEDED:
      return {
        ...state,
        items: action.payload,
        loading: false,
      }
    case GET_ITEMS_FAILED:
      return {
        ...state,
        error: action.payload.error,
        loading: false,
        items: [],
      }
    case ADD_ITEM_REQUESTED:
      return {
        ...state,
        loading: true,
      }
    case ADD_ITEM_SUCCEEDED:
      return {
        ...state,
        items: [...state.items, action.payload],
        currentItem: '',
        loading: false,
      }
    case ADD_ITEM_FAILED:
      return {
        ...state,
        error: action.payload.error,
        currentItem: '',
        loading: false,
      }
    case COMPLETE_ITEM_FAILED:
      return {
        ...state,
        error: action.payload,
        currentItem: '',
        loading: false,
      }
    default:
      return state
  }
}
