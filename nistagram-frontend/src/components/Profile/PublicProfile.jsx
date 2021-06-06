import React, { useEffect, useState } from "react";
import { getPostsByUserId } from "../../actions/actions";
import PostModal from "../../components/Profile/PostModal";
import OptionsButton from "./OptionsButton";
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
import {
  getHighlights,
  getActiveStoriesForUser,
  getStoriesForUser,
  loadImagesForArchive,
} from "../../actions/actionsStory";
import ProfileStoryCard from "./ProfileStoryCard";

function PublicProfile(props) {
  const [postId, setPostId] = useState("");
  const [showPostModal, setShowPostModal] = useState(false);
  const [username, setUsername] = useState("");
  const [followedById, setFollowedById] = useState(0);
  const [followingId, setFollowingId] = useState(0);
  const user = props.user;
  const initialUser = {};
  const posts = props.posts;
  const highlights = props.highlights;

  useEffect(() => {
    props.getUserById(props.location.pathname.slice(9));
    props.getPostsByUserId(props.location.pathname.slice(9));
    props.getHighlights(props.location.pathname.slice(9));
    props.getActiveStoriesForUser(props.location.pathname.slice(9));
    props.getStoriesForUser();
    props.loadImagesForArchive();
  }, [props.location.pathname]);

  const follow = () => {
    props.followProfile({
      FollowedById: sessionStorage.getItem("userId"),
      FollowingId: props.location.pathname.slice(9),
    });
  };

  const Posts = () =>
    posts.map((post) => (
      <Photo
        src={"/images/download.jfif"}
        onClick={() => displayModalPost(post)}
      />
    ));

  const displayModalPost = (post) => {
    if (post != undefined) {
      setPostId(post.id);
      setUsername(post.registeredUser.username);
    }
    setShowPostModal(!showPostModal);
  };

  if (
    props.posts === undefined ||
    user === undefined ||
    props.highlights === undefined ||
    props.stories === null
  ) {
    return null;
  }

  return (
    <div>
      {showPostModal ? (
        <PostModal
          show={showPostModal}
          postId={postId}
          personPhoto="/images/download.jfif"
          person={username}
          onShowChange={() => displayModalPost()}
        />
      ) : null}
      <OptionsButton />
      <ProfileHeader user={user} userid={user.id} postsCount={posts.length} />
      <ProfileStoryCard
        user={props.user}
        activeStories={props.stories}
        highlights={props.highlights}
      />
      <button
        onClick={follow}
        style={{ float: "right" }}
        className="btn btn-block btn-primary btn-md mt-4 mb-4"
      >
        Follow
      </button>
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
  highlights: state.highlights,
  stories: state.activeStories,
});

export default compose(
  withRouter,
  connect(mapStateToProps, {
    getPostsByUserId,
    getUserById,
    followProfile,
    getHighlights,
    getActiveStoriesForUser,
    getStoriesForUser,
    loadImagesForArchive,
  })
)(PublicProfile);
