import { act } from "react-dom/test-utils";
import { loadImage } from "../actions/actions";
import {
  GET_POSTS_BY_USER_ID,
  GET_POST,
  GET_HASHTAGS_BY_TEXT,
  GET_POSTS_BY_HASHTAG,
  LOAD_IMAGE,
  GET_LOCATIONS_BY_TEXT,
  GET_POSTS_BY_LOCATION,
  REGISTER_USER,
  SAVE_POST,
  GET_LOCATIONS,
  GET_TAGGABLE_USERS,
  LIKE_POST,
  DISLIKE_POST,
  COMMENT_POST,
  LOAD_IMAGES,
  CLEAR_IMAGES,
  EDIT_USER,
  EDIT_USER_ERROR,
  GET_LOGGED_USER,
  GET_LOGGED_USER_ERROR,
  GET_USERS_BY_NAME,
  GET_USER_BY_ID,
  GET_COLLECTIONS_BY_USER,
  ADD_POST_TO_COLLECTION,
  GET_POSTS_BY_COLLECTION_AND_USER,
  GET_FOLLOW_REQUESTS,
  HANDLE_REQUESTS,
  GET_FOLLOWING,
  GET_POSTS_FOR_FOLLOWING,
  GET_ALL_IMAGES,
  GET_STORIES,
  LOAD_IMAGE_STORY,
  GET_STORIES_FOR_MODAL,
  LOAD_IMAGES_FOR_STORY_MODAL,
  LOAD_PROFILE_IMAGES_FOR_STORY,
  GET_TAGGABLE_USERS_FOR_STORY,
  GET_LOCATIONS_FOR_STORY,
  SAVE_STORY,
  GET_USER_FOR_STORY,
  CHANGE_PROFILE_PICTURE_USERMICROSERVICE,
  CHANGE_PROFILE_PICTURE_POSTMICROSERVICE,
  LOAD_IMAGE_PROFILE,
  LOAD_IMAGE_PROFILE_ERROR,
  GET_HIGHLIGHTS,
  ADD_STORY_TO_HIGHLIGHT,
  CREATE_HIGHLIGHT,
  LOAD_IMAGES_FOR_ARCHIVE,
  GET_STORIES_FOR_ARCHIVE,
  GET_ACTIVE_STORIES,
  GET_ALL_IMAGES_FOR_SEARCH,
  GET_ALL_IMAGES_FOR_PROFILE,
  GET_ALL_IMAGES_FOR_COLLECTION,
  CREATE_NEW_COLLECTION,
  GET_UNAPPROVED_VERIFICATION_REQUESTS,
  GET_FOLLOWING_WITHOUT_MUTED,
  GET_FOLLOWING_WITHOUT_MUTED_ERROR,
  GET_LIKED_POSTS,
  GET_DISLIKED_POSTS,
  REPORT_CONTENT,
  DELETE_VERIFICATION_REQUEST,
  VERIFY_USER,
  GET_USER_NOTIFICATION_SETTINGS,
  EDIT_NOTIFICATION_SETTINGS,
  CREATE_NOTIFICATION,
  GET_NOTIFICATIONS_FOR_FOLLOWING,
} from "../types/types";

const initialState = {
  posts: [],
  registeredUser: {},
  post: {},
  hashtags: {},
  locations: [],
  loadedImage: "",
  locations: [],
  taggableUsers: [],
  loadedImages: [],
  loggedUser: {},
  users: [],
  collections: [],
  followRequests: [],
  following: [],
  stories: [],
  allStories: [],
  allStoriesImages: [],
  storyImage: {},
  storyImages: [],
  storiesForModal: {},
  storyProfileImages: [],
  story: {},
  profileImage: "",
  homePageImages: [],
  highlights: [],
  activeStories: [],
  explorePosts: [],
  searchImages: [],
  profileImages: [],
  collectionImages: [],
  collectionPosts: [],
  profilePosts: [],
  unapprovedVerificationRequests: [],
  likedPosts: [],
  dislikedPosts: [],
  userNotificationSettings: {},
  commentId: 0,
  notificationsForFollowing: [],
};

function reducer(state = initialState, action) {
  switch (action.type) {
    case GET_POSTS_BY_USER_ID:
      return {
        ...state,
        profilePosts: action.payload,
      };
    case REGISTER_USER:
      return {
        ...state,
        registeredUser: action.payload,
      };
    case GET_POST:
      return {
        ...state,
        post: action.payload,
      };
    case GET_HASHTAGS_BY_TEXT:
      return {
        ...state,
        hashtags: action.payload,
      };
    case GET_POSTS_BY_HASHTAG:
      return {
        ...state,
        explorePosts: action.payload,
      };
    case GET_POSTS_BY_LOCATION:
      return {
        ...state,
        explorePosts: action.payload,
      };
    case LOAD_IMAGE:
      return {
        ...state,
        loadedImage: action.payload,
      };
    case LOAD_IMAGES:
      return {
        ...state,
        loadedImages: state.loadedImages.concat(action.payload),
      };
    case SAVE_POST:
      return {
        ...state,
        post: action.payload,
      };
    case GET_LOCATIONS_BY_TEXT:
      return {
        ...state,
        locations: action.payload,
      };
    case GET_LOCATIONS:
      return {
        ...state,
        locations: action.payload,
      };
    case GET_TAGGABLE_USERS:
      return {
        ...state,
        taggableUsers: action.payload,
      };
    case LIKE_POST:
      return {
        ...state,
      };
    case DISLIKE_POST:
      return {
        ...state,
      };
    case COMMENT_POST:
      debugger;
      return {
        ...state,
        commentId: action.payload,
      };
    case CLEAR_IMAGES:
      return {
        ...state,
        loadedImages: [],
      };
    case GET_LOGGED_USER:
      return {
        ...state,
        loggedUser: action.payload,
      };
    case GET_USERS_BY_NAME:
      return {
        ...state,
        users: action.payload,
      };
    case GET_USER_BY_ID:
      return {
        ...state,
        registeredUser: action.payload,
      };
    case GET_COLLECTIONS_BY_USER:
      return {
        ...state,
        collections: action.payload,
      };
    case ADD_POST_TO_COLLECTION:
      return {
        ...state,
      };
    case GET_POSTS_BY_COLLECTION_AND_USER:
      return {
        ...state,
        collectionPosts: action.payload,
      };
    case GET_FOLLOW_REQUESTS:
      return {
        ...state,
        followRequests: action.payload,
      };
    case HANDLE_REQUESTS:
      return {
        ...state,
        followRequests: [
          ...state.followRequests.slice(0, action.payload),
          ...state.followRequests.slice(action.payload + 1),
        ],
      };
    case GET_FOLLOWING:
      return {
        ...state,
        following: action.payload,
      };
    case GET_FOLLOWING_WITHOUT_MUTED:
      return {
        ...state,
        following: action.payload,
      };
    case GET_POSTS_FOR_FOLLOWING:
      return {
        ...state,
        posts: action.payload,
      };
    case GET_ALL_IMAGES:
      return {
        ...state,
        homePageImages: action.payload,
      };
    case GET_STORIES:
      return {
        ...state,
        stories: action.payload,
      };
    case GET_ACTIVE_STORIES:
      return {
        ...state,
        activeStories: action.payload,
      };
    case LOAD_IMAGE_STORY:
      return {
        ...state,
        storyImage: action.payload,
      };
    case GET_STORIES_FOR_MODAL:
      return {
        ...state,
        storiesForModal: action.payload,
      };
    case LOAD_IMAGES_FOR_STORY_MODAL:
      return {
        ...state,
        storyImages: action.payload,
      };
    case LOAD_PROFILE_IMAGES_FOR_STORY:
      return {
        ...state,
        storyProfileImages: action.payload,
      };
    case GET_TAGGABLE_USERS_FOR_STORY:
      return {
        ...state,
        taggableUsers: action.payload,
      };
    case GET_LOCATIONS_FOR_STORY:
      return {
        ...state,
        locations: action.payload,
      };
    case SAVE_STORY:
      debugger;
      return {
        ...state,
        story: action.payload,
      };
    case GET_USER_FOR_STORY:
      return {
        ...state,
        registeredUser: action.payload,
      };
    case GET_HIGHLIGHTS:
      return {
        ...state,
        highlights: action.payload,
      };
    case ADD_STORY_TO_HIGHLIGHT:
      return {
        ...state,
        story: action.payload,
      };
    case CREATE_HIGHLIGHT:
      return {
        ...state,
        highlights: state.highlights.concat(action.payload),
      };
    case LOAD_IMAGES_FOR_ARCHIVE:
      return {
        ...state,
        allStoriesImages: action.payload,
      };
    case GET_STORIES_FOR_ARCHIVE:
      return {
        ...state,
        allStories: action.payload,
      };
    case GET_ALL_IMAGES_FOR_SEARCH:
      return {
        ...state,
        searchImages: action.payload,
      };
    case CHANGE_PROFILE_PICTURE_USERMICROSERVICE:
      return {
        ...state,
      };
    case CHANGE_PROFILE_PICTURE_POSTMICROSERVICE:
      return {
        ...state,
      };
    case LOAD_IMAGE_PROFILE:
      return {
        ...state,
        profileImage: action.payload,
      };
    case GET_ALL_IMAGES_FOR_PROFILE:
      return {
        ...state,
        profileImages: action.payload,
      };
    case GET_ALL_IMAGES_FOR_COLLECTION:
      return {
        ...state,
        collectionImages: action.payload,
      };
    case CREATE_NEW_COLLECTION:
      return {
        ...state,
        collections: state.collections.concat(action.payload),
      };
    case GET_UNAPPROVED_VERIFICATION_REQUESTS:
      return {
        ...state,
        unapprovedVerificationRequests: action.payload,
      };
    case GET_LIKED_POSTS:
      return {
        ...state,
        likedPosts: action.payload,
      };
    case GET_DISLIKED_POSTS:
      return {
        ...state,
        dislikedPosts: action.payload,
      };
    case REPORT_CONTENT:
      return {
        ...state,
      };
    case DELETE_VERIFICATION_REQUEST:
      return {
        ...state,
        unapprovedVerificationRequests:
          state.unapprovedVerificationRequests.filter(
            (request) => action.payload !== request
          ),
      };
    case VERIFY_USER:
      return {
        ...state,
        unapprovedVerificationRequests:
          state.unapprovedVerificationRequests.filter(
            (request) => action.payload.id !== request.id
          ),
      };
    case GET_USER_NOTIFICATION_SETTINGS:
      return {
        ...state,
        userNotificationSettings: action.payload,
      };
    case EDIT_NOTIFICATION_SETTINGS:
      return {
        ...state,
        userNotificationSettings: action.payload,
      };
    case CREATE_NOTIFICATION:
      return {
        ...state,
      };
    case GET_NOTIFICATIONS_FOR_FOLLOWING:
      return {
        ...state,
        notificationsForFollowing: action.payload,
      };
    default:
      return state;
  }
}

export default reducer;
