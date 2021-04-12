import React, { Component } from "react";
import { Modal, ModalHeader, ModalBody, ModalFooter } from "reactstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import { Height } from "@material-ui/icons";

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
            <label style={{ color: "red" }}>Block this user</label>
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
            <label style={{ color: "red" }}>Mute this user</label>
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
            <label style={{ color: "red" }}>Report this user</label>
          </button>
          <hr />
        </ModalBody>
      </Modal>
    );
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

export default OptionsModal;
