import {
  GET_POSTS_BY_USER_ID,
  GET_POST,
  GET_HASHTAGS_BY_TEXT,
  GET_POSTS_BY_HASHTAG,
} from "../types/types";

const initialState = {
  posts: [],
  post: {},
  hashtags: {},
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
    default:
      return state;
  }
}

export default reducer;
