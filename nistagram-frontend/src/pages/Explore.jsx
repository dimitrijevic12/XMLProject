import React, { Component } from "react";
import Layout from "../layouts/Layout";
import {
  Grid,
  Photo,
  GridControlBar,
  GridControlBarItem,
} from "react-instagram-ui-kit";
import { getPostsByHashTag } from "../actions/actions";
import { connect } from "react-redux";
import { compose } from "redux";
import { withRouter } from "react-router-dom";

class Explore extends Component {
  state = {};

  componentDidMount() {
    debugger;
    this.props.getPostsByHashTag(this.props.location.state.searchObject.value);
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
            this.displayModalPost();
          }}
        />
      ));
    return (
      <Layout>
        <Grid>
          <Posts />
        </Grid>
      </Layout>
    );
  }
}

const mapStateToProps = (state) => ({ posts: state.posts });

export default compose(
  withRouter,
  connect(mapStateToProps, { getPostsByHashTag })
)(Explore);
