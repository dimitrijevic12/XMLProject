import React, { Component } from "react";
import StoryModal from "./StoryModal";

class Story extends Component {
  state = {
    showStoryModal: false,
  };
  render() {
    debugger;
    return (
      <div>
        {this.state.showStoryModal ? (
          <StoryModal
            show={this.state.showStoryModal}
            onShowChange={this.displayModalStory.bind(this)}
          />
        ) : null}
        <div
          className="story-circle"
          style={{
            backgroundImage: `url(${this.props.item.url}`,
            paddingBottom: "51px",
            paddingRight: "51px",
          }}
          key={this.props.item.id}
          onClick={() => {
            this.displayModalStory();
          }}
        />
      </div>
    );
  }

  displayModalStory() {
    debugger;
    this.setState({
      showStoryModal: !this.state.showStoryModal,
    });
  }
}

export default Story;
