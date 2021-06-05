import React, { Component } from "react";
import ProfileStoryModal from "./ProfileStoryModal";
import { connect } from "react-redux";
import { compose } from "redux";
import { withRouter } from "react-router-dom";

class ProfileStory extends Component {
  state = {
    showProfileStoryModal: false,
    user: {},
  };

  render() {
    debugger;
    return (
      <div>
        {this.state.showProfileStoryModal ? (
          <ProfileStoryModal
            show={this.state.showProfileStoryModal}
            onShowChange={this.displayModalProfileStory.bind(this)}
            user={this.state.user}
            profileImage={this.props.profileImage}
          />
        ) : null}
        <div
          className="ProfileStory-circle"
          style={{
            backgroundImage:
              this.props.first === true
                ? `url("/images/white_plus2.png")`
                : `url("data:image/jpg;base64,${this.props.profileImage}"`,
            paddingBottom: "51px",
            backgroundSize: "50px",
            paddingRight: "51px",
          }}
          key={this.props.item.id}
          onClick={() => {
            debugger;
            if (this.props.first === true)
              this.props.hiProfileStory.push({
                pathname: "/ProfileStory",
              });
            else this.displayModalProfileStory(this.props.item.id);
          }}
        />
      </div>
    );
  }

  displayModalProfileStory(userid) {
    debugger;
    this.setState({
      showProfileStoryModal: !this.state.showProfileStoryModal,
      user: userid,
    });
  }
}

const mapStateToProps = (state) => ({
  image: state.ProfileStoryImage,
});

export default compose(withRouter, connect(mapStateToProps, {}))(ProfileStory);
