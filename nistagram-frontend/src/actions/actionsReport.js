import { REPORT_CONTENT, REPORT_CONTENT_ERROR } from "../types/types";
import axios from "axios";

export const reportContent = (report) => async (dispatch) => {
  debugger;
  try {
    const response = await axios.post(
      "http://localhost:44355/api/reports",
      report,
      {
        headers: {
          "Access-Control-Allow-Origin": "*",
          Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
      }
    );
    dispatch({
      type: REPORT_CONTENT,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: REPORT_CONTENT_ERROR,
      payload: console.log(e),
    });
  }
};
