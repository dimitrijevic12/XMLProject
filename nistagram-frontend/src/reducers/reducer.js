import { loadImage } from "../actions/actions";
import {
  GET_POSTS_BY_USER_ID,
  GET_POST,
  GET_HASHTAGS_BY_TEXT,
  GET_POSTS_BY_HASHTAG,
  LOAD_IMAGE,
  GET_LOCATIONS_BY_TEXT,
  GET_POSTS_BY_LOCATION,
  REGISTER_USER,
  SAVE_POST,
} from "../types/types";

const initialState = {
  posts: [],
  registeredUser: {},
  post: {},
  hashtags: {},
  locations: [],
  loadedImage: "",
};

function reducer(state = initialState, action) {
  switch (action.type) {
    case GET_POSTS_BY_USER_ID:
      return {
        ...state,
        posts: action.payload,
      };
    case REGISTER_USER:
      return {
        ...state,
        registeredUser: action.payload,
      };
    case GET_POST:
      return {
        ...state,
        post: action.payload,
      };
    case GET_HASHTAGS_BY_TEXT:
      return {
        ...state,
        hashtags: action.payload,
      };
    case GET_POSTS_BY_HASHTAG:
      return {
        ...state,
        posts: action.payload,
      };
    case GET_POSTS_BY_LOCATION:
      return {
        ...state,
        posts: action.payload,
      };
    case LOAD_IMAGE:
      return {
        ...state,
        loadedImage: action.payload,
      };
    case SAVE_POST:
      return {
        ...state,
        post: action.payload,
      };
    case GET_LOCATIONS_BY_TEXT:
      return {
        ...state,
        locations: action.payload,
      };
    default:
      return state;
  }
}

export default reducer;
