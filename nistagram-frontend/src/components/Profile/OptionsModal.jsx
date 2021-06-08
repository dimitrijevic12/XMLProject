import React, { Component } from "react";
import { Modal, ModalHeader, ModalBody, ModalFooter } from "reactstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import { connect } from "react-redux";
import { addCloseFriendStory } from "../../actions/actionsStory";
import { addCloseFriend } from "../../actions/actionsUser";

class OptionsModal extends Component {
  state = {
    showOptionsModal: this.props.show,
  };

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
          {this.displayCloseFriendButton()}
        </ModalBody>
      </Modal>
    );
  }

  displayCloseFriendButton() {
    var display = true;
    var follower = false;
    debugger;
    for (var i = 0; i < this.props.user.closeFriendTo.length; i++) {
      if (
        this.props.user.closeFriendTo[i].id === sessionStorage.getItem("userId")
      ) {
        display = false;
        break;
      }
    }
    for (var i = 0; i < this.props.user.closeFriendTo.length; i++) {
      if (
        this.props.user.closeFriendTo[i].id === sessionStorage.getItem("userId")
      ) {
        follower = true;
        break;
      }
    }
    if (display && follower) {
      return (
        <button
          style={{
            height: "100%",
            width: "100%",
            alignSelf: "stretch",
            float: "center",
          }}
          className="btn btn-block btn-md mb-2"
          onClick={() => this.addCloseFriend()}
        >
          Add to Close friends
        </button>
      );
    } else {
      return "";
    }
  }

  async addCloseFriend() {
    await this.props.addCloseFriendStory(this.props.user.id);
    await this.props.addCloseFriend(this.props.user.id);
    debugger;
    window.location = "/profile/" + this.props.user.id;
  }

  mute() {
    alert("mute");
  }

  toggle() {
    debugger;
    this.setState({ showOptionsModal: false });
    this.props.onShowChange();
  }
}

const mapStateToProps = () => {};

export default connect(mapStateToProps, {
  addCloseFriendStory,
  addCloseFriend,
})(OptionsModal);
