import {
  GET_POSTS_BY_USER_ID,
  GET_POSTS_BY_USER_ID_ERROR,
} from "../types/types";
import axios from "axios";

export const getPostsByUserId = (id) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.get(
      "http://localhost:23078/api/post/user/" + id,
      {
        headers: { "Access-Control-Allow-Origin": "*" },
      }
    );
    debugger;
    dispatch({
      type: GET_POSTS_BY_USER_ID,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_POSTS_BY_USER_ID_ERROR,
      payload: console.log(e),
    });
  }
};
