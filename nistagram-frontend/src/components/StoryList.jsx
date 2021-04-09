import React, { Component } from "react";
import "../StoryCircle.css";
import Story from "./Story";

class StoryList extends Component {
  state = {};
  render() {
    return (
      <div className="story-wrapper">
        {this.props.items.map((item, i) => (
          <Story item={item} i={i} />
        ))}
      </div>
    );
  }
}

export default StoryList;
