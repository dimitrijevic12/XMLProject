import React, { useCallback, useEffect, useState } from "react";
import { getPostsByUserId, getAllImages } from "../../actions/actions";
import PostModal from "../../components/Profile/PostModal";
import OptionsButton from "./OptionsButton";
import MyOptionsButton from "./MyOptionsButton";
import ProfileHeader from "./ProfileHeader";
import {
  Grid,
  Photo,
  GridControlBar,
  GridControlBarItem,
} from "react-instagram-ui-kit";
import { connect } from "react-redux";
import { compose } from "redux";
import { withRouter } from "react-router-dom";
import { getUserById, followProfile } from "../../actions/actionsUser";

function PublicProfile(props) {
  const [postId, setPostId] = useState("");
  const [showPostModal, setShowPostModal] = useState(false);
  const [username, setUsername] = useState("");
  const [followedById, setFollowedById] = useState(0);
  const [followingId, setFollowingId] = useState(0);
  const user = props.user;
  const initialUser = {};
  const posts = props.posts;

  useEffect(async () => {
    await props.getUserById(props.location.pathname.slice(9));
    await props.getPostsByUserId(props.location.pathname.slice(9));
  }, [props.location.pathname]);

  const follow = () => {
    props.followProfile({
      FollowedById: sessionStorage.getItem("userId"),
      FollowingId: props.location.pathname.slice(9),
    });
  };

  const GetAllImages = (posts) => {
    const getAllImages = useCallback(async () => {
      const paths = [];
      for (var i = 0; i < props.posts.length; i++) {
        if (props.posts[i].contentPath === undefined) {
          paths.push(props.posts[i].contentPaths[0]);
        } else {
          paths.push(props.posts[i].contentPath);
        }
      }
      await props.getAllImages(paths);
    });
    return props.homePageImages;
  };

  const Posts = () => {
    if (posts.length === 0) {
      return (
        <div className="text-center pt-5">
          <img src="/images/noposts.png" />
          <br />
          <h4>No Posts Yet</h4>
        </div>
      );
    }
    var shouldDisplayPosts = false;
    if (props.location.pathname.slice(9) === sessionStorage.getItem("userId")) {
      shouldDisplayPosts = true;
    } else {
      if (user.isPrivate === false) {
        shouldDisplayPosts = true;
      } else {
        for (var i = 0; i < user.followers.length; i++) {
          if (user.followers[i].id === sessionStorage.getItem("userId")) {
            shouldDisplayPosts = true;
            break;
          }
        }
      }
    }
    console.log(props.homePageImages);
    debugger;
    if (shouldDisplayPosts === true) {
      return posts.map((post) => (
        <Photo
          src={"/images/download.jfif"}
          onClick={() => displayModalPost(post)}
        />
      ));
    } else {
      return (
        <div className="text-center pt-5">
          <img src="/images/padlock.png" />
          <br />
          <h4>This Account Is Private</h4>
        </div>
      );
    }
  };

  const displayModalPost = (post) => {
    if (post != undefined) {
      setPostId(post.id);
      setUsername(post.registeredUser.username);
    }
    setShowPostModal(!showPostModal);
  };

  if (props.posts === undefined || user === undefined) {
    return null;
  }

  const DisplayFollowButton = () => {
    var display = true;
    debugger;
    for (var i = 0; i < user.followers.length; i++) {
      if (user.followers[i].id === sessionStorage.getItem("userId")) {
        display = false;
        break;
      }
    }
    if (display === true) {
      return (
        <button
          onClick={follow}
          style={{ float: "right" }}
          className="btn btn-block btn-primary btn-md mt-4 mb-4"
        >
          Follow
        </button>
      );
    } else {
      return "";
    }
  };

  return (
    <div>
      {showPostModal ? (
        <PostModal
          show={showPostModal}
          postId={postId}
          personPhoto={user.profilePicturePath}
          person={username}
          onShowChange={() => displayModalPost()}
        />
      ) : null}
      {props.location.pathname.slice(9) === sessionStorage.getItem("userId") ? (
        <MyOptionsButton />
      ) : (
        <OptionsButton />
      )}
      <ProfileHeader
        user={user}
        userid={user.id}
        postsCount={posts.length}
        location={props.location.pathname.slice(9)}
      />
      {props.location.pathname.slice(9) === sessionStorage.getItem("userId") ? (
        ""
      ) : (
        <DisplayFollowButton />
      )}

      <Grid>
        <GridControlBar>
          <GridControlBarItem isActive>𐄹 Posts</GridControlBarItem>
          <GridControlBarItem>웃 Tagged</GridControlBarItem>
        </GridControlBar>
        <Posts />
      </Grid>
    </div>
  );
}

const mapStateToProps = (state) => ({
  posts: state.posts,
  user: state.registeredUser,
  homePageImages: state.homePageImages,
});

export default compose(
  withRouter,
  connect(mapStateToProps, {
    getPostsByUserId,
    getUserById,
    followProfile,
    getAllImages,
  })
)(PublicProfile);
