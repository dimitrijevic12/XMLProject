import React, { Component } from "react";
import { Profile } from "react-instagram-ui-kit";

class ProfileHeader extends Component {
  state = {};
  render() {
    return (
      <Profile
        bio={`
        Lead guitarist of AC⚡DC
      `}
        pictureSrc="images/download.jfif"
        username="angusyoung"
        followersData={[5, 3000000, 55]}
        fullname="Angus Young"
      />
    );
  }
}

export default ProfileHeader;
