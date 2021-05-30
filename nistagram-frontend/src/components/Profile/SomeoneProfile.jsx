import React, { Component } from "react";
import {
  Grid,
  Photo,
  GridControlBar,
  GridControlBarItem,
} from "react-instagram-ui-kit";
import OptionsButton from "./OptionsButton";
import PostModal from "./PostModal";
import ProfileHeader from "./ProfileHeader";
import { getPostsByUserId } from "../../actions/actions";
import { connect } from "react-redux";

class SomeoneProfile extends Component {
  state = {
    showPostModal: false,
    posts: [],
  };

  componentDidMount() {
    debugger;
    this.props.getPostsByUserId("12345678-1234-1234-1234-123456789123");
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
      <div>
        {this.state.showPostModal ? (
          <PostModal
            show={this.state.showPostModal}
            post="images/nature.jpg"
            personPhoto="images/download.jfif"
            person="angusyoung"
            onShowChange={this.displayModalPost.bind(this)}
          />
        ) : null}
        <OptionsButton />
        <ProfileHeader />
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

  displayModalPost() {
    debugger;
    this.setState({
      showPostModal: !this.state.showPostModal,
    });
  }
}

const mapStateToProps = (state) => ({ posts: state.posts });

export default connect(mapStateToProps, { getPostsByUserId })(SomeoneProfile);
