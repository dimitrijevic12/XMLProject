import {
  CREATE_AGENT_REQUEST,
  CREATE_AGENT_REQUEST_ERROR,
  GET_AGENT_REQUESTS,
  GET_AGENT_REQUESTS_ERROR,
} from "../types/types";
import axios from "axios";

export const createAgentRequest = (request) => async (dispatch) => {
  debugger;
  try {
    const response = await axios.post(
      `https://localhost:44355/api/agentRequests`,
      request,
      {
        headers: {
          "Access-Control-Allow-Origin": "*",
          Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
      }
    );
    dispatch({
      type: CREATE_AGENT_REQUEST,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: CREATE_AGENT_REQUEST_ERROR,
      payload: console.log(e),
    });
  }
};

export const getAgentRequests = () => async (dispatch) => {
  debugger;
  try {
    const response = await axios.get(
      `https://localhost:44355/api/agentRequests`,
      {
        params: { "is-approved": "false" },
        headers: {
          "Access-Control-Allow-Origin": "*",
          Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
      }
    );
    dispatch({
      type: GET_AGENT_REQUESTS,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_AGENT_REQUESTS_ERROR,
      payload: console.log(e),
    });
  }
};
