import {
  REGISTER_USER,
  REGISTER_USER_ERROR,
  GET_LOGGED_USER,
  GET_LOGGED_USER_ERROR,
  EDIT_USER,
  EDIT_USER_ERROR,
  GET_USERS_BY_NAME,
  GET_USERS_BY_NAME_ERROR,
  GET_USER_BY_ID,
  GET_USER_BY_ID_ERROR,
  EDIT_USER_POST,
  EDIT_USER_POST_ERROR,
  EDIT_USER_STORY,
  EDIT_USER_STORY_ERROR,
  FOLLOW_PROFILE,
  FOLLOW_PROFILE_ERROR,
  GET_FOLLOW_REQUESTS,
  GET_FOLLOW_REQUESTS_ERROR,
  HANDLE_REQUESTS,
  HANDLE_REQUESTS_ERROR,
  GET_FOLLOWING,
  GET_FOLLOWING_ERROR,
} from "../types/types";
import axios from "axios";

export const userRegistration = (user) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.post(
      "https://localhost:44355/api/users",
      user,
      {
        headers: {
          "Access-Control-Allow-Origin": "*",
          Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
      }
    );
    debugger;
    dispatch({
      type: REGISTER_USER,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: REGISTER_USER_ERROR,
      payload: console.log(e),
    });
  }
};

export const userRegistrationForPost = (user) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.post(
      "https://localhost:44355/api/usersforpost",
      user,
      {
        headers: {
          "Access-Control-Allow-Origin": "*",
          Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
      }
    );
    debugger;
    dispatch({
      type: REGISTER_USER,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: REGISTER_USER_ERROR,
      payload: console.log(e),
    });
  }
};

export const userRegistrationForStory = (user) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.post(
      "https://localhost:44355/api/usersforstory",
      user,
      {
        headers: {
          "Access-Control-Allow-Origin": "*",
          Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
      }
    );
    debugger;
    dispatch({
      type: REGISTER_USER,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: REGISTER_USER_ERROR,
      payload: console.log(e),
    });
  }
};

export const userLoggedIn = (user) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.post(
      "https://localhost:44355/api/users/login",
      user,
      {
        headers: {
          "Access-Control-Allow-Origin": "*",
          Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
      }
    );
    debugger;
    var parts = response.data.token.split("."); // header, payload, signature
    var userInfo = JSON.parse(atob(parts[1]));
    sessionStorage.setItem("token", response.data.token);
    sessionStorage.setItem("userId", userInfo.user_id);
    sessionStorage.setItem("role", userInfo.role);
    sessionStorage.setItem("username", userInfo.username);
    return true;
  } catch (e) {
    console.log(e);
  }
};

export const getLoggedUser = () => async (dispatch) => {
  try {
    debugger;
    const response = await axios.get(
      "https://localhost:44355/api/users/" + sessionStorage.getItem("userId"),
      {
        headers: {
          "Access-Control-Allow-Origin": "*",
          Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
      }
    );
    debugger;
    dispatch({
      type: GET_LOGGED_USER,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_LOGGED_USER_ERROR,
      payload: console.log(e),
    });
  }
};

export const editUser = (user) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.put(
      "https://localhost:44355/api/users/edit",
      user,
      {
        headers: {
          "Access-Control-Allow-Origin": "*",
          Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
      }
    );
    debugger;
    dispatch({
      type: EDIT_USER,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: EDIT_USER_ERROR,
      payload: console.log(e),
    });
  }
};

export const editUserForPost = (user) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.put(
      "https://localhost:44355/api/users/editforpost",
      user,
      {
        headers: {
          "Access-Control-Allow-Origin": "*",
          Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
      }
    );
    debugger;
    dispatch({
      type: EDIT_USER_POST,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: EDIT_USER_POST_ERROR,
      payload: console.log(e),
    });
  }
};

export const editUserForStory = (user) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.put(
      "http://localhost:9587/api/users/story-users/" +
        sessionStorage.getItem("userId"),
      user,
      {
        headers: {
          "Access-Control-Allow-Origin": "*",
          Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
      }
    );
    debugger;
    dispatch({
      type: EDIT_USER_STORY,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: EDIT_USER_STORY_ERROR,
      payload: console.log(e),
    });
  }
};

export const getUsersByName = (name) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.get("https://localhost:44355/api/users?", {
      params: {
        name: name,
        access: "public",
      },
      headers: { "Access-Control-Allow-Origin": "" },
    });
    debugger;
    dispatch({
      type: GET_USERS_BY_NAME,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_USERS_BY_NAME_ERROR,
      payload: console.log(e),
    });
  }
};

export const getUserById = (id) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.get(
      "https://localhost:44355/api/users/" + id,
      {
        headers: { "Access-Control-Allow-Origin": "" },
      }
    );
    debugger;
    dispatch({
      type: GET_USER_BY_ID,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_USER_BY_ID_ERROR,
      payload: console.log(e),
    });
  }
};

export const followProfile = (follow) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.post(
      "https://localhost:44355/api/users/follow",
      follow,
      {
        headers: {
          "Access-Control-Allow-Origin": "*",
          Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
      }
    );
    debugger;
    dispatch({
      type: FOLLOW_PROFILE,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: FOLLOW_PROFILE_ERROR,
      payload: console.log(e),
    });
  }
};

export const getFollowRequests = () => async (dispatch) => {
  try {
    debugger;
    const response = await axios.get(
      "https://localhost:44355/api/users/" +
        sessionStorage.getItem("userId") +
        "/followRequests",
      {
        headers: { "Access-Control-Allow-Origin": "" },
      }
    );
    debugger;
    dispatch({
      type: GET_FOLLOW_REQUESTS,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_FOLLOW_REQUESTS_ERROR,
      payload: console.log(e),
    });
  }
};

export const handleRequests = (follow) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.put(
      "https://localhost:44355/api/users/handlerequest",
      follow,
      {
        headers: { "Access-Control-Allow-Origin": "" },
      }
    );
    debugger;
    dispatch({
      type: HANDLE_REQUESTS,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: HANDLE_REQUESTS_ERROR,
      payload: console.log(e),
    });
  }
};

export const getFollowing = () => async (dispatch) => {
  try {
    debugger;
    const response = await axios.get(
      "https://localhost:44355/api/users/" +
        sessionStorage.getItem("userId") +
        "/following",
      {
        headers: { "Access-Control-Allow-Origin": "" },
      }
    );
    debugger;
    dispatch({
      type: GET_FOLLOWING,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_FOLLOWING_ERROR,
      payload: console.log(e),
    });
  }
};
