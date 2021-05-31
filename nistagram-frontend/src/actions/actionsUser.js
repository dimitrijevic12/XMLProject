import {
    REGISTER_USER,
    REGISTER_USER_ERROR,
  } from "../types/types";
  import axios from "axios";
  
  export const userRegistration = (user) => async (dispatch) => {
    try {
      debugger;
      const response = await axios.post(
        "https://localhost:44355/api/users/", user,
        {
          headers: { "Access-Control-Allow-Origin": "*" },
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
  