import axios from "axios";
import { CREATE_CAMPAIGN, CREATE_CAMPAIGN_ERROR } from "../types/types";

export const createCampaign = (campaign) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.post(
      `https://localhost:44355/api/campaigns`,
      campaign,
      {
        headers: {
          "Access-Control-Allow-Origin": "*",
          Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
      }
    );
    debugger;
    dispatch({
      type: CREATE_CAMPAIGN,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: CREATE_CAMPAIGN_ERROR,
      payload: console.log(e),
    });
  }
};
