import React, { useState, useEffect } from "react";
import Layout from "../layouts/Layout";
import { Grid, Photo } from "react-instagram-ui-kit";
import { getPostsByHashTag, getPostsByLocation } from "../actions/actions";
import { connect } from "react-redux";
import { compose } from "redux";
import { withRouter } from "react-router-dom";
import PostModal from "../components/Profile/PostModal";
import _ from "lodash";

function Explore(props) {
  const [postId, setPostId] = useState("");
  const [showPostModal, setShowPostModal] = useState(false);
  const [username, setUsername] = useState("");
  const posts = props.posts;

  useEffect(() => {
    var test = props.location.pathname.slice(18);
    var testArray = test.split("-");
    if (props.location.state.searchObject.type === "hashtag") {
      props.getPostsByHashTag(props.location.hash);
    } else if (props.location.state.searchObject.type === "location") {
      debugger;
      var locationArray = props.location.pathname.slice(18).split("-");
      if (locationArray.length === 1)
        props.getPostsByLocation(locationArray[0], "", "");
      else if (locationArray.length === 2)
        props.getPostsByLocation(locationArray[1], locationArray[0], "");
      else
        props.getPostsByLocation(
          locationArray[2],
          locationArray[1],
          locationArray[0]
        );
    }
  }, [props.location.pathname]);

  if (props.posts === undefined) {
    return null;
  }
  const Posts = () =>
    posts.map((post) => (
      <Photo
        src={"/images/" + post.contentPath}
        onClick={() => displayModalPost(post)}
      />
    ));

  const displayModalPost = (post) => {
    debugger;
    if (post != undefined) {
      setPostId(post.id);
      setUsername(post.registeredUser.username);
    }
    setShowPostModal(!showPostModal);
  };

  return (
    <Layout>
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
        <Posts />
      </Grid>
    </Layout>
  );
}

const mapStateToProps = (state) => ({ posts: state.posts });

export default compose(
  withRouter,
  connect(mapStateToProps, { getPostsByHashTag, getPostsByLocation })
)(Explore);
