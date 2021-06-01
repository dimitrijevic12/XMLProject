import {
  GET_POSTS_BY_USER_ID,
  REGISTER_USER,
  GET_POST,
  LOAD_IMAGE,
  SAVE_POST,
  GET_LOCATIONS,
  GET_TAGGABLE_USERS,
  LIKE_POST,
  DISLIKE_POST,
  COMMENT_POST,
} from "../types/types";

const initialState = {
  posts: [],
  registeredUser: {},
  post: {},
  loadedImage: "",
  locations: [],
  taggableUsers: [],
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
    default:
      return state;
  }
}

export default reducer;
