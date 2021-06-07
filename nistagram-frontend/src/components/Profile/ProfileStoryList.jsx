import React, { useEffect, useState } from "react";
import "./ProfileStoryCircle.css";
import ProfileStory from "./ProfileStory";
import { connect } from "react-redux";
import { loadProfileImagesStory } from "../../actions/actionsStory";

function ProfileProfileStoryList(props) {
  useEffect(() => {
    props.loadProfileImagesStory(createImagesList(props.highlights));
  }, props.highlights);

  const createImagesList = () => {
    var images = [];
    if (props.activeStories[0] === undefined) return images;
    images.push(props.activeStories[0].contentPath);
    props.highlights.forEach((element) => {
      images.push(element.stories[0].contentPath);
    });
    return images;
  };

  if (props.profileImages === undefined || props.highlights === undefined)
    return null;
  debugger;
  if (props.profileImages.length - 1 !== props.highlights.length) return null;
  return (
    <div className="story-wrapper">
      {props.activeStories === undefined ? null : (
        <ProfileStory
          user={props.user}
          first={true}
          activeStories={props.activeStories}
          profileImage={props.profileImages[0].fileContents}
          highlights={props.highlights}
          i={0}
        />
      )}

      {props.highlights.map((highlight, i) => (
        <ProfileStory
          profileImage={props.profileImages[i + 1].fileContents}
          highlight={highlight}
          first={false}
        />
      ))}
    </div>
  );
}

const mapStateToProps = (state) => ({
  profileImages: state.storyProfileImages,
});

export default connect(mapStateToProps, { loadProfileImagesStory })(
  ProfileProfileStoryList
);
