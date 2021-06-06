import React, { Component } from "react";
import { Profile } from "react-instagram-ui-kit";
import { getUserById } from "../../actions/actionsUser";
import { connect } from "react-redux";

class ProfileHeader extends Component {
  state = {
    user: this.props.user,
    postsCount: this.props.postsCount,
  };

  render() {
    if (this.props.user === undefined) return null;
    return (
      <Profile
        bio={this.props.user.bio}
        pictureSrc="/images/download.jfif"
        username={this.props.user.username}
        followersData={[
          this.state.postsCount,
          this.props.user.followers === undefined
            ? 0
            : this.props.user.followers.length,
          this.props.user.following === undefined
            ? 0
            : this.props.user.following.length,
        ]}
        fullname={this.props.user.firstName + " " + this.props.user.lastName}
      />
    );
  }
}

export default ProfileHeader;
