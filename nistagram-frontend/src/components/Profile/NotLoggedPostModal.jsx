import React, { Component } from "react";
import { Modal, ModalHeader, ModalBody, ModalFooter } from "reactstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import moment from "moment";
import { Slide } from "react-slideshow-image";
import "react-slideshow-image/dist/styles.css";
import {
  getPost,
  loadImage,
  likePost,
  dislikePost,
  commentPost,
  loadImages,
  getAllImagesForProfile,
} from "../../actions/actions";
import { loadImageProfile } from "../../actions/actionsUser";
import { connect } from "react-redux";
import TaggedUsersModal from "./TaggedUsersModal";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { createNotification } from "../../actions/actionsNotification";

class NotLoggedPostModal extends Component {
  state = {
    showNotLoggedPostModal: this.props.show,
    showTaggedModal: false,
    showChooseCollectionModal: false,
    showReportModal: false,
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
    await this.props.loadImageProfile(this.props.personPhoto);
    this.setState({
      likesCount: this.props.post.likes.length,
      dislikesCount: this.props.post.dislikes.length,
      comments: this.props.post.comments,
    });
    if (this.props.posts !== undefined) this.getAllImages(this.props.posts);
  }

  render() {
    if (this.props.post == undefined) {
      return null;
    }
    if (
      this.props.post.contentPath == undefined &&
      this.props.loadedImages == undefined
    ) {
      return null;
    }
    if (
      this.props.post.contentPaths == undefined &&
      this.props.loadedImage == undefined
    ) {
      return null;
    }
    debugger;
    var profileImage = "/images/user.png";
    if (this.props.profileImage !== undefined) {
      profileImage = this.props.profileImage;
    }
    const post = this.props.post;
    const loadedImage = this.props.loadedImage;
    const loadedImages = this.props.loadedImages;
    return (
      <Modal
        style={{
          maxWidth: "850px",
          width: "849px",
        }}
        isOpen={this.state.showNotLoggedPostModal}
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
          {profileImage === "/images/user.png" ? (
            <img
              src={profileImage}
              style={{ width: 32, height: 32, borderRadius: 50 }}
            />
          ) : (
            <img
              src={"data:image/jpg;base64," + profileImage}
              style={{ width: 32, height: 32, borderRadius: 50 }}
            />
          )}

          <span style={{ width: 15, display: "inline-block" }}></span>
          {this.props.person}
        </ModalHeader>
        <ModalBody>
          <div>
            {post.contentPath == undefined ? (
              <Slide easing="ease">
                {loadedImages.map((f, i) =>
                  loadedImages[i].contentType === "image/jpeg" ? (
                    <div className="each-slide">
                      <img
                        onClick={() => {
                          this.displayModalPost();
                        }}
                        src={
                          loadedImages[i].contentType === "image/jpeg"
                            ? "data:image/jpg;base64," +
                              loadedImages[i].fileContents
                            : "data:video/mp4;base64," +
                              loadedImages[i].fileContents
                        }
                        style={{ width: 800, height: 320 }}
                        className="mb-3"
                      />
                    </div>
                  ) : (
                    <div className="each-slide">
                      <video
                        controls
                        onClick={() => {
                          this.displayModalPost();
                        }}
                        style={{ width: 800, height: 320 }}
                        className="mb-3"
                      >
                        <source
                          src={
                            "data:video/mp4;base64," +
                            loadedImages[i].fileContents
                          }
                          type="video/mp4"
                        ></source>
                      </video>
                    </div>
                  )
                )}
              </Slide>
            ) : loadedImage.contentType === "image/jpeg" ? (
              <img
                onClick={() => {
                  this.displayModalPost();
                }}
                src={"data:image/jpg;base64," + loadedImage.fileContents}
                style={{ width: 800, height: 320 }}
                className="mb-3"
              />
            ) : (
              <video
                controls
                onClick={() => {
                  this.displayModalPost();
                }}
                style={{ width: 800, height: 320 }}
                className="mb-3"
              >
                <source
                  src={"data:video/mp4;base64," + loadedImage.fileContents}
                  type="video/mp4"
                ></source>
              </video>
            )}
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
            <br />
            <br />
            <br />
            <br />
            Likes:{" "}
            <a href="javascript:;" className="mr-2">
              {this.state.likesCount}
            </a>
            Dislikes: <a href="javascript:;">{this.state.dislikesCount}</a>{" "}
            <br />
            <hr />
            <div style={{ overflow: "scroll" }}>
              {this.state.comments.map((comment) => (
                <div>
                  <img src="/images/user.png" />{" "}
                  {comment.registeredUser.username + ": " + comment.commentText}
                  <br />
                  <hr />
                </div>
              ))}
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
      userId: sessionStorage.getItem("userId"),
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
      userId: sessionStorage.getItem("userId"),
    });
    this.setState({
      disliked: !this.state.disliked,
    });
  }

  async commentPost() {
    this.sendNotification();
    const comment = {
      CommentText: this.state.commentText,
      RegisteredUser: { id: sessionStorage.getItem("userId") },
    };
    debugger;
    await this.props.commentPost({ id: this.props.post.id, comment: comment });
    toast.configure();
    toast.success("Commented successfully!", {
      position: toast.POSITION.TOP_RIGHT,
    });
  }

  sendNotification() {
    debugger;
    this.props.createNotification({
      Type: "Comment",
      ContentId: "12345678-1234-1234-1234-123456789123",
      RegisteredUser: { id: sessionStorage.getItem("userId") },
    });
  }

  toggle() {
    debugger;
    this.setState({ showNotLoggedPostModal: false });
    this.props.onShowChange();
  }

  displayModalPost() {
    debugger;
    this.setState({
      showTaggedModal: !this.state.showTaggedModal,
    });
  }

  displayModalReport() {
    debugger;
    this.setState({
      showReportModal: !this.state.showReportModal,
    });
  }

  displayModalCollection() {
    debugger;
    this.setState({
      showChooseCollectionModal: !this.state.showChooseCollectionModal,
    });
  }
}

const mapStateToProps = (state) => ({
  post: state.post,
  loadedImage: state.loadedImage,
  loadedImages: state.loadedImages,
  profileImage: state.profileImage,
  commentId: state.commentId,
  profileImages: state.profileImages,
});

export default connect(mapStateToProps, {
  getPost,
  loadImage,
  likePost,
  dislikePost,
  commentPost,
  loadImages,
  loadImageProfile,
  createNotification,
  getAllImagesForProfile,
})(NotLoggedPostModal);
