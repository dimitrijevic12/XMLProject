import React, { Component } from "react";
import "./StoryCircle.css";
import Story from "./Story";

class StoryList extends Component {
  state = {};
  render() {
    debugger;
    return (
      <div className="story-wrapper">
        <Story item={{}} i={0} />
        {this.props.items.map((item, i) => (
          <Story item={item} i={i + 1} />
        ))}
      </div>
    );
  }
}

export default StoryList;
