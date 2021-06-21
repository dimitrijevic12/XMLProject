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
  GET_ACTIVE_STORIES,
  GET_ACTIVE_STORIES_ERROR,
  ADD_CLOSE_FRIEND_STORY,
  ADD_CLOSE_FRIEND_STORY_ERROR,
  GET_STORY_BY_ID,
  GET_STORY_BY_ID_ERROR,
  LOAD_IMAGE_FOR_STORY,
  LOAD_IMAGE_FOR_STORY_ERROR,
  BAN_STORY,
  BAN_STORY_ERROR,
} from "../types/types";
import axios from "axios";

export const getStories = () => async (dispatch) => {
  try {
    const response = await axios.get("http://localhost:44355/api/stories", {
      params: {
        "following-id": sessionStorage.getItem("userId"),
        "last-24h": "true",
      },
      headers: {
        "Access-Control-Allow-Origin": "",
        Authorization: "Bearer " + sessionStorage.getItem("token"),
      },
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

export const getStoriesForUser = () => async (dispatch) => {
  debugger;
  try {
    const response = await axios.get("http://localhost:44355/api/stories", {
      params: {
        "story-owner-id": sessionStorage.getItem("userId"),
      },
      headers: {
        "Access-Control-Allow-Origin": "",
        Authorization: "Bearer " + sessionStorage.getItem("token"),
      },
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
    const response = await axios.get("http://localhost:44355/api/stories", {
      params: {
        "story-owner-id": userId,
        "following-id": sessionStorage.getItem("userId"),
        "last-24h": "true",
      },
      headers: {
        "Access-Control-Allow-Origin": "",
        Authorization: "Bearer " + sessionStorage.getItem("token"),
      },
    });
    debugger;
    dispatch({
      type: GET_ACTIVE_STORIES,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_ACTIVE_STORIES_ERROR,
      payload: console.log(e),
    });
  }
};

export const addStoryToHighlight = (highlightId, story) => async (dispatch) => {
  debugger;
  try {
    const response = await axios.post(
      `http://localhost:44355/api/highlights/${highlightId}/stories`,
      story,
      {
        headers: {
          "Access-Control-Allow-Origin": "",
          Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
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

export const getStoriesForModal = (ownerId, userid) => async (dispatch) => {
  try {
    const response = await axios.get("http://localhost:44355/api/stories", {
      params: {
        "story-owner-id": ownerId,
        "following-id": userid,
        "last-24h": "true",
      },
      headers: {
        "Access-Control-Allow-Origin": "",
        Authorization: "Bearer " + sessionStorage.getItem("token"),
      },
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
    debugger;
    const response = await axios.post(
      "http://localhost:44355/api/contents/images",
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
      payload: response.data,
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
    debugger;
    const response = await axios.post(
      "http://localhost:44355/api/contents/images",
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
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: LOAD_IMAGES_FOR_STORY_MODAL_ERROR,
      payload: console.log(e),
    });
  }
};

export const loadProfileImagesStory = (images) => async (dispatch) => {
  debugger;
  try {
    const response = await axios.post(
      "http://localhost:44355/api/contents/images",
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
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: LOAD_PROFILE_IMAGES_FOR_STORYL_ERROR,
      payload: console.log(e),
    });
  }
};

export const getTaggableForStory = () => async (dispatch) => {
  debugger;
  try {
    const response = await axios.get(
      "http://localhost:44355/api/users-for-story",
      {
        params: { "is-taggable": "true" },
        headers: {
          "Access-Control-Allow-Origin": "",
          Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
      }
    );
    debugger;
    dispatch({
      type: GET_TAGGABLE_USERS_FOR_STORY,
      payload: response.data,
    });
  } catch (e) {
    debugger;
    dispatch({
      type: GET_TAGGABLE_USERS_FOR_STORY_ERROR,
      payload: console.log(e),
    });
  }
};

export const getLocationsForStory = () => async (dispatch) => {
  try {
    const response = await axios.get(
      "http://localhost:44355/api/locations-for-story",
      {
        headers: {
          "Access-Control-Allow-Origin": "",
          Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
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
      "http://localhost:44355/api/stories",
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
      "http://localhost:44355/api/users-for-story/" +
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

export const getHighlights = (userId) => async (dispatch) => {
  try {
    const response = await axios.get("http://localhost:44355/api/highlights", {
      params: {
        "owner-id": userId,
      },
      headers: {
        "Access-Control-Allow-Origin": "",
        Authorization: "Bearer " + sessionStorage.getItem("token"),
      },
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
      "http://localhost:44355/api/highlights",
      highlight,
      {
        headers: {
          "Access-Control-Allow-Origin": "",
          Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
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

export const addCloseFriendStory = (userId) => async (dispatch) => {
  try {
    const response = await axios.put(
      `http://localhost:44355/api/story-microservice/users/${sessionStorage.getItem(
        "userId"
      )}/close-friends/${userId}`,
      {
        headers: {
          "Access-Control-Allow-Origin": "*",
          Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
      }
    );
    dispatch({
      type: ADD_CLOSE_FRIEND_STORY,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: ADD_CLOSE_FRIEND_STORY_ERROR,
      payload: console.log(e),
    });
  }
};

export const getStoryById = (id) => async (dispatch) => {
  try {
    const response = await axios
      .get("http://localhost:44355/api/stories/" + id, {
        headers: { "Access-Control-Allow-Origin": "*" },
      })
      .then(async function (response) {
        dispatch({
          type: GET_STORY_BY_ID,
          payload: response.data,
        });
        const response2 = axios
          .get(
            "http://localhost:44355/api/stories/contents/" +
              response.data.contentPath,
            {
              headers: {
                "Access-Control-Allow-Origin": "*",
              },
            }
          )
          .then(function (response2) {
            dispatch({
              type: LOAD_IMAGE_FOR_STORY,
              payload: response2.data,
            });
          });
      });
  } catch (e) {
    dispatch({
      type: GET_STORY_BY_ID_ERROR,
      payload: console.log(e),
    });
  }
};

export const loadImageForStory = (path) => async (dispatch) => {
  try {
    const response = await axios.get(
      "http://localhost:44355/api/stories/contents/" + path,
      {
        headers: { "Access-Control-Allow-Origin": "*" },
      }
    );
    dispatch({
      type: LOAD_IMAGE_FOR_STORY,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: LOAD_IMAGE_FOR_STORY_ERROR,
      payload: console.log(e),
    });
  }
};

export const banStory = (id) => async (dispatch) => {
  try {
    const response = await axios.put(
      "http://localhost:44355/api/stories/" + id + "/ban",
      {},
      {
        headers: {
          "Access-Control-Allow-Origin": "*",
          Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
      }
    );
    dispatch({
      type: BAN_STORY,
      payload: response.data,
    });
    return true;
  } catch (e) {
    dispatch({
      type: BAN_STORY_ERROR,
      payload: console.log(e),
    });
  }
};
