import React, { useEffect, useState } from "react";
import { getPostsByCollectionAndUser } from "../../actions/actions";
import PostModal from "../../components/Profile/PostModal";
import {
  Grid,
  Photo,
  GridControlBar,
  GridControlBarItem,
} from "react-instagram-ui-kit";
import { connect } from "react-redux";
import { compose } from "redux";
import { withRouter } from "react-router-dom";

function PostsInCollection(props) {
  const [postId, setPostId] = useState("");
  const [showPostModal, setShowPostModal] = useState(false);
  const [username, setUsername] = useState("");
  const initialUser = {};
  const posts = props.posts;

  useEffect(() => {
    props.getPostsByCollectionAndUser(props.location.pathname.slice(12));
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

  if (props.posts === undefined) {
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
      <Grid>
        <GridControlBar>
          <GridControlBarItem isActive>𐄹 Saved Posts</GridControlBarItem>
        </GridControlBar>
        <Posts />
      </Grid>
    </div>
  );
}

const mapStateToProps = (state) => ({
  posts: state.posts,
});

export default compose(
  withRouter,
  connect(mapStateToProps, { getPostsByCollectionAndUser })
)(PostsInCollection);
