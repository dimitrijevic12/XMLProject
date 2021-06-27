import { GET_ITEMS, GET_ITEMS_ERROR } from "../types/types";
import axios from "axios";

export const getItems = () => async (dispatch) => {
  try {
    const response = await axios.get("http://localhost:55744/api/items", {
      headers: { "Access-Control-Allow-Origin": "*" },
    });
    debugger;
    dispatch({
      type: GET_ITEMS,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_ITEMS_ERROR,
      payload: console.log(e),
    });
  }
};
