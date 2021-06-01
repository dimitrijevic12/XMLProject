import React, { Component } from "react";
import { Modal, ModalHeader, ModalBody, ModalFooter } from "reactstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import Checkbox from "@material-ui/core/Checkbox";
import Favorite from "@material-ui/icons/Favorite";
import FavoriteBorder from "@material-ui/icons/FavoriteBorder";
import moment from "moment";
import {
  getPost,
  loadImage,
  likePost,
  dislikePost,
  commentPost,
} from "../../actions/actions";
import { connect } from "react-redux";
import TaggedUsersModal from "./TaggedUsersModal";

class PostModal extends Component {
  state = {
    showPostModal: this.props.show,
    showTaggedModal: false,
    likesCount: 0,
    dislikesCount: 0,
    liked: false,
    disliked: false,
    commentText: "",
    comments: [],
  };

  async componentDidMount() {
    debugger;
    await this.props.getPost(this.props.postId);
    this.setState({
      likesCount: this.props.post.likes.length,
      dislikesCount: this.props.post.dislikes.length,
      comments: this.props.post.comments,
    });
  }

  render() {
    if (this.props.post == undefined || this.props.loadImage == undefined) {
      return null;
    }
    const post = this.props.post;
    const loadedImage = this.props.loadedImage;
    debugger;
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
            src={"data:image/jpg;base64," + loadedImage}
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
              src={"data:image/jpg;base64," + loadedImage}
              style={{ width: 800, height: 320 }}
              className="mb-3"
            />
            <div>
              {post.hashTags.map((hashTag) => hashTag.hashTagText + " ")}
            </div>
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
                  onClick={() => {
                    this.likePost();
                  }}
                  icon={<FavoriteBorder />}
                  checkedIcon={<Favorite />}
                  name="checkedH"
                />
              }
            />
            <img
              style={{ width: 24, height: 24 }}
              onClick={() => {
                this.dislikePost();
              }}
              src="images/dislike.png"
            />
            <span style={{ width: 15, display: "inline-block" }}></span>
            <img src="images/chat.png" />
            <span style={{ width: 15, display: "inline-block" }}></span>
            <img src="images/send.png" />
            <br />
            <br />
            Likes:{" "}
            <a href="javascript:;" className="mr-2">
              {this.state.likesCount}
            </a>
            Dislikes: <a href="javascript:;">{this.state.dislikesCount}</a>{" "}
            <br />
            <hr />
            {this.state.comments.map((comment) => (
              <div>
                <img src="images/user.png" /> {comment.commentText}
                <br />
                <hr />
              </div>
            ))}
            <div style={{ float: "left" }}>
              <input
                name="commentText"
                value={this.state.commentText}
                onChange={this.handleChange}
                style={{ border: 0 }}
                type="text"
                placeholder="Add a comment..."
              />
            </div>
            <div style={{ float: "right" }}>
              <a
                onClick={() => {
                  this.commentPost();
                }}
                href=""
              >
                {" "}
                Post{" "}
              </a>
            </div>
          </div>
        </ModalBody>
        <ModalFooter></ModalFooter>
      </Modal>
    );
  }

  handleChange = (event) => {
    debugger;
    const { name, value, type, checked } = event.target;
    type === "checkbox"
      ? this.setState({
          [name]: checked,
        })
      : this.setState({
          [name]: value,
        });
  };

  async likePost() {
    debugger;
    if (this.state.liked == false) {
      this.setState((prevState) => {
        return { likesCount: prevState.likesCount + 1 };
      });
    } else {
      this.setState((prevState) => {
        return { likesCount: prevState.likesCount - 1 };
      });
    }

    await this.props.likePost({
      id: this.props.post.id,
      userId: "12345678-1234-1234-1234-123456789123",
    });
    this.setState({
      liked: !this.state.liked,
    });
  }

  async dislikePost() {
    debugger;
    if (this.state.disliked == false) {
      this.setState((prevState) => {
        return { dislikesCount: prevState.dislikesCount + 1 };
      });
    } else {
      this.setState((prevState) => {
        return { dislikesCount: prevState.dislikesCount - 1 };
      });
    }

    await this.props.dislikePost({
      id: this.props.post.id,
      userId: "12345678-1234-1234-1234-123456789123",
    });
    this.setState({
      disliked: !this.state.disliked,
    });
  }

  async commentPost() {
    const comment = {
      CommentText: this.state.commentText,
      RegisteredUser: { id: "12345678-1234-1234-1234-123456789123" },
    };
    debugger;
    await this.props.commentPost({ id: this.props.post.id, comment: comment });
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

const mapStateToProps = (state) => ({
  post: state.post,
  loadedImage: state.loadedImage,
});

export default connect(mapStateToProps, {
  getPost,
  loadImage,
  likePost,
  dislikePost,
  commentPost,
})(PostModal);
