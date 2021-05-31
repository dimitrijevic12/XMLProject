import React, { Component } from "react";
import Layout from "../layouts/Layout";
import { Grid, Photo } from "react-instagram-ui-kit";
import { getPostsByHashTag } from "../actions/actions";
import { connect } from "react-redux";
import { compose } from "redux";
import { withRouter } from "react-router-dom";
import PostModal from "../components/Profile/PostModal";
import _ from "lodash";

class Explore extends Component {
  state = {};

  componentDidMount() {
    debugger;
    this.props.getPostsByHashTag(this.props.location.state.searchObject.value);
  }

  static getDerivedStateFromProps(props, state) {
    debugger;
    // Re-run the filter whenever the list array or filter text change.
    // Note we need to store prevPropsList and prevFilterText to detect changes.
    if (
      state.location === undefined ||
      props.location.pathname !== state.location.pathname ||
      _.isEqual(props.posts, state.posts)
    ) {
      props.getPostsByHashTag(props.location.state.searchObject.value);
      return {
        posts: props.posts,
        location: props.location,
      };
    }
    return null;
  }

  render() {
    if (this.props.posts == undefined) {
      return null;
    }
    const posts = this.props.posts;
    const Posts = () =>
      posts.map((post) => (
        <Photo
          src="images/nature.jpg"
          onClick={() => {
            this.displayModalPost(post);
          }}
        />
      ));
    return (
      <Layout>
        {this.state.showPostModal ? (
          <PostModal
            show={this.state.showPostModal}
            postId={this.state.postId}
            personPhoto="images/download.jfif"
            onShowChange={this.displayModalPost.bind(this)}
          />
        ) : null}
        <Grid>
          <Posts />
        </Grid>
      </Layout>
    );
  }

  displayModalPost(post) {
    debugger;
    if (post != undefined) {
      this.setState({
        postId: post.id,
      });
    }
    this.setState({
      showPostModal: !this.state.showPostModal,
    });
  }
}

const mapStateToProps = (state) => ({ posts: state.posts });

export default compose(
  withRouter,
  connect(mapStateToProps, { getPostsByHashTag })
)(Explore);
