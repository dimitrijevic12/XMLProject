import { GET_POSTS_BY_USER_ID,
         REGISTER_USER
} from "../types/types";

const initialState = {
  posts: [],
  registeredUser: {}
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
    default:
      return state;
  }
}

export default reducer;
