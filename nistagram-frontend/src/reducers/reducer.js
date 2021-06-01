import {
  GET_POSTS_BY_USER_ID,
  GET_POST,
  LOAD_IMAGE,
  SAVE_POST,
  GET_LOCATIONS,
  GET_TAGGABLE_USERS,
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
    default:
      return state;
  }
}

export default reducer;
