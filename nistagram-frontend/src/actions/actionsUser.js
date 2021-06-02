import {
  GET_USERS_BY_NAME,
  GET_USERS_BY_NAME_ERROR,
  GET_USER_BY_ID,
  GET_USER_BY_ID_ERROR,
  REGISTER_USER,
  REGISTER_USER_ERROR,
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
  } catch (e) {
    console.log(e);
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
      headers: { "Access-Control-Allow-Origin": "*" },
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
        headers: { "Access-Control-Allow-Origin": "*" },
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
