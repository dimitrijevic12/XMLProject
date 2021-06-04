import React, { Component } from "react";
import StoryModal from "./StoryModal";
import { loadImageStory } from "../../actions/actionsStory";
import { connect } from "react-redux";

class Story extends Component {
  state = {
    showStoryModal: false,
    user: {},
  };

  componentDidMount() {
    debugger;
    if (this.props.item.profilePicturePath !== undefined)
      this.props.loadImageStory(this.props.item.profilePicturePath);
  }

  render() {
    if (this.props.image === undefined) {
      return null;
    }
    debugger;
    return (
      <div>
        {this.state.showStoryModal ? (
          <StoryModal
            show={this.state.showStoryModal}
            onShowChange={this.displayModalStory.bind(this)}
            user={this.state.user}
            profileImage={this.props.image}
          />
        ) : null}
        <div
          className="story-circle"
          style={{
            backgroundImage:
              this.props.i === 0
                ? `url("/images/white_plus2.png")`
                : `url("data:image/jpg;base64,${this.props.image}"`,
            paddingBottom: "51px",
            backgroundSize: "50px",
            paddingRight: "51px",
          }}
          key={this.props.item.id}
          onClick={() => {
            this.displayModalStory(this.props.item.id);
          }}
        />
      </div>
    );
  }

  displayModalStory(userid) {
    debugger;
    this.setState({
      showStoryModal: !this.state.showStoryModal,
      user: userid,
    });
  }
}

const mapStateToProps = (state) => ({
  image: state.storyImage,
});

export default connect(mapStateToProps, { loadImageStory })(Story);
