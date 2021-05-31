import {
  GET_POSTS_BY_USER_ID,
  GET_POST,
  LOAD_IMAGE,
  SAVE_POST,
} from "../types/types";

const initialState = {
  posts: [],
  post: {},
  loadedImage: "",
};

function reducer(state = initialState, action) {
  switch (action.type) {
    case GET_POSTS_BY_USER_ID:
      return {
        ...state,
        posts: action.payload,
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
    default:
      return state;
  }
}

export default reducer;
