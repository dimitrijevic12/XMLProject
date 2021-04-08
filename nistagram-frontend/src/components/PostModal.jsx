import React, { Component } from "react";
import { Modal, ModalHeader, ModalBody, ModalFooter } from "reactstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import Checkbox from "@material-ui/core/Checkbox";
import Favorite from "@material-ui/icons/Favorite";
import FavoriteBorder from "@material-ui/icons/FavoriteBorder";

class PostModal extends Component {
  state = {
    showPostModal: this.props.show,
  };
  render() {
    debugger;
    console.log(this.props.post);
    return (
      <Modal
        style={{
          maxWidth: "850px",
          width: "849px",
        }}
        isOpen={this.state.showPostModal}
        centered={true}
      >
        <ModalHeader toggle={this.toggle.bind(this)}>
          <img
            src={this.props.personPhoto}
            style={{ width: 32, height: 32, borderRadius: 50 }}
          />
          <span style={{ width: 15, display: "inline-block" }}></span>
          {this.props.person}
        </ModalHeader>
        <ModalBody>
          <div>
            <img src={this.props.post} style={{ width: 800, height: 320 }} />
            September 29, 2020
            <br />
            <br />
            <FormControlLabel
              style={{ width: 24, height: 24 }}
              control={
                <Checkbox
                  icon={<FavoriteBorder />}
                  checkedIcon={<Favorite />}
                  name="checkedH"
                />
              }
            />
            <img src="images/chat.png" />
            <span style={{ width: 15, display: "inline-block" }}></span>
            <img src="images/send.png" />
            <br />
            <br />
            Likes: <a href="javascript:;">61</a> <br />
            <hr />
            <img src="images/user.png" /> Nice photo great eye
            <br />
            <hr />
            <div style={{ float: "left" }}>
              <input
                style={{ border: 0 }}
                type="text"
                placeholder="Add a comment..."
              />
            </div>
            <div style={{ float: "right" }}>
              <a href="javascript:;"> Post </a>
            </div>
          </div>
        </ModalBody>
        <ModalFooter></ModalFooter>
      </Modal>
    );
  }

  toggle() {
    debugger;
    this.setState({ showPostModal: false });
    this.props.onShowChange();
  }
}

export default PostModal;
