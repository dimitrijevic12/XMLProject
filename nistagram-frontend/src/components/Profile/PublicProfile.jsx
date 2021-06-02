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
import { getUserById } from "../../actions/actionsUser";

function PublicProfile(props) {
  const [postId, setPostId] = useState("");
  const [showPostModal, setShowPostModal] = useState(false);
  const [username, setUsername] = useState("");
  const user = props.user;
  const initialUser = {};
  const posts = props.posts;

  useEffect(() => {
    props.getUserById(props.location.pathname.slice(9));
    props.getPostsByUserId(props.location.pathname.slice(9));
  }, [props.location.pathname]);

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

  if (props.posts === undefined || user === undefined) {
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
      <button
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
});

export default compose(
  withRouter,
  connect(mapStateToProps, { getPostsByUserId, getUserById })
)(PublicProfile);
