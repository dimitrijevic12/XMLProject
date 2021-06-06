import React, { Component } from "react";
import { Modal, ModalHeader, ModalBody, ModalFooter } from "reactstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import { withRouter } from "react-router-dom";
import { compose } from "redux";
import { connect } from "react-redux";

class MyOptionsModal extends Component {
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
            onClick={() => this.collections()}
            style={{
              height: "100%",
              width: "100%",
              alignSelf: "stretch",
              float: "center",
            }}
            className="btn btn-block btn-md mb-2"
          >
            <label>Collections</label>
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
            <label>Archive</label>
          </button>
          <hr />
          <button
            onClick={() => this.edit()}
            style={{
              height: "100%",
              width: "100%",
              alignSelf: "stretch",
              float: "center",
            }}
            className="btn btn-block btn-md mb-2"
          >
            <label>Change profile picture</label>
          </button>
          <hr />
        </ModalBody>
      </Modal>
    );
  }

  collections() {
    this.props.history.replace({
      pathname: "/collections",
    });
  }

  edit() {
    this.props.history.replace({
      pathname: "/change-profile-picture",
    });
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

export default compose(withRouter)(MyOptionsModal);
