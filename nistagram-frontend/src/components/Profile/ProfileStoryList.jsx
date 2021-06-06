import React, { Component } from "react";
import "./ProfileStoryCircle.css";
import ProfileStory from "./ProfileStory";
import { connect } from "react-redux";
import { loadProfileImagesStory } from "../../actions/actionsStory";

class ProfileProfileStoryList extends Component {
  state = {};

  componentDidMount() {
    debugger;
    this.props.loadProfileImagesStory(
      this.createImagesList(this.props.highlights)
    );
  }

  render() {
    debugger;
    if (
      this.props.profileImages === undefined ||
      this.props.highlights === undefined
    )
      return null;
    return (
      <div className="story-wrapper">
        {
          <ProfileStory
            user={this.props.user}
            first={true}
            activeStories={this.props.activeStories}
            profileImage={this.props.profileImages[0]}
            highlights={this.props.highlights}
            i={0}
          />
        }
        {this.props.highlights.map((highlight, i) => (
          <ProfileStory
            profileImage={this.props.profileImages[i + 1]}
            highlight={highlight}
            first={false}
          />
        ))}
      </div>
    );
  }

  createImagesList() {
    debugger;
    var images = [];
    images.push(this.props.activeStories[0].contentPath);
    this.props.highlights.forEach((element) => {
      images.push(element.stories[0].contentPath);
    });
    return images;
  }
}

const mapStateToProps = (state) => ({
  profileImages: state.storyProfileImages,
});

export default connect(mapStateToProps, { loadProfileImagesStory })(
  ProfileProfileStoryList
);
