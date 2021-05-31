import React, { Component } from "react";
import { savePost } from "../../actions/actions";
import { connect } from "react-redux";

class CreatePost extends Component {
  state = {
    file: null,
    fileName: "",
    fileUrl: null,
    description: "",
    location: "",
    tag: "",
  };

  render() {
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
              <input
                type="text"
                name="tag"
                value={this.state.tag}
                onChange={this.handleChange}
                class="form-control"
                id="tag"
                placeholder="Tag people"
              />
            </div>
          </div>
          <div className="d-inline-flex w-50">
            <div class="form-group w-100 pr-5">
              <label for="location">Location:</label>
              <select
                value={this.state.location}
                class="form-control"
                onChange={this.handleChange}
                name="location"
              >
                <option value=""> </option>
                <option value="Novi Sad, Serbia">Novi Sad, Serbia </option>
                <option value="Belgrade, Serbia">Belgrade, Serbia </option>
                <option value="Paris, France">Paris, France </option>
                <option value="London, UK">London, UK </option>
              </select>
            </div>
          </div>
        </div>
        <div className="mt-5 pb-5">
          <button
            onClick={this.createPost.bind(this)}
            className="btn btn-primary btn-block"
          >
            Post
          </button>
        </div>
      </React.Fragment>
    );
  }

  async createRegistration() {
    this.props.savePost(this.state.post);
  }

  choosePost = async (event) => {
    this.setState({
      fileUrl: URL.createObjectURL(event.target.files[0]),
    });
  };

  handleChange = (event) => {
    const { name, value, type, checked } = event.target;
    debugger;
    this.setState({
      [name]: value,
    });
  };
}

const mapStateToProps = (state) => ({});

export default connect(mapStateToProps, { savePost })(CreatePost);
