import React, { Component } from "react";
import {
  savePost,
  getLocations,
  getTaggableUsers,
} from "../../actions/actions";
import { connect } from "react-redux";
import axios from "axios";

class CreatePost extends Component {
  state = {
    file: null,
    fileName: "",
    fileUrl: null,
    description: "",
    location: {},
    locations: [],
    tag: "",
    contentPath: "",
    registeredUser: { id: "12345678-1234-1234-1234-123456789123" },
    taggableUsers: [],
    taggedUsers: [],
    taggableUser: {},
  };

  async componentDidMount() {
    await this.props.getLocations();
    this.setState({
      locations: this.props.locations,
    });

    await this.props.getTaggableUsers();
    this.setState({
      taggableUsers: this.props.taggableUsers,
    });
  }

  render() {
    if (
      this.props.locations == undefined ||
      this.props.taggableUsers == undefined
    ) {
      return null;
    }
    return (
      <React.Fragment>
        <div className="mt-5">
          <div className="d-inline-flex w-50">
            <div class="form-group w-100 pr-5">
              <input type="file" onChange={this.choosePost} />
              <img
                src={this.state.fileUrl}
                style={{ width: 500, height: 300 }}
              />
            </div>
          </div>
          <div className="d-inline-flex w-50">
            <div class="form-group w-100 pr-5">
              <label className="label">Description:</label>
              <textarea
                name="description"
                value={this.state.description}
                onChange={this.handleChange}
                cols="40"
                rows="5"
                class="form-control"
                placeholder="Enter description"
              ></textarea>
            </div>
          </div>
        </div>
        <div className="mt-5">
          <div className="d-inline-flex w-50">
            <div class="form-group w-100 pr-5">
              <label for="tag">People in this photo:</label>
              <select className="form-control" onChange={this.handleChangeUser}>
                <option>Select user</option>
                {this.state.taggableUsers.map((option, index) => (
                  <option key={index} value={index}>
                    {option.firstName +
                      " " +
                      option.lastName +
                      "(" +
                      option.username +
                      ")"}
                  </option>
                ))}
              </select>
            </div>
          </div>
          <div className="d-inline-flex w-50">
            <div class="form-group w-100 pr-5">
              <label for="location">Location:</label>
              <select
                className="form-control"
                onChange={this.handleChangeLocation}
              >
                <option>Select location</option>
                {this.state.locations.map((option, index) => (
                  <option key={index} value={index}>
                    {option.street +
                      ", " +
                      option.cityName +
                      ", " +
                      option.country}
                  </option>
                ))}
              </select>
            </div>
          </div>
        </div>
        <div className="mt-5 pb-5">
          <button
            className="btn btn-primary btn-block"
            onClick={() => {
              this.createPost();
            }}
          >
            Post
          </button>
        </div>
      </React.Fragment>
    );
  }

  async createPost() {
    await this.props.savePost({
      Description: this.state.description,
      RegisteredUser: this.state.registeredUser,
      Location: this.state.location,
      ContentPath: this.state.contentPath,
    });
  }

  handleChangeUser = (e) => {
    this.setState({ taggableUser: this.state.taggableUsers[e.target.value] });
  };

  handleChangeLocation = (e) => {
    this.setState({ location: this.state.locations[e.target.value] });
  };

  choosePost = async (event) => {
    this.setState({
      fileUrl: URL.createObjectURL(event.target.files[0]),
    });

    const formData = new FormData();

    formData.append("formFile", event.target.files[0]);
    formData.append("fileName", event.target.files[0].name);

    var dummyThis = this;
    try {
      const res = await axios({
        method: "post",
        url: "https://localhost:44355/api/posts/contents",
        data: formData,
        headers: {
          "Content-Type": "multipart/form-data",
          "Access-Control-Allow-Origin": "*",
        },
      })
        .then(function (response) {
          var contentPath = { ...dummyThis.state.contentPath };
          contentPath = response.data;
          dummyThis.setState({ contentPath });
        })
        .catch(function (response) {
          console.log(response);
        });
    } catch (ex) {
      console.log(ex);
    }
  };

  handleChange = (event) => {
    const { name, value, type, checked } = event.target;
    debugger;
    this.setState({
      [name]: value,
    });
  };
}

const mapStateToProps = (state) => ({
  locations: state.locations,
  taggableUsers: state.taggableUsers,
});

export default connect(mapStateToProps, {
  savePost,
  getLocations,
  getTaggableUsers,
})(CreatePost);
