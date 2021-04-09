import React, { Component } from "react";
import Stories from "react-insta-stories";
import { Modal, ModalBody } from "reactstrap";

class StoryModal extends Component {
  state = {
    showStoryModal: this.props.show,
  };
  render() {
    const photos = [
      "images/nature.jpg",
      "images/sample1.jpeg",
      "images/sample2.jpg",
    ];
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
        isOpen={this.state.showStoryModal}
        toggle={this.toggle.bind(this)}
        centered={true}
        backdropClassName="story-modal-backdrop"
      >
        <ModalBody
          className="story-modal-body"
          style={{ padding: "2px !important" }}
        >
          <Stories
            loop
            keyboardNavigation
            width={"100%"}
            height={"700px"}
            defaultInterval={8000}
            stories={photos}
            onStoryEnd={(s, st) => console.log("story ended", s, st)}
            onAllStoriesEnd={(s, st) => console.log("all stories ended", s, st)}
            onStoryStart={(s, st) => console.log("story started", s, st)}
          />
        </ModalBody>
      </Modal>
    );
  }

  toggle() {
    debugger;
    this.setState({ showPostModal: false });
    this.props.onShowChange();
  }
}

export default StoryModal;
