import { act } from "react-dom/test-utils";
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
  GET_LOCATIONS,
  GET_TAGGABLE_USERS,
  LIKE_POST,
  DISLIKE_POST,
  COMMENT_POST,
  EDIT_USER,
  EDIT_USER_ERROR,
  GET_LOGGED_USER,
  GET_LOGGED_USER_ERROR,
  GET_USERS_BY_NAME,
  GET_USER_BY_ID,
} from "../types/types";

const initialState = {
  posts: [],
  registeredUser: {},
  post: {},
  hashtags: {},
  locations: [],
  loadedImage: "",
  locations: [],
  taggableUsers: [],
  loggedUser : {},
  users: [],
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
    case GET_LOCATIONS:
      return {
        ...state,
        locations: action.payload,
      };
    case GET_TAGGABLE_USERS:
      return {
        ...state,
        taggableUsers: action.payload,
      };
    case LIKE_POST:
      return {
        ...state,
      };
    case DISLIKE_POST:
      return {
        ...state,
      };
    case COMMENT_POST:
      return {
        ...state,
      };
    case GET_LOGGED_USER:
      return {
        ...state,
        loggedUser : action.payload,
      };
    case GET_USERS_BY_NAME:
      return {
        ...state,
        users: action.payload,
      };
    case GET_USER_BY_ID:
      return {
        ...state,
        registeredUser: action.payload,
      };
    default:
      return state;
  }
}

export default reducer;
