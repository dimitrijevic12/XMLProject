import {
  GET_STORIES,
  GET_STORIES_ERROR,
  LOAD_IMAGE_STORY,
  LOAD_IMAGE_ERROR,
  GET_STORIES_FOR_MODAL,
  GET_STORIES_FOR_MODAL_ERROR,
  LOAD_IMAGES_FOR_STORY_MODAL,
  LOAD_IMAGES_FOR_STORY_MODAL_ERROR,
} from "../types/types";
import axios from "axios";

export const getStories = () => async (dispatch) => {
  try {
    debugger;
    const response = await axios.get("https://localhost:44355/api/stories", {
      params: {
        "following-id": sessionStorage.getItem("userId"),
        "last-24h": "true",
      },
      headers: { "Access-Control-Allow-Origin": "" },
    });
    debugger;
    dispatch({
      type: GET_STORIES,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_STORIES_ERROR,
      payload: console.log(e),
    });
  }
};

export const getStoriesForModal = (userid) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.get("https://localhost:44355/api/stories", {
      params: {
        "story-owner-id": userid,
        "last-24h": "true",
      },
      headers: { "Access-Control-Allow-Origin": "" },
    });
    debugger;
    dispatch({
      type: GET_STORIES_FOR_MODAL,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_STORIES_FOR_MODAL_ERROR,
      payload: console.log(e),
    });
  }
};

export const loadImageStory = (path) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.get(
      "https://localhost:44355/api/contents/" + path,
      {
        headers: {
          "Access-Control-Allow-Origin": "*",
          Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
      }
    );
    debugger;
    dispatch({
      type: LOAD_IMAGE_STORY,
      payload: response.data.fileContents,
    });
  } catch (e) {
    dispatch({
      type: LOAD_IMAGE_ERROR,
      payload: console.log(e),
    });
  }
};

export const loadImagesStory = (images) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.post(
      "https://localhost:44355/api/contents/images",
      images,
      {
        headers: {
          "Access-Control-Allow-Origin": "*",
          Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
      }
    );
    debugger;
    dispatch({
      type: LOAD_IMAGES_FOR_STORY_MODAL,
      payload: createFileContents(response.data),
    });
  } catch (e) {
    dispatch({
      type: LOAD_IMAGES_FOR_STORY_MODAL_ERROR,
      payload: console.log(e),
    });
  }
};

const createFileContents = (data) => {
  var contents = [];
  data.forEach((element) => {
    contents.push(element.fileContents);
  });
  return contents;
};
