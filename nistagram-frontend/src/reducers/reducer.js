import { GET_POSTS_BY_USER_ID } from "../types/types";

const initialState = {
  posts: [],
};

function reducer(state = initialState, action) {
  switch (action.type) {
    case GET_POSTS_BY_USER_ID:
      return {
        ...state,
        posts: action.payload,
      };
    default:
      return state;
  }
}

export default reducer;
