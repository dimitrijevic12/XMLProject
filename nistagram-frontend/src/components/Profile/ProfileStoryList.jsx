import React, { Component } from "react";
import "./ProfileStoryCircle.css";
import ProfileStory from "./ProfileStory";
import { connect } from "react-redux";
import { loadProfileImagesStory } from "../../actions/actionsStory";

class ProfileProfileStoryList extends Component {
  state = {};

  componentDidMount() {
    this.props.loadProfileImagesStory(this.createImagesList(this.props.items));
  }

  render() {
    debugger;
    if (this.props.profileImages === undefined) return null;
    return (
      <div className="story-wrapper">
        <ProfileStory first={true} item={{}} i={0} />
        {this.props.items.map((item, i) => (
          <ProfileStory
            profileImage={this.props.profileImages[i]}
            item={item}
            first={false}
          />
        ))}
      </div>
    );
  }

  createImagesList() {
    var images = [];
    this.props.items.forEach((element) => {
      images.push(element.profilePicturePath);
    });
    return images;
  }
}

const mapStateToProps = (state) => ({
  profileImages: state.ProfilestoryProfileImages,
});

export default connect(mapStateToProps, { loadProfileImagesStory })(
  ProfileProfileStoryList
);
