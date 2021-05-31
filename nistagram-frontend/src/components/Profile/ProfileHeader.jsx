import React, { Component } from "react";
import { Profile } from "react-instagram-ui-kit";

class ProfileHeader extends Component {
  state = {
    user: this.props.user,
    postsCount: this.props.postsCount,
  };
  render() {
    return (
      <Profile
        bio={`
        Lead guitarist of AC⚡DC
      `}
        pictureSrc="images/download.jfif"
        username={this.state.user.username}
        followersData={[
          this.state.postsCount,
          this.state.user.followers.length,
          this.state.user.following.length,
        ]}
        fullname={this.state.user.firstName + " " + this.state.user.lastName}
      />
    );
  }
}

export default ProfileHeader;
