import React, { Component } from "react";
import { Modal, ModalHeader, ModalBody, ModalFooter } from "reactstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import Checkbox from "@material-ui/core/Checkbox";
import Favorite from "@material-ui/icons/Favorite";
import FavoriteBorder from "@material-ui/icons/FavoriteBorder";
import moment from "moment";
import { getPost } from "../../actions/actions";
import { connect } from "react-redux";
import TaggedUsersModal from "./TaggedUsersModal";

class PostModal extends Component {
  state = {
    showPostModal: this.props.show,
    showTaggedModal: false,
  };

  componentDidMount() {
    debugger;
    this.props.getPost(this.props.postId);
  }

  render() {
    if (this.props.post == undefined) {
      return null;
    }
    const post = this.props.post;
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
          {this.state.showTaggedModal ? (
            <TaggedUsersModal
              show={this.state.showTaggedModal}
              postId={post.id}
              onShowChange={this.displayModalPost.bind(this)}
            />
          ) : null}
          <img
            src={this.props.personPhoto}
            style={{ width: 32, height: 32, borderRadius: 50 }}
          />
          <span style={{ width: 15, display: "inline-block" }}></span>
          {this.props.person}
        </ModalHeader>
        <ModalBody>
          <div>
            <img
              onClick={() => {
                this.displayModalPost();
              }}
              src="images/nature.jpg"
              style={{ width: 800, height: 320 }}
              className="mb-3"
            />
            {post.hashTags.map((hashTag) => (
              <div>{hashTag.hashTagText}</div>
            ))}
            {post.description}
            <br />
            {moment(post.timeStamp).format("DD/MM/YYYY HH:mm")}
            {Object.entries(post.location).length !== 0
              ? ", " +
                post.location.street +
                " " +
                post.location.cityName +
                ", " +
                post.location.country
              : ""}
            <a style={{ float: "right" }} className="mr-4" href="javascript:;">
              Report
            </a>
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
            Likes:{" "}
            <a href="javascript:;" className="mr-2">
              {post.likes.length}
            </a>
            Dislikes: <a href="javascript:;">{post.dislikes.length}</a> <br />
            <hr />
            {post.comments.map((comment) => (
              <div>
                <img src="images/user.png" /> {comment.commentText}
                <br />
                <hr />
              </div>
            ))}
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

  displayModalPost() {
    debugger;
    this.setState({
      showTaggedModal: !this.state.showTaggedModal,
    });
  }
}

const mapStateToProps = (state) => ({ post: state.post });

export default connect(mapStateToProps, { getPost })(PostModal);
