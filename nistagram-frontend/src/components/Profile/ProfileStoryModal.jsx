import React, { useEffect, useState } from "react";
import Stories from "react-insta-stories";
import { Modal, ModalBody } from "reactstrap";
import {
  getStoriesForModal,
  loadImagesStory,
} from "../../actions/actionsStory";
import { connect } from "react-redux";
import "../../css/story.css";
import TaggedUsersProfileStoryModal from "./TaggedUsersProfileStoryModal";
import CollectionsModal from "./CollectionsModal";

function ProfileStoryModal(props) {
  const [showProfileStoryModal, setShowProfileStoryModal] = useState(
    props.show
  );
  const [showTaggedUsersModal, setShowTaggedUsersModal] = useState(false);
  const [showCollectionsModal, setShowCollectionsModal] = useState(false);
  const [users, setUsers] = useState([]);
  const [story, setStory] = useState({});
  var tempStories = [];

  const timeSince = (date) => {
    var correctDate = new Date(Date.parse(date));
    var seconds = Math.floor(
      (new Date() - new Date(Date.parse(correctDate))) / 1000
    );

    var interval = seconds / 31536000;

    if (interval > 1) {
      return Math.floor(interval) + " years";
    }
    interval = seconds / 2592000;
    if (interval > 1) {
      return Math.floor(interval) + " months";
    }
    interval = seconds / 86400;
    if (interval > 1) {
      return Math.floor(interval) + " days";
    }
    interval = seconds / 3600;
    if (interval > 1) {
      return Math.floor(interval) + " hours";
    }
    interval = seconds / 60;
    if (interval > 1) {
      return Math.floor(interval) + " minutes";
    }
    return Math.floor(seconds) + " seconds";
  };

  const convertHashtagsToString = (hashtags) => {
    debugger;
    var temp = [...hashtags];
    var text = temp[0];
    temp.shift();
    temp.forEach((element) => {
      text += " " + element;
    });
    return text;
  };

  const createImagesList = () => {
    var images = [];
    props.stories.forEach((element) => {
      images.push(element.contentPath);
    });
    return images;
  };

  const toggle = () => {
    debugger;
    setShowProfileStoryModal(false);
    props.onShowChange();
  };

  const displayModalStory = (users) => {
    debugger;
    setShowTaggedUsersModal(!showTaggedUsersModal);
    setUsers(users);
  };

  const displayCollectionsModal = (story) => {
    debugger;
    setShowCollectionsModal(!showCollectionsModal);
    setStory(story);
  };

  useEffect(() => {
    debugger;
    props.loadImagesStory(createImagesList(props.stories));
  }, [props.stories]);

  useEffect(() => {
    debugger;
    props.loadImagesStory(createImagesList(props.stories));
    tempStories = props.images;
  }, [props.highlight]);

  if (
    props.stories === undefined ||
    props.images === undefined ||
    props.stories.length !== props.images.length
  )
    return null;
  debugger;
  const stories = [];
  props.stories.forEach((story, i) => {
    stories.push({
      url:
        props.images[i].contentType === "image/jpeg"
          ? "data:image/jpg;base64," + props.images[i].fileContents
          : "data:video/mp4;base64," + props.images[i].fileContents,
      duration: 1000 * story.duration,
      type: props.images[i].contentType !== "image/jpeg" ? "video" : "image",
      header: {
        heading:
          story.registeredUser.firstName + " " + story.registeredUser.lastName,
        subheading: `Posted ${timeSince(story.timeStamp)} ago`,
      },
      seeMore: ({ close }) => {
        return (
          <div>
            <div
              onClick={close}
              style={{
                bottom: 0,
                position: "absolute",
                zIndex: 10,
                width: "100%",
                backgroundColor: "black",
                opacity: "50%",
                color: "white",
                height: "300px",
              }}
            ></div>
            <div className="story-footer-description">{story.description}</div>
            <div className="story-footer-hashtag">
              {convertHashtagsToString(story.hashTags)}
            </div>
            <div className="story-footer-tagged">
              <button
                className="btn btn-sm btn-primary"
                onClick={() => displayModalStory(story.taggedUsers)}
              >
                Tagged users:
              </button>
            </div>
            <div className="story-footer-collections">
              {props.isActiveStories ? (
                <button
                  className="btn btn-sm btn-primary"
                  onClick={() => displayCollectionsModal(story)}
                >
                  Add to collection:
                </button>
              ) : null}
            </div>
          </div>
        );
      },
    });
  });
  return (
    <Modal
      style={{
        maxWidth: "450px",
        width: "450px",
        maxHeight: "700px",
        width: "700px",
        borderRadius: "15px",
      }}
      className="text-center"
      isOpen={showProfileStoryModal}
      toggle={toggle}
      centered={true}
      backdropClassName="story-modal-backdrop"
    >
      {showTaggedUsersModal ? (
        <TaggedUsersProfileStoryModal
          show={showTaggedUsersModal}
          taggedUsers={users}
          onShowChange={displayModalStory}
        />
      ) : null}
      {showCollectionsModal ? (
        <CollectionsModal
          show={showCollectionsModal}
          highlights={props.highlights}
          story={story}
          onShowChange={displayCollectionsModal}
        />
      ) : null}
      <ModalBody
        className="story-modal-body"
        style={{ padding: "2px !important" }}
      >
        <Stories
          keyboardNavigation
          width="100%"
          height="670px"
          stories={stories}
          onAllStoriesEnd={(s, st) => toggle()}
          storyStyles={{ height: "670px" }}
        />
      </ModalBody>
    </Modal>
  );
}

const mapStateToProps = (state) => ({
  images: state.storyImages,
  allImages: state.allStoriesImages,
});

export default connect(mapStateToProps, {
  getStoriesForModal,
  loadImagesStory,
})(ProfileStoryModal);
