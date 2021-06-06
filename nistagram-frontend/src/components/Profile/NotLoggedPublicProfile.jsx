import React, { useEffect, useState } from "react";
import { getPostsByUserId } from "../../actions/actions";
import PostModal from "../../components/Profile/PostModal";
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

  useEffect(() => {
    props.getUserById(props.location.pathname.slice(9));
    props.getPostsByUserId(props.location.pathname.slice(9));
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
      <ProfileHeader user={user} userid={user.id} postsCount={posts.length} />

      <Grid>
        <GridControlBar>
          <GridControlBarItem isActive>𐄹 Posts</GridControlBarItem>
          <GridControlBarItem>웃 Tagged</GridControlBarItem>
        </GridControlBar>
        {user.isPrivate === true ? (
          <div className="text-center mt-3">
            <img src="/images/padlock.png" />
            <br />
            <h4>This Account Is Private</h4>
          </div>
        ) : (
          <Posts />
        )}
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
  connect(mapStateToProps, { getPostsByUserId, getUserById, followProfile })
)(PublicProfile);
