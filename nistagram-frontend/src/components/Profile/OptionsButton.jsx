import React, { Component } from "react";
import OptionsModal from "./OptionsModal";

class OptionsButton extends Component {
  state = {
    showOptionsModal: false,
  };
  render() {
    return (
      <div>
        {this.state.showOptionsModal ? (
          <OptionsModal
            show={this.state.showOptionsModal}
            onShowChange={this.displayModalOptions.bind(this)}
          />
        ) : null}
        <button
          onClick={() => {
            this.displayModalOptions();
          }}
          style={{ float: "right" }}
          className="btn mr-5"
        >
          <label style={{ fontSize: "2.2rem" }}>...</label>
        </button>
      </div>
    );
  }

  displayModalOptions() {
    debugger;
    this.setState({
      showOptionsModal: !this.state.showOptionsModal,
    });
  }
}

export default OptionsButton;
