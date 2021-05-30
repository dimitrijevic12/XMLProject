import {
  GET_POSTS_BY_USER_ID,
  GET_POSTS_BY_USER_ID_ERROR,
  GET_POST,
  GET_POST_ERROR,
} from "../types/types";
import axios from "axios";

export const getPostsByUserId = (id) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.get(
      "https://localhost:44355/api/posts/users/" + id,
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

export const getPost = (id) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.get(
      "https://localhost:44355/api/posts/" + id,
      {
        headers: { "Access-Control-Allow-Origin": "*" },
      }
    );
    debugger;
    dispatch({
      type: GET_POST,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_POST_ERROR,
      payload: console.log(e),
    });
  }
};
