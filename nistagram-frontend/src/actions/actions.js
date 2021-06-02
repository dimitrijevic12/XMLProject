import {
  GET_POSTS_BY_USER_ID,
  GET_POSTS_BY_USER_ID_ERROR,
  GET_POST,
  GET_POST_ERROR,
  GET_HASHTAGS_BY_TEXT_ERROR,
  GET_POSTS_BY_HASHTAG,
  GET_POSTS_BY_HASHTAG_ERROR,
  GET_HASHTAGS_BY_TEXT,
  LOAD_IMAGE,
  LOAD_IMAGE_ERROR,
  SAVE_POST,
  SAVE_POST_ERROR,
  GET_LOCATIONS,
  GET_LOCATIONS_ERROR,
  GET_TAGGABLE_USERS,
  GET_TAGGABLE_USERS_ERROR,
  LIKE_POST,
  LIKE_POST_ERROR,
  DISLIKE_POST,
  DISLIKE_POST_ERROR,
  COMMENT_POST,
  COMMENT_POST_ERROR,
  GET_LOCATIONS_BY_TEXT,
  GET_LOCATIONS_BY_TEXT_ERROR,
  GET_POSTS_BY_LOCATION,
  GET_POSTS_BY_LOCATION_ERROR,
  GET_USERS_BY_NAME,
  GET_USERS_BY_NAME_ERROR,
  GET_USER_BY_ID,
  GET_USER_BY_ID_ERROR,
} from "../types/types";
import axios from "axios";

export const getPostsByUserId = (id) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.get("https://localhost:44355/api/posts?", {
      params: { userid: id },
      headers: { "Access-Control-Allow-Origin": "*" },
    });
    debugger;
    dispatch({
      type: GET_POSTS_BY_USER_ID,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_POSTS_BY_USER_ID_ERROR,
      payload: console.log(e),
    });
  }
};

export const getPostsByHashTag = (hashtag) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.get("https://localhost:44355/api/posts?", {
      params: { hashtag: hashtag, access: "public" },
      headers: { "Access-Control-Allow-Origin": "*" },
    });
    debugger;
    dispatch({
      type: GET_POSTS_BY_HASHTAG,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_POSTS_BY_HASHTAG_ERROR,
      payload: console.log(e),
    });
  }
};

export const getPostsByLocation =
  (country, city, street) => async (dispatch) => {
    try {
      debugger;
      const response = await axios.get("https://localhost:44355/api/posts?", {
        params: {
          country: country,
          city: city,
          street: street,
          access: "public",
        },
        headers: { "Access-Control-Allow-Origin": "*" },
      });
      debugger;
      dispatch({
        type: GET_POSTS_BY_LOCATION,
        payload: response.data,
      });
    } catch (e) {
      dispatch({
        type: GET_POSTS_BY_LOCATION_ERROR,
        payload: console.log(e),
      });
    }
  };

export const getPost = (id) => async (dispatch) => {
  try {
    debugger;
    const response = await axios
      .get("https://localhost:44355/api/posts/" + id, {
        headers: { "Access-Control-Allow-Origin": "*" },
      })
      .then(function (response) {
        debugger;
        dispatch({
          type: GET_POST,
          payload: response.data,
        });
        const response2 = axios
          .get(
            "https://localhost:44355/api/posts/contents/" +
              response.data.contentPath,
            {
              headers: {
                "Access-Control-Allow-Origin": "*",
              },
            }
          )
          .then(function (response2) {
            debugger;
            dispatch({
              type: LOAD_IMAGE,
              payload: response2.data.fileContents,
            });
          });
      });
  } catch (e) {
    dispatch({
      type: GET_POST_ERROR,
      payload: console.log(e),
    });
  }
};

export const loadImage = (path) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.get(
      "https://localhost:44355/api/posts/contents/" + path,
      {
        headers: { "Access-Control-Allow-Origin": "*" },
      }
    );
    debugger;
    dispatch({
      type: LOAD_IMAGE,
      payload: response.data.fileContents,
    });
  } catch (e) {
    dispatch({
      type: LOAD_IMAGE_ERROR,
      payload: console.log(e),
    });
  }
};

export const savePost = (post) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.post(
      "https://localhost:44355/api/posts/",
      post,
      {
        headers: { "Access-Control-Allow-Origin": "*" },
      }
    );
    debugger;
    dispatch({
      type: SAVE_POST,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: SAVE_POST_ERROR,
      payload: console.log(e),
    });
  }
};

export const getHashTagsByText = (text) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.get(
      "https://localhost:44355/api/hashtags?text=" + text,
      {
        headers: { "Access-Control-Allow-Origin": "*" },
      }
    );
    dispatch({
      type: GET_HASHTAGS_BY_TEXT,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_HASHTAGS_BY_TEXT_ERROR,
      payload: console.log(e),
    });
  }
};

export const getLocationsByText = (text) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.get(
      "https://localhost:44355/api/locations?text=" + text,
      {
        headers: { "Access-Control-Allow-Origin": "*" },
      }
    );
    dispatch({
      type: GET_LOCATIONS_BY_TEXT,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_LOCATIONS_BY_TEXT_ERROR,
      payload: console.log(e),
    });
  }
};

export const getLocations = () => async (dispatch) => {
  try {
    debugger;
    const response = await axios.get("https://localhost:44355/api/locations", {
      headers: { "Access-Control-Allow-Origin": "*" },
    });
    debugger;
    dispatch({
      type: GET_LOCATIONS,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_LOCATIONS_ERROR,
      payload: console.log(e),
    });
  }
};

export const getTaggableUsers = () => async (dispatch) => {
  try {
    debugger;
    const response = await axios.get(
      "https://localhost:44355/api/users/taggable",
      {
        headers: { "Access-Control-Allow-Origin": "*" },
      }
    );
    debugger;
    dispatch({
      type: GET_TAGGABLE_USERS,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: GET_TAGGABLE_USERS_ERROR,
      payload: console.log(e),
    });
  }
};

export const likePost = (dto) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.put(
      "https://localhost:44355/api/posts/" +
        dto.id +
        "/users/" +
        dto.userId +
        "/likes",
      {},
      {
        headers: {
          "Access-Control-Allow-Origin": "*",
        },
      }
    );
    debugger;
    dispatch({
      type: LIKE_POST,
      payload: response.data,
    });
  } catch (e) {
    debugger;
    dispatch({
      type: LIKE_POST_ERROR,
      payload: console.log(e),
    });
  }
};

export const dislikePost = (dto) => async (dispatch) => {
  try {
    debugger;
    const response = await axios.put(
      "https://localhost:44355/api/posts/" +
        dto.id +
        "/users/" +
        dto.userId +
        "/dislikes",
      {},
      {
        headers: { "Access-Control-Allow-Origin": "*" },
      }
    );
    debugger;
    dispatch({
      type: DISLIKE_POST,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: DISLIKE_POST_ERROR,
      payload: console.log(e),
    });
  }
};

export const commentPost = (dto) => async (dispatch) => {
  try {
    debugger;
    const comment = dto.comment;
    const response = await axios.post(
      "https://localhost:44355/api/posts/" + dto.id + "/comments",
      comment,
      {
        headers: {
          "Access-Control-Allow-Origin": "*",
          "Content-Type": "application/json",
        },
      }
    );
    debugger;
    dispatch({
      type: COMMENT_POST,
      payload: response.data,
    });
  } catch (e) {
    dispatch({
      type: COMMENT_POST_ERROR,
      payload: console.log(e),
    });
  }
};
