import { GET_POSTS_BY_USER_ID, GET_POST } from "../types/types";

const initialState = {
  posts: [],
  post: {},
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
    default:
      return state;
  }
}

export default reducer;
