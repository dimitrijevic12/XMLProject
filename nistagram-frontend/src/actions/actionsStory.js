import {
  GET_STORIES,
  GET_STORIES_ERROR,
  LOAD_IMAGE_STORY,
  LOAD_IMAGE_ERROR,
  GET_STORIES_FOR_MODAL,
  GET_STORIES_FOR_MODAL_ERROR,
  LOAD_IMAGES_FOR_STORY_MODAL,
  LOAD_IMAGES_FOR_STORY_MODAL_ERROR,
  LOAD_PROFILE_IMAGES_FOR_STORY,
  LOAD_PROFILE_IMAGES_FOR_STORYL_ERROR,
  GET_LOCATIONS_FOR_STORY,
  GET_LOCATIONS_FOR_STORY_ERROR,
  GET_TAGGABLE_USERS_FOR_STORY,
  GET_TAGGABLE_USERS_FOR_STORY_ERROR,
  SAVE_STORY,
  SAVE_STORY_ERROR,
  GET_USER_FOR_STORY,
  GET_USER_FOR_STORY_ERROR,
  GET_HIGHLIGHTS,
  GET_HIGHLIGHTS_ERROR,
  ADD_STORY_TO_HIGHLIGHT,
  ADD_STORY_TO_HIGHLIGHT_ERROR,
  CREATE_HIGHLIGHT,
  CREATE_HIGHLIGHT_ERROR,
  LOAD_IMAGES_FOR_ARCHIVE,
  LOAD_IMAGES_FOR_ARCHIVE_ERROR,
  GET_STORIES_FOR_ARCHIVE,
  GET_STORIES_FOR_ARCHIVE_ERROR,
} from "../types/types";
import axios from "axios";

export const getStories = () => async (dispatch) => {
  try {
    const response = await axios.get("https://localhost:44355/api/stories", {
      params: {
        "following-id": sessionStorage.getItem("userId"),
        "last-24h": "true",
      },
      headers: { "Access-Control-Allow-Origin": "" },
    });
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

export const getStoriesForUser = () => async (dispatch) => {
  debugger;
  try {
    const response = await axios.get("https://localhost:44355/api/stories", {
      params: {
        "story-owner-id": sessionStorage.getItem("userId"),
      },
      headers: { "Access-Control-Allow-Origin": "" },
    });
    debugger;
    dispatch({
      type: GET_STORIES_FOR_ARCHIVE,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_STORIES_FOR_ARCHIVE_ERROR,
      payload: console.log(e),
    });
  }
};

export const getActiveStoriesForUser = (userId) => async (dispatch) => {
  debugger;
  try {
    const response = await axios.get("https://localhost:44355/api/stories", {
      params: {
        "story-owner-id": userId,
        "last-24h": "true",
      },
      headers: { "Access-Control-Allow-Origin": "" },
    });
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

export const addStoryToHighlight = (highlightId, story) => async (dispatch) => {
  debugger;
  try {
    const response = await axios.post(
      `https://localhost:44355/api/highlights/${highlightId}/stories`,
      story,
      {
        headers: { "Access-Control-Allow-Origin": "" },
      }
    );
    dispatch({
      type: ADD_STORY_TO_HIGHLIGHT,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: ADD_STORY_TO_HIGHLIGHT_ERROR,
      payload: console.log(e),
    });
  }
};

export const getStoriesForModal = (userid) => async (dispatch) => {
  try {
    const response = await axios.get("https://localhost:44355/api/stories", {
      params: {
        "story-owner-id": userid,
        "last-24h": "true",
      },
      headers: { "Access-Control-Allow-Origin": "" },
    });
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

export const loadImagesStory = (images) => async (dispatch) => {
  try {
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

export const loadImagesForArchive = (images) => async (dispatch) => {
  try {
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
    dispatch({
      type: LOAD_IMAGES_FOR_ARCHIVE,
      payload: createFileContents(response.data),
    });
  } catch (e) {
    dispatch({
      type: LOAD_IMAGES_FOR_STORY_MODAL_ERROR,
      payload: console.log(e),
    });
  }
};

export const loadProfileImagesStory = (images) => async (dispatch) => {
  try {
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
    dispatch({
      type: LOAD_PROFILE_IMAGES_FOR_STORY,
      payload: createFileContents(response.data),
    });
  } catch (e) {
    dispatch({
      type: LOAD_PROFILE_IMAGES_FOR_STORYL_ERROR,
      payload: console.log(e),
    });
  }
};

export const getTaggableForStory = () => async (dispatch) => {
  try {
    const response = await axios.get(
      "https://localhost:44355/api/users-for-story",
      {
        params: { "is-taggable": "true" },
        headers: { "Access-Control-Allow-Origin": "" },
        Authorization: "Bearer " + sessionStorage.getItem("token"),
      }
    );
    dispatch({
      type: GET_TAGGABLE_USERS_FOR_STORY,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_TAGGABLE_USERS_FOR_STORY_ERROR,
      payload: console.log(e),
    });
  }
};

export const getLocationsForStory = () => async (dispatch) => {
  try {
    const response = await axios.get(
      "https://localhost:44355/api/locations-for-story",
      {
        headers: { "Access-Control-Allow-Origin": "" },
        Authorization: "Bearer " + sessionStorage.getItem("token"),
      }
    );
    dispatch({
      type: GET_LOCATIONS_FOR_STORY,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_LOCATIONS_FOR_STORY_ERROR,
      payload: console.log(e),
    });
  }
};

export const saveStory = (story) => async (dispatch) => {
  try {
    const response = await axios.post(
      "https://localhost:44355/api/stories",
      story,
      {
        headers: {
          "Access-Control-Allow-Origin": "*",
          Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
      }
    );
    dispatch({
      type: SAVE_STORY,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: SAVE_STORY_ERROR,
      payload: console.log(e),
    });
  }
};

export const getUserForStory = () => async (dispatch) => {
  try {
    const response = await axios.get(
      "https://localhost:44355/api/users-for-story/" +
        sessionStorage.getItem("userId"),
      {
        Authorization: "Bearer " + sessionStorage.getItem("token"),
        headers: { "Access-Control-Allow-Origin": "" },
      }
    );
    dispatch({
      type: GET_USER_FOR_STORY,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_USER_FOR_STORY_ERROR,
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

export const getHighlights = (userId) => async (dispatch) => {
  try {
    const response = await axios.get("https://localhost:44355/api/highlights", {
      params: {
        "owner-id": userId,
      },
      headers: { "Access-Control-Allow-Origin": "" },
      Authorization: "Bearer " + sessionStorage.getItem("token"),
    });
    dispatch({
      type: GET_HIGHLIGHTS,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_HIGHLIGHTS_ERROR,
      payload: console.log(e),
    });
  }
};

export const createHighlight = (highlight) => async (dispatch) => {
  try {
    const response = await axios.post(
      "https://localhost:44355/api/highlights",
      highlight,
      {
        headers: { "Access-Control-Allow-Origin": "" },
        Authorization: "Bearer " + sessionStorage.getItem("token"),
      }
    );
    dispatch({
      type: CREATE_HIGHLIGHT,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: CREATE_HIGHLIGHT_ERROR,
      payload: console.log(e),
    });
  }
};
