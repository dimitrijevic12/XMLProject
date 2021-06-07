import React, { Component } from "react";
import StoryCard from "../components/Story/StoryCard";
import Layout from "../layouts/Layout";
import InfiniteScroll from "react-infinite-scroll-component";
import { Card, CardBody, CardHeader } from "reactstrap";
import { Checkbox, FormControlLabel } from "@material-ui/core";
import { Favorite, FavoriteBorder } from "@material-ui/icons";
import { getFollowing } from "../actions/actionsUser";
import { withRouter } from "react-router-dom";
import { compose } from "redux";
import { connect } from "react-redux";
import {
  getPostsForFollowing,
  getAllImages,
  likePost,
  dislikePost,
  commentPost,
} from "../actions/actions";
import { getStories } from "../actions/actionsStory";
import moment from "moment";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import ChooseCollectionModal from "../components/Collection/ChooseCollectionModal";
import TaggedUsersModal from "../components/Profile/TaggedUsersModal";

const style = {
  height: 30,
  border: "1px solid green",
  margin: 6,
  padding: 8,
};

class HomePage extends Component {
  state = {
    items: Array.from({ length: 10 }),
    comments: [],
    showTaggedModal: false,
    showChooseCollectionModal: false,
    liked: false,
    disliked: false,
    post: {},
  };

  async componentDidMount() {
    debugger;
    await this.props.getFollowing();
    await this.props.getPostsForFollowing(this.props.following);
    await this.props.getStories();
    var posts = [...this.props.posts];
    posts.sort(function compare(a, b) {
      var dateA = new Date(a.timeStamp);
      var dateB = new Date(b.timeStamp);
      return dateB - dateA;
    });
    await this.getAllImages(posts);
  }
  render() {
    if (this.props.following === undefined) {
      return null;
    }
    if (this.props.posts === undefined) {
      return null;
    }
    if (this.props.stories === undefined) {
      return null;
    }

    const posts = this.props.posts;

    if (this.props.homePageImages === undefined) {
      return null;
    }

    var users = this.getAllUsersFromStories();

    debugger;
    return (
      <Layout>
        {this.state.showTaggedModal ? (
          <TaggedUsersModal
            show={this.state.showTaggedModal}
            postId={this.state.post.id}
            onShowChange={this.displayModalPost.bind(this)}
          />
        ) : null}
        {this.state.showChooseCollectionModal ? (
          <ChooseCollectionModal
            show={this.state.showChooseCollectionModal}
            postId={this.state.post.id}
            onShowChange={this.displayModalCollection.bind(this)}
          />
        ) : null}
        <StoryCard users={users} />
        <InfiniteScroll
          dataLength={posts.length}
          next={this.fetchMoreData}
          hasMore={true}
          loader={<h4></h4>}
        >
          {posts.length === 0 ? (
            <div className="text-center pt-5">
              <img src="/images/noposts.png" />
              <br />
              <h4>No Posts Yet</h4>
            </div>
          ) : (
            posts.map((post, index) =>
              this.props.homePageImages[index].contentType === "image/jpeg" ? (
                <Card
                  style={{
                    marginTop: "40px",
                    marginBottom: "40px",
                    maxHeight: "900px",
                    height: "900px",
                  }}
                >
                  <CardHeader>
                    <img
                      src="images/nature.jpg"
                      style={{ width: 32, height: 32, borderRadius: 50 }}
                    />
                    <span style={{ width: 15, display: "inline-block" }}></span>
                    {post.registeredUser.username}
                  </CardHeader>
                  <CardBody>
                    <img
                      onClick={() => {
                        this.displayModalPost(post);
                      }}
                      src={
                        "data:image/jpg;base64," +
                        this.props.homePageImages[index].fileContents
                      }
                      style={{
                        maxHeight: "530px",
                        width: "100%",
                        height: "100%",
                      }}
                    />
                    <div>
                      {post.hashTags.map(
                        (hashTag) => hashTag.hashTagText + " "
                      )}
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
                    <a
                      style={{ float: "right" }}
                      className="mr-4"
                      href="javascript:;"
                    >
                      Report
                    </a>
                    <br />
                    <br />
                    <FormControlLabel
                      style={{ width: 24, height: 24 }}
                      control={
                        <Checkbox
                          onClick={() => {
                            this.likePost(post);
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
                        this.dislikePost(post);
                      }}
                      src="/images/dislike.png"
                    />
                    <span style={{ width: 15, display: "inline-block" }}></span>
                    <img src="/images/chat.png" />
                    <span style={{ width: 15, display: "inline-block" }}></span>
                    <img src="/images/send.png" />
                    <span style={{ width: 15, display: "inline-block" }}></span>
                    <img
                      style={{ width: 24, height: 24 }}
                      src="/images/collection.png"
                      onClick={() => {
                        this.displayModalCollection(post);
                      }}
                    />
                    <br />
                    <br />
                    Likes:{" "}
                    <a href="javascript:;" className="mr-2">
                      {post.likes.length}
                    </a>
                    Dislikes: <a href="javascript:;">{post.dislikes.length}</a>{" "}
                    <br />
                    <hr />
                    <div>
                      {post.comments.map((comment) => (
                        <div>
                          {comment.registeredUser.username +
                            ": " +
                            comment.commentText}
                          <br />
                          <hr />
                        </div>
                      ))}
                    </div>
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
                          this.commentPost(post);
                        }}
                        href=""
                      >
                        {" "}
                        Post{" "}
                      </a>
                    </div>
                  </CardBody>
                </Card>
              ) : (
                <Card
                  style={{
                    marginTop: "40px",
                    marginBottom: "40px",
                    maxHeight: "900px",
                    height: "900px",
                  }}
                >
                  <CardHeader>
                    <img
                      src="images/nature.jpg"
                      style={{ width: 32, height: 32, borderRadius: 50 }}
                    />
                    <span style={{ width: 15, display: "inline-block" }}></span>
                    {post.registeredUser.username}
                  </CardHeader>
                  <CardBody>
                    <video
                      controls
                      onClick={() => {
                        this.displayModalPost(post);
                      }}
                      style={{
                        maxHeight: "530px",
                        width: "100%",
                        height: "100%",
                      }}
                      className="mb-3"
                    >
                      <source
                        src={
                          "data:video/mp4;base64," +
                          this.props.homePageImages[index].fileContents
                        }
                        type="video/mp4"
                      ></source>
                    </video>
                    <div>
                      {post.hashTags.map(
                        (hashTag) => hashTag.hashTagText + " "
                      )}
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
                    <a
                      style={{ float: "right" }}
                      className="mr-4"
                      href="javascript:;"
                    >
                      Report
                    </a>
                    <br />
                    <br />
                    <FormControlLabel
                      style={{ width: 24, height: 24 }}
                      control={
                        <Checkbox
                          onClick={() => {
                            this.likePost(post);
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
                        this.dislikePost(post);
                      }}
                      src="/images/dislike.png"
                    />
                    <span style={{ width: 15, display: "inline-block" }}></span>
                    <img src="/images/chat.png" />
                    <span style={{ width: 15, display: "inline-block" }}></span>
                    <img src="/images/send.png" />
                    <span style={{ width: 15, display: "inline-block" }}></span>
                    <img
                      style={{ width: 24, height: 24 }}
                      src="/images/collection.png"
                      onClick={() => {
                        this.displayModalCollection(post);
                      }}
                    />
                    <br />
                    <br />
                    Likes:{" "}
                    <a href="javascript:;" className="mr-2">
                      {post.likes.length}
                    </a>
                    Dislikes: <a href="javascript:;">{post.dislikes.length}</a>{" "}
                    <br />
                    <hr />
                    {post.comments.map((comment) => (
                      <div>
                        {comment.registeredUser.username +
                          ": " +
                          comment.commentText}
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
                          this.commentPost(post);
                        }}
                        href=""
                      >
                        {" "}
                        Post{" "}
                      </a>
                    </div>
                  </CardBody>
                </Card>
              )
            )
          )}
        </InfiniteScroll>
      </Layout>
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

  async likePost(post) {
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

    var success = false;
    success = await this.props.likePost({
      id: post.id,
      userId: sessionStorage.getItem("userId"),
    });
    if (success === true) {
      this.setState({
        liked: !this.state.liked,
      });
      window.location.href = "http://localhost:3000/";
    } else {
      toast.configure();
      toast.error("You have already liked this post!", {
        position: toast.POSITION.TOP_RIGHT,
      });
    }
  }

  async getAllImages(posts) {
    const paths = [];
    for (var i = 0; i < posts.length; i++) {
      if (posts[i].contentPath === undefined) {
        paths.push(posts[i].contentPaths[0]);
      } else {
        paths.push(posts[i].contentPath);
      }
    }
    await this.props.getAllImages(paths);
  }

  async dislikePost(post) {
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

    var success = false;

    success = await this.props.dislikePost({
      id: post.id,
      userId: sessionStorage.getItem("userId"),
    });
    if (success === true) {
      this.setState({
        disliked: !this.state.disliked,
      });
      window.location.href = "http://localhost:3000/";
    } else {
      toast.configure();
      toast.error("You have already disliked this post!", {
        position: toast.POSITION.TOP_RIGHT,
      });
    }
  }

  async commentPost(post) {
    const comment = {
      CommentText: this.state.commentText,
      RegisteredUser: { id: sessionStorage.getItem("userId") },
    };
    debugger;
    await this.props.commentPost({ id: post.id, comment: comment });
    toast.configure();
    toast.success("Commented successfully!", {
      position: toast.POSITION.TOP_RIGHT,
    });
  }

  displayModalPost(post) {
    debugger;
    this.setState({
      post: post,
      showTaggedModal: !this.state.showTaggedModal,
    });
  }

  displayModalCollection(post) {
    debugger;
    this.setState({
      post: post,
      showChooseCollectionModal: !this.state.showChooseCollectionModal,
    });
  }

  fetchMoreData = () => {
    // a fake async api call like which sends
    // 20 more records in 1.5 secs
    setTimeout(() => {
      this.setState({
        items: this.state.items.concat(Array.from({ length: 20 })),
      });
    }, 1500);
  };
  getAllUsersFromStories = () => {
    debugger;
    var users = [];
    this.props.stories.forEach((story) => {
      if (!users.some((e) => e.id === story.registeredUser.id)) {
        users.push(story.registeredUser);
      }
    });
    debugger;
    return users;
  };
}

const mapStateToProps = (state) => ({
  following: state.following,
  posts: state.posts,
  homePageImages: state.homePageImages,
  stories: state.stories,
});

export default compose(
  withRouter,
  connect(mapStateToProps, {
    getFollowing,
    getPostsForFollowing,
    getAllImages,
    likePost,
    dislikePost,
    commentPost,
    getStories,
  })
)(HomePage);
