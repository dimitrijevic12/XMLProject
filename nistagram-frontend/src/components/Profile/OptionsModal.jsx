import React, { Component } from "react";
import { Modal, ModalHeader, ModalBody, ModalFooter } from "reactstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import { Height } from "@material-ui/icons";
import ProfileStoryModal from "./ProfileStoryModal";
import { connect } from "react-redux";
import { loadImagesForArchive } from "../../actions/actionsStory";

class OptionsModal extends Component {
  state = {
    showOptionsModal: this.props.show,
    showProfileStoryModal: false,
    user: "",
  };

  async componentDidMount() {
    this.props.loadImagesForArchive(
      this.createImagesList(this.props.allStories)
    );
  }

  render() {
    return (
      <Modal
        style={{
          maxWidth: "450px",
          width: "449px",
        }}
        isOpen={this.state.showOptionsModal}
        centered={true}
      >
        {this.state.showProfileStoryModal ? (
          <ProfileStoryModal
            show={this.state.showProfileStoryModal}
            onShowChange={this.displayModalProfileStory.bind(this)}
            user={this.state.user}
            profileImage={this.props.profileImage}
            isActiveStories={true}
            isArchive={true}
            highlights={this.props.highlights}
            stories={this.props.allStories}
          />
        ) : null}
        <ModalHeader toggle={this.toggle.bind(this)}></ModalHeader>
        <ModalBody>
          <button
            style={{
              height: "100%",
              width: "100%",
              alignSelf: "stretch",
              float: "center",
            }}
            className="btn btn-block btn-md mb-2"
          >
            <label>Block this user</label>
          </button>
          <hr />
          <button
            onClick={() => this.mute()}
            style={{
              height: "100%",
              width: "100%",
              alignSelf: "stretch",
              float: "center",
            }}
            className="btn btn-block btn-md mb-2"
          >
            <label>Mute this user</label>
          </button>
          <hr />
          <button
            style={{
              height: "100%",
              width: "100%",
              alignSelf: "stretch",
              float: "center",
            }}
            className="btn btn-block btn-md mb-2"
          >
            <label>Report this user</label>
          </button>
          <hr />
          <button
            style={{
              height: "100%",
              width: "100%",
              alignSelf: "stretch",
              float: "center",
            }}
            className="btn btn-block btn-md mb-2"
            onClick={() =>
              this.displayModalProfileStory(sessionStorage.getItem("userId"))
            }
          >
            <label>Story archive</label>
          </button>
          <hr />
          <button
            style={{
              height: "100%",
              width: "100%",
              alignSelf: "stretch",
              float: "center",
            }}
            className="btn btn-block btn-md mb-2"
          >
            <label>Add user to close friends</label>
          </button>
          <hr />
        </ModalBody>
      </Modal>
    );
  }

  createImagesList() {
    debugger;
    var images = [];
    this.props.allStories.forEach((element) => {
      images.push(element.contentPath);
    });
    return images;
  }

  mute() {
    alert("mute");
  }

  displayModalProfileStory(userid) {
    this.setState({
      showProfileStoryModal: !this.state.showProfileStoryModal,
      user: userid,
    });
  }

  toggle() {
    debugger;
    this.setState({ showOptionsModal: false });
    this.props.onShowChange();
  }
}

const mapStateToProps = (state) => ({
  allStories: state.allStories,
});

export default connect(mapStateToProps, { loadImagesForArchive })(OptionsModal);
